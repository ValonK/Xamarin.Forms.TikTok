﻿using MvvmCross.Forms.Presenters.Attributes;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxContentPagePresentation(NoHistory = false, WrapInNavigationPage = true, ViewModelType = typeof(InboxViewModel))]
public partial class InboxView
{
    public InboxView()
    {
        InitializeComponent();
    }
}