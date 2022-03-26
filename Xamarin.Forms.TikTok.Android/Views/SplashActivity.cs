using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace Xamarin.Forms.TikTok.Droid.Views;

[Activity(
	NoHistory = true,
	MainLauncher = true,
	LaunchMode = LaunchMode.SingleTop,
	Label = "Xamarin.Forms.TikTok",
	Theme = "@style/MyTheme.Splash",
	Icon = "@mipmap/icon",
	RoundIcon = "@mipmap/icon")]
public class SplashActivity : MvxFormsSplashScreenActivity<Setup, Core.App, App>
{
	protected override Task RunAppStartAsync(Bundle bundle)
	{
		var intent = new Intent(this, typeof(MainActivity));
		if (Intent.Extras != null)
			intent.PutExtras(Intent.Extras);
		StartActivity(intent);

		return Task.CompletedTask;
	}
}