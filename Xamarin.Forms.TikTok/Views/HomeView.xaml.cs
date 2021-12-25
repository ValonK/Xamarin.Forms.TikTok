using Xamarin.Forms.TikTok.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private HomeViewModel _homeViewModel;

        public HomeView()
        {
            InitializeComponent();
            _homeViewModel = new HomeViewModel();

            BindingContext = _homeViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _homeViewModel?.Appearing();
            CarouselView.UserInteracted += CarouselView_UserInteracted;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _homeViewModel?.Disappearing();
        }

        private void CarouselView_UserInteracted(PanCardView.CardsView view, PanCardView.EventArgs.UserInteractedEventArgs args)
        {
            if (args.Status == PanCardView.Enums.UserInteractionStatus.Started)
            {
                MainView.DisableSwipe();
            }
            if (args.Status == PanCardView.Enums.UserInteractionStatus.Ended)
            {
                MainView.EnableSwipe();
            }
        }
    }
}