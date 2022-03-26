using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxContentPagePresentation(NoHistory = false, WrapInNavigationPage = true, ViewModelType = typeof(DiscoverViewModel))]
public partial class DiscoverPage 
{
    private DiscoverViewModel _discoverViewModel;

    public DiscoverPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}