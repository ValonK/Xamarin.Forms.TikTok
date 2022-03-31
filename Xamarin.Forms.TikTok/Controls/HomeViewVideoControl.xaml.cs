using System.Reflection;
using LibVLCSharp.Shared;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewVideoControl
    {
        public HomeViewVideoControl()
        {
            InitializeComponent();
        }

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                _mediaPlayer = value;
                OnPropertyChanged(nameof(MediaPlayer));
            }
        }

        public static readonly BindableProperty IsPlayingProperty =
            BindableProperty.Create(nameof(IsPlaying), typeof(bool),
                typeof(HomeViewVideoControl), false, propertyChanged: OnIsPlayingChanged);

        private static void OnIsPlayingChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is not HomeViewVideoControl home)
            {
                return;
            }

            if (home.IsPlaying)
            {
               home.Play();
            }
            else
            {
                home.Stop();
            }
        }

        public bool IsPlaying
        {
            get => (bool)GetValue(IsPlayingProperty);
            set => SetValue(IsPlayingProperty, value);
        }


        public static readonly BindableProperty VideoUrlProperty =
            BindableProperty.Create(nameof(VideoUrl), typeof(string),
                typeof(HomeViewVideoControl));

        private MediaPlayer _mediaPlayer;

        public string VideoUrl
        {
            get => (string)GetValue(VideoUrlProperty);
            set => SetValue(VideoUrlProperty, value);
        }

        private static StreamMediaInput PrepareMedia(string media)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"Xamarin.Forms.TikTok.Assets.Media.{media}");
            return new StreamMediaInput(stream);
        }

        private void Play()
        {
            var displayInfo = new DisplayInfo();
            var mediaSource = PrepareMedia(VideoUrl);
            MediaPlayer = new MediaPlayer(new Media(App.LibVLC, mediaSource));
            MediaPlayer.AspectRatio = $"{displayInfo.Height}:{displayInfo.Width}";
            MediaPlayer.Play();
        }

        private void Stop()
        {
            MediaPlayer.Stop();
            MediaPlayer.Dispose();
        }

    }
}