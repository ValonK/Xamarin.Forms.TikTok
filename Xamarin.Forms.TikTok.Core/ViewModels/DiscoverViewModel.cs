using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms.TikTok.Core.Models;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class DiscoverViewModel : BaseViewModel
    {
        private ObservableCollection<DiscoverItem> _items;

        public ObservableCollection<DiscoverItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public override Task Initialize()
        {
            Items = new ObservableCollection<DiscoverItem>
                {
                    new DiscoverItem
                    {
                        Image = "discoverPic2.png",
                    },
                    new DiscoverItem
                    {
                        Image = "discoverPic1.png",
                    },
                    new DiscoverItem
                    {
                        Image = "discoverPic2.png",
                    },
                    new DiscoverItem
                    {
                        Image = "discoverPic3.png",
                    },
                };
            return Task.CompletedTask;
        }
    }
}
