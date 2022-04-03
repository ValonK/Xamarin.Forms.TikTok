using System;
using System.Diagnostics;
using System.Reflection;
using LibVLCSharp.Shared;
using Xamarin.Essentials;
using Xamarin.Forms.TikTok.Helpers;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewVideoControl
    {
        private readonly DisplayInfo _displayInfo;
        private MediaPlayer _mediaPlayer;

        public HomeViewVideoControl()
        {
            InitializeComponent();
            _displayInfo = new DisplayInfo();
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

            var isPlaying = (bool)newvalue;
            if (isPlaying)
            {
                if (!Utils.IsPlaying)
                {
                    home.Play();
                }
            }
            else
            {
                if (Utils.IsPlaying)
                {
                    home.Stop();
                }
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
            try
            { 
                var mediaSource = PrepareMedia(VideoUrl);
                _mediaPlayer = new MediaPlayer(new Media(App.LibVLC, mediaSource));
                VideoView.MediaPlayer = _mediaPlayer;

                _mediaPlayer.AspectRatio = $"{_displayInfo.Height}:{_displayInfo.Width}";
                _mediaPlayer.PositionChanged += MediaPlayerOnPositionChanged;
                _mediaPlayer.Stopped += MediaPlayerOnStopped;
                PositionSlider.IsVisible = true;
                _mediaPlayer.Play();
                Utils.IsPlaying = true;
            }
            catch (Exception e) { Debug.Write(e.ToString()); }
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
            PositionSlider.IsVisible = false;
            _mediaPlayer.PositionChanged -= MediaPlayerOnPositionChanged;
            _mediaPlayer.Stopped -= MediaPlayerOnStopped;
            _mediaPlayer.Stop();
            _mediaPlayer.Dispose();
            Utils.IsPlaying = false;
        }
    }
}