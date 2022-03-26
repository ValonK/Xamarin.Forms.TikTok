using MvvmCross.IoC;
using MvvmCross.ViewModels;
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
        
        RegisterAppStart<InitializationViewModel>();
    }
}