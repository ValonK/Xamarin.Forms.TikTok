using System;
using System.Reflection;
using LibVLCSharp.Shared;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewVideoControl
    {
        private readonly DisplayInfo _displayInfo;
        private MediaPlayer _mediaPlayer;

        public event EventHandler MediaStopped;
        public event EventHandler MediaStarted; 

        public HomeViewVideoControl()
        {
            InitializeComponent();
            _displayInfo = new DisplayInfo();
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
            var mediaSource = PrepareMedia(VideoUrl);
            MediaPlayer = new MediaPlayer(new Media(App.LibVLC, mediaSource));
            MediaPlayer.AspectRatio = $"{_displayInfo.Height}:{_displayInfo.Width}";
            MediaPlayer.PositionChanged += MediaPlayerOnPositionChanged;
            MediaPlayer.Stopped += MediaPlayerOnStopped;
            MediaStarted?.Invoke(this, EventArgs.Empty);
            MediaPlayer.Play();
        }

        private void MediaPlayerOnStopped(object sender, EventArgs e)
        {
            PositionSlider.Value = 0;
        }

        private void MediaPlayerOnPositionChanged(object sender, MediaPlayerPositionChangedEventArgs e)
        {
            PositionSlider.Value = e.Position;
        }
        
        private void Stop()
        {
            MediaPlayer.PositionChanged -= MediaPlayerOnPositionChanged;
            MediaPlayer.Stopped -= MediaPlayerOnStopped;
            MediaStopped?.Invoke(this, EventArgs.Empty);
            MediaPlayer.Stop();
            MediaPlayer.Dispose();
        }
    }
}