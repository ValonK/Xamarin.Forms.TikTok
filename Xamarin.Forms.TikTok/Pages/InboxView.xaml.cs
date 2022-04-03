using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(Animated = true, ViewModelType = typeof(InboxViewModel))] 
public partial class InboxView
{
    public InboxView()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }
}