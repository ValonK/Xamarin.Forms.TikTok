using Xamarin.Forms.TikTok.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraView : ContentPage
    {
        private CameraViewModel _cameraViewModel;

        public CameraView()
        {
            InitializeComponent();

            _cameraViewModel = new CameraViewModel();
            BindingContext = _cameraViewModel;  
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _cameraViewModel.Appearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _cameraViewModel.Disappearing();
        }
    }
}