using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace Xamarin.Forms.TikTok.iOS
{
	public class Setup : MvxFormsIosSetup<Xamarin.Forms.TikTok.Core.App, App>
	{
		protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

		protected override ILoggerFactory CreateLogFactory()
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.NSLog()
				.CreateLogger();

			return new SerilogLoggerFactory();
		}
	}
}
