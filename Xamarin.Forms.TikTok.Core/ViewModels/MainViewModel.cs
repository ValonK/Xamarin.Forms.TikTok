using System.Threading.Tasks;
using MvvmCross.Navigation;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        public MainViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }
        
        public async Task SetupTabsAsync()
        {
            await _mvxNavigationService.Navigate(typeof(HomeViewModel));
            await _mvxNavigationService.Navigate(typeof(DiscoverViewModel));
            await _mvxNavigationService.Navigate(typeof(RecordViewModel));
            await _mvxNavigationService.Navigate(typeof(InboxViewModel));
            await _mvxNavigationService.Navigate(typeof(ProfileViewModel));
        }
    }
}
