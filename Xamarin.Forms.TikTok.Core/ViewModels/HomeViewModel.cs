using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LibVLCSharp.Shared;
using MvvmCross.Commands;
using PanCardView.EventArgs;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms.Internals;
using Xamarin.Forms.TikTok.Core.Models;
using Xamarin.Forms.TikTok.Core.Services.Media;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMediaService _mediaService;
        private readonly IDeviceDisplay _deviceDisplay;
        
        private ObservableCollection<TikTokItem> _items;
        private TikTokItem _currentItem;
        private MediaPlayer _mediaPlayer;

        private LibVLC _libVlc;
        private double _position;
        private bool _positionVisible;

        public HomeViewModel(
            IMediaService mediaService, 
            IDeviceDisplay deviceDisplay)
        {
            _mediaService = mediaService;
            _deviceDisplay = deviceDisplay;
            ItemAppearingCommand = new MvxCommand<ItemAppearingEventArgs>(OnItemAppearing);
            ItemDisappearingCommand = new MvxCommand<ItemDisappearingEventArgs>(OnItemDisapearing);
        }

        public ObservableCollection<TikTokItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public TikTokItem CurrentItem
        {
            get => _currentItem;
            set => SetProperty(ref _currentItem, value);
        }

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set => SetProperty(ref _mediaPlayer, value);
        }

        public double Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        public bool PositionVisible
        {
            get => _positionVisible;
            set => SetProperty(ref _positionVisible, value);
        }

        public IMvxCommand<ItemAppearingEventArgs> ItemAppearingCommand { get; }

        public IMvxCommand<ItemDisappearingEventArgs> ItemDisappearingCommand { get; }
        
        public override async void ViewAppearing()
        {
            if (Items == null)
            {
                IsBusy = true;
                await Task.Delay(3000);
                Items = new ObservableCollection<TikTokItem>(_mediaService.GetMediaItems());
                CurrentItem = Items.First();
                IsBusy = false;
            }
            else
            {   
                CurrentItem.IsPlaying = true;
            }
        }

        public override Task Initialize()
        {
            _libVlc = new LibVLC(true);
            return Task.CompletedTask;
        }

        public override void ViewDisappearing()
        {
            if (Items.Count == 0) return;
            
            foreach (var tikTokItem in Items)
            {
                if (tikTokItem.IsPlaying) { tikTokItem.IsPlaying = false; }
            } 
        }

        private void OnItemDisapearing(ItemDisappearingEventArgs eventArgs)
        {
            if (eventArgs.Item is TikTokItem {IsPlaying: true} item)
            {
                item.IsPlaying = false;
                Stop();
            }
        }

        private void OnItemAppearing(ItemAppearingEventArgs eventArgs)
        {
            if (eventArgs.Item is TikTokItem { IsPlaying: false } item)
            {
                item.IsPlaying = true;
                Play(item.VideoUrl);
            }
        }
        
        private void Play(string videoUrl)
        {
            try
            {
                var mediaSource = _mediaService.PrepareMedia(videoUrl);
                MediaPlayer = new MediaPlayer(new Media(_libVlc, mediaSource));

                MediaPlayer.AspectRatio = $"{_deviceDisplay.MainDisplayInfo.Height}:{_deviceDisplay.MainDisplayInfo.Width}";
                MediaPlayer.PositionChanged += MediaPlayerOnPositionChanged;
                MediaPlayer.Stopped += MediaPlayerOnStopped;
                PositionVisible = true;
                MediaPlayer.Play();
            }
            catch (Exception e) { Debug.Write(e.ToString()); }
        }
        
        private void MediaPlayerOnStopped(object sender, EventArgs e)
        {
            Position = 0;
        }

        private void MediaPlayerOnPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            Position = e.Position;
        }
        
        private void Stop()
        {
            PositionVisible = false;
            MediaPlayer.PositionChanged -= MediaPlayerOnPositionChanged;
            MediaPlayer.Stopped -= MediaPlayerOnStopped;
            MediaPlayer.Stop();
            MediaPlayer.Dispose();
        }
    }
}