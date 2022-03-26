using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using PanCardView.Droid;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.TikTok.Droid;

[Activity(Label = "Xamarin.Forms.TikTok",
    Icon = "@mipmap/icon",
    Theme = "@style/MainTheme", 
    MainLauncher = false,
    ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
public class MainActivity : MvxFormsAppCompatActivity
{
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        InitializePackages(bundle);
        Window?.SetStatusBarColor(Color.Black.ToAndroid());
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    private void InitializePackages(Bundle savedInstanceState)
    {
        Essentials.Platform.Init(this, savedInstanceState);
        CardsViewRenderer.Preserve(); 
    }
}