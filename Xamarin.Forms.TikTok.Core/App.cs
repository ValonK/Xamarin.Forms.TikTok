using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms.TikTok.Core.Services.Media;
using Xamarin.Forms.TikTok.Core.ViewModels;

namespace Xamarin.Forms.TikTok.Core;

public class App : MvxApplication
{
    public override void Initialize()
    {
        CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();
        
        Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IDeviceDisplay, DeviceDisplayImplementation>();
        Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IMediaService, MediaService>();
        
        RegisterAppStart<InitializationViewModel>();
    }
}