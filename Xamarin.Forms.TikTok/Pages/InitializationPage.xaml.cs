using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxContentPagePresentation(NoHistory = false, WrapInNavigationPage = true, ViewModelType = typeof(InitializationViewModel))]
public partial class InitializationPage 
{
    public InitializationPage()
    {
        InitializeComponent();
    }
}