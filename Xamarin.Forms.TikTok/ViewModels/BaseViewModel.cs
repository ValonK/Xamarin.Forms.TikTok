using Xamarin.Forms.TikTok.Models;

namespace Xamarin.Forms.TikTok.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}
