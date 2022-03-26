using System.Threading.Tasks;
using MvvmCross.Navigation;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;

        private bool _tabsLoaded;

        
        public MainViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            if (_tabsLoaded != false) return;
            await SetupTabsAsync();
            _tabsLoaded = true;
        }
        
        private async Task SetupTabsAsync()
        {
            await _mvxNavigationService.Navigate(typeof(HomeViewModel));
            await _mvxNavigationService.Navigate(typeof(DiscoverViewModel));
            await _mvxNavigationService.Navigate(typeof(RecordViewModel));
            await _mvxNavigationService.Navigate(typeof(InboxViewModel));
            await _mvxNavigationService.Navigate(typeof(ProfileViewModel));
        }
    }
}
