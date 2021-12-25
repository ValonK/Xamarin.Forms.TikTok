using Android.App;
using Android.Content;
using System.Threading.Tasks;
using AndroidX.AppCompat.App;

namespace Xamarin.Forms.TikTok.Droid
{
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnResume()
        {
            base.OnResume();
            var startupWork = new Task(SimulateStartup);
            startupWork.Start();
        }
        
        async void SimulateStartup ()
        {
            await Task.Delay (2000);
            StartActivity(new Intent(global::Android.App.Application.Context, typeof (MainActivity)));
        }
    }
}