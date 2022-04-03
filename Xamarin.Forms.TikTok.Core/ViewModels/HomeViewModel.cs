using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using PanCardView.EventArgs;
using Xamarin.Forms.Internals;
using Xamarin.Forms.TikTok.Core.Models;
using Xamarin.Forms.TikTok.Core.Services.Media;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IMediaService _mediaService;
        
        private ObservableCollection<TikTokItem> _items;
        private TikTokItem _currentItem;
        
        public HomeViewModel(IMediaService mediaService)
        {
            _mediaService = mediaService;
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
        
        public IMvxCommand<ItemAppearingEventArgs> ItemAppearingCommand { get; }

        public IMvxCommand<ItemDisappearingEventArgs> ItemDisappearingCommand { get; }
        
        public override void ViewAppearing()
        {
            if (Items == null)
            {
                IsBusy = true;
                Items = new ObservableCollection<TikTokItem>(_mediaService.GetMediaItems());
                CurrentItem = Items.First();
                IsBusy = false;
            }
            else
            {   
                CurrentItem.IsPlaying = true;
            }
        }
        
        public override void ViewDisappearing()
        {
            if (Items.Count == 0) return;
            
            foreach (var tikTokItem in Items)
            {
                if (tikTokItem.IsPlaying) { tikTokItem.IsPlaying = false; }
            } 
        }

        private static void OnItemDisapearing(ItemDisappearingEventArgs eventArgs)
        {
            if (eventArgs.Item is TikTokItem {IsPlaying: true} item)
            {
                item.IsPlaying = false;
            }
        }

        private void OnItemAppearing(ItemAppearingEventArgs eventArgs)
        {
            if (eventArgs.Item is TikTokItem { IsPlaying: false } item)
            {
                Items.ForEach(x =>
                {
                    if (x.VideoUrl != item.VideoUrl)
                    {
                        x.IsPlaying = false;
                    }
                }); 
                
                item.IsPlaying = true;
            }
        }
    }
}