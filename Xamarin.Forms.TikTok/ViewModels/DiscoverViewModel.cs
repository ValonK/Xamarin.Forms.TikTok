using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.TikTok.Models;

namespace Xamarin.Forms.TikTok.ViewModels
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

        public override async void Appearing()
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

        public override void Disappearing()
        {

        }
    }
}
