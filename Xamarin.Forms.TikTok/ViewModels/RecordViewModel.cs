using Xamarin.CommunityToolkit.UI.Views;

namespace Xamarin.Forms.TikTok.ViewModels
{
    public class RecordViewModel : BaseViewModel
    {
        public override async void Appearing()
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Views.CameraView(), true);
        }

        public override void Disappearing()
        {

        }
    }
}
