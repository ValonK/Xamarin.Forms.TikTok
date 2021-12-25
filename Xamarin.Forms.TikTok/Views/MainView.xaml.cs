using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : TabbedPage
    {
        public static MainView Current { get; private set; }

        public MainView()
        {
            InitializeComponent();
            Current = this;
        }

        public static void DisableSwipe()
        {
            Current.On<Android>().DisableSwipePaging();
        }
    
        public static void EnableSwipe()
        {
            Current.On<Android>().EnableSwipePaging();
        }
    }
}