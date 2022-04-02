namespace Xamarin.Forms.TikTok.Core.Models
{
    public class DiscoverItem : ObservableObject
    {
        private string _name;
        private string _image;

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
    }
}
