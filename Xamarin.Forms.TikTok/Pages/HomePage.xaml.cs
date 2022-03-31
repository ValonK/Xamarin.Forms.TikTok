using System.Threading.Tasks;
using MvvmCross.Forms.Presenters.Attributes;
using PanCardView;
using PanCardView.Enums;
using PanCardView.EventArgs;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(Animated = true, ViewModelType = typeof(HomeViewModel))] 
public partial class HomePage
{
    private bool _isRotating;
    
    public HomePage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CarouselView.UserInteracted += CarouselView_UserInteracted;
        await RotateElement(ArtistImage);

    }
    
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _isRotating = true;
        CarouselView.UserInteracted -= CarouselView_UserInteracted;
    }

    private async Task RotateElement(VisualElement element)
    {
        _isRotating = false;
        while (!_isRotating) 
        { 
            await element.RotateTo(360, 1900, Easing.Linear); 
            await element.RotateTo(0, 0);
        }
    } 

    private static void CarouselView_UserInteracted(CardsView view, UserInteractedEventArgs args)
    {
        if (args.Status == UserInteractionStatus.Started)
        {
            MainPage.DisableSwipe();
        }
        else if (args.Status == UserInteractionStatus.Ended)
        {
            MainPage.EnableSwipe();
        }
    }
}