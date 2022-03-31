using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using LibVLCSharp.Forms.Shared;
using MvvmCross.Forms.Platforms.Android.Views;
using PanCardView.Droid;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.TikTok.Core.ViewModels;

namespace Xamarin.Forms.TikTok.Droid.Views;

[Activity(Theme = "@style/AppTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
public class MainActivity : MvxFormsAppCompatActivity<ViewModel>
{
    protected override void OnCreate(Bundle bundle)
    {
        InitializePackages(bundle);
        CrossCurrentActivity.Current.Activity = this;
        RequestedOrientation = ScreenOrientation.Portrait;

        TabLayoutResource = Resource.Layout.Tabbar;
        ToolbarResource = Resource.Layout.Toolbar;
        
        Window?.SetStatusBarColor(Color.Black.ToAndroid());
        base.OnCreate(bundle);
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    private void InitializePackages(Bundle bundle)
    {
        LibVLCSharpFormsRenderer.Init();
        CrossCurrentActivity.Current.Init(this, bundle);
        Essentials.Platform.Init(this, bundle);
        CardsViewRenderer.Preserve(); 
    }
}