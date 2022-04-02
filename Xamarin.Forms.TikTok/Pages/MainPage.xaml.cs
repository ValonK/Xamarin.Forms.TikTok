using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(TabbedPosition.Root, ViewModelType = typeof(MainViewModel))]
public partial class MainPage 
{
    public static MainPage Current { get; private set; }

    public MainPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        Current = this;
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