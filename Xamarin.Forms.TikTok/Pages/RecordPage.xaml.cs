using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms.TikTok.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Pages;

[XamlCompilation(XamlCompilationOptions.Compile)]
[MvxTabbedPagePresentation(Animated = true, ViewModelType = typeof(RecordViewModel))]
public partial class RecordPage : MvxContentPage<RecordViewModel>
{
    public RecordPage()
    {
        InitializeComponent();
    }
}