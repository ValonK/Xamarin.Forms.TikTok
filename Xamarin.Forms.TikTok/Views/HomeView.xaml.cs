using PanCardView;
using PanCardView.EventArgs;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView
    {
        private readonly HomeViewModel _homeViewModel;
        private bool _isRotating;

        public HomeView()
        {
            InitializeComponent();
            _homeViewModel = new HomeViewModel();

            BindingContext = _homeViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CarouselView.UserInteracted += CarouselView_UserInteracted;
            RotateElement(ArtistImage);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _isRotating = true;
            CarouselView.UserInteracted -= CarouselView_UserInteracted;
        }

        private async void RotateElement(VisualElement element)
        {
            _isRotating = false;
            while (!_isRotating) 
            { 
                await element.RotateTo(360, 1900, Easing.Linear); 
                await element.RotateTo(0, 0);
            }
        } 

        private static void CarouselView_UserInteracted(CardsView view, UserInteractedEventArgs args)
        {
            switch (args.Status)
            {
                case PanCardView.Enums.UserInteractionStatus.Started:
                    MainView.DisableSwipe();
                    break;
                case PanCardView.Enums.UserInteractionStatus.Ended:
                    MainView.EnableSwipe();
                    break;
            }
        }
    }
}