using System.Threading.Tasks;
using MvvmCross.ViewModels;

namespace Xamarin.Forms.TikTok.Core.ViewModels._Base
{
    public abstract class BaseViewModelResult<TResult> : BaseViewModel, IMvxViewModelResult<TResult>
    {
        public TaskCompletionSource<object> CloseCompletionSource { get; set; }

        public override void ViewDestroy(bool viewFinishing = true)
        {
            if (viewFinishing && CloseCompletionSource.Task.IsCompleted == false && !CloseCompletionSource.Task.IsFaulted)
                CloseCompletionSource.TrySetCanceled();

            base.ViewDestroy(viewFinishing);
        }
    }
}
