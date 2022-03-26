using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(Animated = true, WrapInNavigationPage = true, ViewModelType = typeof(ProfileViewModel))]
public partial class ProfilePage 
{
    public ProfilePage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}