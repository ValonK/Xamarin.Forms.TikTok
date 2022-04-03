using System.Collections.Generic;
using MvvmCross.Forms.Views;
using MvvmCross.ViewModels;

namespace Xamarin.Forms.TikTok.Core.Helpers;

internal static class Utils
{
    internal static IList<IMvxViewModel> GetActiveViewModels()
    {
        if (Application.Current.MainPage is not NavigationPage navigationPage)
        {
            return null;
        }
        
        if (navigationPage.CurrentPage is not MvxTabbedPage mvxTabbedPage)
        {
            return null;
        }

        if (mvxTabbedPage.Children.Count <= 1)
        {
            return null;
        }

        var viewModels = new List<IMvxViewModel>();
        foreach (var page in mvxTabbedPage.Children)
        {
            if (page is not NavigationPage childNavigationPage)
            {
                continue;
            }

            if (childNavigationPage.CurrentPage is IMvxPage { DataContext: IMvxViewModel viewModel })
            {
                viewModels.Add(viewModel);
            }
        }

        return viewModels;
    } 
}