using Android.App;
using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Android.Core;
using Serilog;
using Serilog.Extensions.Logging;

#if DEBUG
[assembly: Application(Debuggable = true)]
#else
[assembly: Application(Debuggable = false)]
#endif

namespace Xamarin.Forms.TikTok.Droid
{
	public class Setup : MvxFormsAndroidSetup<Xamarin.Forms.TikTok.Core.App, App>
	{
		protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

		protected override ILoggerFactory CreateLogFactory()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.AndroidLog()
				.CreateLogger();

			return new SerilogLoggerFactory();
		}
	}
}
