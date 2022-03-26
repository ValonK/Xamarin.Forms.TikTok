namespace Xamarin.Forms.TikTok.Models
{
    public class DiscoverItem : ObservableObject
    {
        private string _name;
        private string _image;
        private bool _isAnimating;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public bool IsAnimating
        {
            get => _isAnimating;
            set => SetProperty(ref _isAnimating, value);
        }
    }
}
