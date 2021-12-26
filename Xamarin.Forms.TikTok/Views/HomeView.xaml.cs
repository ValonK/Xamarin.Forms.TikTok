using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms.TikTok.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private HomeViewModel _homeViewModel;
        private bool _isRotating;

        public HomeView()
        {
            InitializeComponent();
            _homeViewModel = new HomeViewModel();

            BindingContext = _homeViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            _homeViewModel?.Appearing();
            CarouselView.UserInteracted += CarouselView_UserInteracted;
            RotateElement(ArtistImage);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isRotating = false;
            CarouselView.UserInteracted -= CarouselView_UserInteracted;
            _homeViewModel?.Disappearing();
        }

        private async void RotateElement(VisualElement element)
        {
            _isRotating = true;
            while (!_isRotating) 
            { 
                await element.RotateTo(360, 1900, Easing.Linear); 
                await element.RotateTo(0, 0);
            }
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