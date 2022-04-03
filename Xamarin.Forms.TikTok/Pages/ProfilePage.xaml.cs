using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(Animated = true, ViewModelType = typeof(ProfileViewModel))]
public partial class ProfilePage : MvxContentPage<ProfileViewModel>
{
    public ProfilePage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}