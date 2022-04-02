using System;
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
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        CarouselView.UserInteracted -= CarouselView_UserInteracted;
    }

    private async Task RotateElement(VisualElement element)
    {
        while (true)
        {
            if (!_isRotating)
                break;
            
            await element.RotateTo(360, 1900, Easing.Linear);
            await element.RotateTo(0, 0);
        }
    }

    private static void CarouselView_UserInteracted(CardsView view, UserInteractedEventArgs args)
    {
        switch (args.Status)
        {
            case UserInteractionStatus.Started:
                MainPage.DisableSwipe();
                break;
            case UserInteractionStatus.Ended:
                MainPage.EnableSwipe();
                break;
        }
    }

    private async void HomeViewVideoControl_OnMediaStarted(object sender, EventArgs e)
    {
        _isRotating = true;
        await RotateElement(ArtistImage);
    }

    private void HomeViewVideoControl_OnMediaStopped(object sender, EventArgs e)
    {
        _isRotating = false;
    }
}