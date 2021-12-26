using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscoverItemControl : ContentView
    {
        public DiscoverItemControl()
        {
            InitializeComponent();
        }

        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        public static readonly BindableProperty SubtitleProperty =
            BindableProperty.Create(nameof(Subtitle), typeof(string),
                typeof(DiscoverItemControl));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string),
                typeof(DiscoverItemControl));
    }
}