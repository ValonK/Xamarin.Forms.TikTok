using System;
using MvvmCross.Forms.Views;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.TikTok.Core.ViewModels._Base;

namespace Xamarin.Forms.TikTok.Behaviors;

public class TabbedPageBehavior : Behavior<MvxTabbedPage<MainViewModel>>
{
    public MvxTabbedPage<MainViewModel> AssociatedObject { get; set; }

    protected override void OnAttachedTo(MvxTabbedPage<MainViewModel> bindable)
    {
        bindable.CurrentPageChanged += BindableOnCurrentPageChanged;
        base.OnAttachedTo(bindable);
        AssociatedObject = bindable;
    }

    private void BindableOnCurrentPageChanged(object sender, EventArgs e)
    {
        if (AssociatedObject?.ViewModel == null)
            return;

        if (AssociatedObject.CurrentPage is not NavigationPage navigationPage)
        {
            return;
        }

        if (navigationPage.CurrentPage is not IMvxPage p)
        {
            return;
        }
        
        BaseViewModel.OnTabChanged(p.ViewModel);
    }

    protected override void OnDetachingFrom(MvxTabbedPage<MainViewModel> bindable)
    {        
        bindable.CurrentPageChanged -= BindableOnCurrentPageChanged;
        base.OnDetachingFrom(bindable);
        AssociatedObject = null;
    }
}