using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using MvvmCross.Forms.Platforms.Android.Views;
using PanCardView.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.TikTok.Droid.Views;

[Activity(Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : MvxFormsAppCompatActivity
{
    public static MainActivity MainActivityInstance;

    protected override void OnCreate(Bundle bundle)
    {
        MainActivityInstance = this;
        CrossCurrentActivity.Current.Activity = this;
        RequestedOrientation = ScreenOrientation.Portrait;

        TabLayoutResource = Resource.Layout.Tabbar;
        ToolbarResource = Resource.Layout.Toolbar;
        InitializePackages(bundle);

        base.OnCreate(bundle);
        Window?.SetStatusBarColor(Color.Black.ToAndroid());
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    private void InitializePackages(Bundle bundle)
    {
        CrossCurrentActivity.Current.Init(this, bundle);
        Essentials.Platform.Init(this, bundle);
        CardsViewRenderer.Preserve(); 
    }
}