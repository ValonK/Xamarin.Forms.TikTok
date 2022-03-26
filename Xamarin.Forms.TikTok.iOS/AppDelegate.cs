using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using PanCardView.iOS;
using UIKit;

namespace Xamarin.Forms.TikTok.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : MvxFormsApplicationDelegate<Setup, Xamarin.Forms.TikTok.Core.App, App>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            InitializePackages();
            return base.FinishedLaunching(uiApplication, launchOptions);
        }
        
        private static void InitializePackages()
        {
            CardsViewRenderer.Preserve(); 
        }
    }
}
