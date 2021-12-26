using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewVideoControl : ContentView
    {
        private MediaElement _mediaElement;

        public HomeViewVideoControl()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty IsPlayingProperty =
            BindableProperty.Create (nameof(IsPlaying), typeof(bool),
                typeof(HomeViewVideoControl), false, propertyChanged: OnIsPlayingChanged);

        private static void OnIsPlayingChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!(bindable is HomeViewVideoControl home))
            {
                return;
            }

            if (home.IsPlaying)
            {
                if (home._mediaElement == null)
                {
                    home._mediaElement = new MediaElement
                    {
                        Source = home.VideoUrl,
                        Aspect = Aspect.AspectFill,
                        ShowsPlaybackControls = false
                    };

                    home.Container.Children.Add(home._mediaElement);
                }
                
                home._mediaElement.Play();
            }
            else
            {
                home._mediaElement.Stop();
            }
        }
        
        public bool IsPlaying
        {
            get => (bool)GetValue (IsPlayingProperty);
            set => SetValue (IsPlayingProperty, value);
        }

           
        public static readonly BindableProperty VideoUrlProperty =
            BindableProperty.Create (nameof(VideoUrl), typeof(string),
                typeof(HomeViewVideoControl));

        public string VideoUrl
        {
            get => (string)GetValue (VideoUrlProperty);
            set => SetValue (VideoUrlProperty, value);
        }


    }
}