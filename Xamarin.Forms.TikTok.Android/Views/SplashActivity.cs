using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;
using Xamarin.Forms.Platform.Android;

namespace Xamarin.Forms.TikTok.Droid.Views;

[Activity(
	NoHistory = true,
	MainLauncher = true,
	LaunchMode = LaunchMode.SingleTop,
	Label = "Xamarin.Forms.TikTok",
	Theme = "@style/AppTheme.Splash",
	Icon = "@mipmap/icon",
	RoundIcon = "@mipmap/icon")]
public class SplashActivity : MvxFormsSplashScreenActivity<Setup, Core.App, App>
{
	protected override Task RunAppStartAsync(Bundle bundle)
	{
		StartActivity(typeof(MainActivity));
		return Task.CompletedTask;
	}
}