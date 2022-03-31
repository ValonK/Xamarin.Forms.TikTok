using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using MvvmCross.Commands;
using PanCardView.EventArgs;
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
        
        public override async void ViewAppearing()
        {
            IsBusy = true;

            CurrentItem = Items.First();

            await Task.Delay(1200);
            IsBusy = false;
        }

        public override Task Initialize()
        {
            Items = new ObservableCollection<TikTokItem>(_mediaService.GetMediaItems());
            return Task.CompletedTask;
        }

        public override void ViewDisappearing()
        {
            Items.Clear();
        }

        private static void OnItemDisapearing(ItemDisappearingEventArgs eventArgs)
        {
            if (eventArgs.Item is TikTokItem item)
            {
                item.IsPlaying = false;
            }
        }

        private static void OnItemAppearing(ItemAppearingEventArgs eventArgs)
        {
            if (eventArgs.Item is TikTokItem item)
            {
                item.IsPlaying = true;
            }
        }
    }
}