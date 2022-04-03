using MvvmCross.Navigation;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels;

public class InitializationViewModel : BaseViewModel
{
    private readonly IMvxNavigationService _mvxNavigationService;

    public InitializationViewModel(IMvxNavigationService mvxNavigationService)
    {
        _mvxNavigationService = mvxNavigationService;
    }

    public override async void ViewAppearing()
    {
        base.ViewAppearing();
        await _mvxNavigationService.Navigate<MainViewModel>();
    }
}