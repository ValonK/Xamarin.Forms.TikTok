using Xamarin.Forms.TikTok.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecordView : ContentPage
    {
        private RecordViewModel _recordViewModel;

        public RecordView()
        {
            InitializeComponent();

            _recordViewModel = new RecordViewModel();
            BindingContext = _recordViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _recordViewModel.Appearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _recordViewModel.Disappearing();
        }
    }
}