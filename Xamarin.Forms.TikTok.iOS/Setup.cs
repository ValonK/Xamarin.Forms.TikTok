using Microsoft.Extensions.Logging;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace Xamarin.Forms.TikTok.iOS
{
	public class Setup : MvxFormsIosSetup<Xamarin.Forms.TikTok.Core.App, App>
	{
		protected override ILoggerProvider CreateLogProvider()
		{
			return null;
		}

		protected override ILoggerFactory CreateLogFactory()
		{
			return null;
		}
	}
}
