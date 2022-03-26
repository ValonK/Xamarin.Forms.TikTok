using System.Collections.ObjectModel;
using Xamarin.Forms.TikTok.Core.Models;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class DiscoverViewModel : BaseViewModel
    {
        private ObservableCollection<DiscoverItem> _items;

        #region Properties

        public ObservableCollection<DiscoverItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        #endregion

        public override void ViewAppearing()
        {
            Items = new ObservableCollection<DiscoverItem>
            {
                new DiscoverItem
                {
                    Image = "gif4.gif", 
                    IsAnimating = true
                },
                new DiscoverItem
                {
                    Image = "discoverPic1.png",
                    IsAnimating = false
                },
                new DiscoverItem
                {
                    Image = "discoverPic2.png",
                    IsAnimating = false
                },
                new DiscoverItem
                {
                    Image = "discoverPic3.png",
                    IsAnimating = false
                },
            };
        }
    }
}
