using System;
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

        private void MainView_OnCurrentPageChanged(object sender, EventArgs e)
        {
            if (Children?.Count != 5)
            {
                return;
            }

            if (CurrentPage is HomeView)
            {
                BarBackgroundColor = Color.Black;
                MessagingCenter.Send(this, "TabColor", Color.White);

                Current.On<Android>().Element.SelectedTabColor = Color.White;
                Current.On<Android>().Element.UnselectedTabColor = Color.White;
            }
            else
            {
                BarBackgroundColor = Color.White;
                MessagingCenter.Send(this, "TabColor", Color.Black);
                Current.On<Android>().Element.SelectedTabColor = Color.Black;
                Current.On<Android>().Element.UnselectedTabColor = Color.Black;
            }
        }
    }
}