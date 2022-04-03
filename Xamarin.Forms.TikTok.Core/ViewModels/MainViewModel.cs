using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Navigation;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IMvxNavigationService _mvxNavigationService;
        private bool _tabsInitialized;
        
        public MainViewModel(IMvxNavigationService mvxNavigationService)
        {
            _mvxNavigationService = mvxNavigationService;
        }

        public override async void ViewAppearing()
        {
            base.ViewAppearing();

            if (_tabsInitialized) return;
            
            await SetupTabsAsync();
            _tabsInitialized = true;
        }
        
        private Task SetupTabsAsync()
        {
            var tabTasks = new List<Task>
            {
                _mvxNavigationService.Navigate<HomeViewModel>(),
                _mvxNavigationService.Navigate<DiscoverViewModel>(),
                _mvxNavigationService.Navigate<RecordViewModel>(),
                _mvxNavigationService.Navigate<InboxViewModel>(),
                _mvxNavigationService.Navigate<ProfileViewModel>(),
            };
            return Task.WhenAll(tabTasks);
        }
    }
}
