using Xamarin.Forms.TikTok.Models;

namespace Xamarin.Forms.TikTok.ViewModels
{
    public abstract class BaseViewModel : ObservableObject
    {
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        public abstract void Appearing();
        public abstract void Disappearing();
    }
}
