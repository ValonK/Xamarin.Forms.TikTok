using Xamarin.Forms.TikTok.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscoverView : ContentPage
    {
        private DiscoverViewModel _discoverViewModel;

        public DiscoverView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _discoverViewModel = new DiscoverViewModel();
            BindingContext = _discoverViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _discoverViewModel.Appearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _discoverViewModel.Disappearing();
        }
    }
}