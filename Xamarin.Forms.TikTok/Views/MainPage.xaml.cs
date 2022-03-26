using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(TabbedPosition.Root, NoHistory = true, ViewModelType = typeof(MainViewModel))]
public partial class MainPage
{
    private bool _tabsLoaded;
    public static MainPage Current { get; private set; }

    public MainPage()
    {
        InitializeComponent();
        Current = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
            
        if (_tabsLoaded == false)
        {
            await ViewModel.SetupTabsAsync();
            _tabsLoaded = true;
        }
    }

    public static void DisableSwipe()
    {
        Current.On<Android>().DisableSwipePaging();
    }
    
    public static void EnableSwipe()
    {
        Current.On<Android>().EnableSwipePaging();
    }
}