using Android.App;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace Xamarin.Forms.TikTok.Droid
{
	public class Setup : MvxFormsAndroidSetup<Xamarin.Forms.TikTok.Core.App, App>
	{
		protected override ILoggerProvider CreateLogProvider()
		{
			// TODO add LogProvider / Serilog or Nlog
			return null;
		}

		protected override ILoggerFactory CreateLogFactory()
		{
			// TODO add LogProvider / Serilog or Nlog
			return null;
		}
	}
}
