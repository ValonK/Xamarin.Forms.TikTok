using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscoverView 
    {
        private DiscoverViewModel _discoverViewModel;

        public DiscoverView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _discoverViewModel = new DiscoverViewModel();
            BindingContext = _discoverViewModel;
        }
    }
}