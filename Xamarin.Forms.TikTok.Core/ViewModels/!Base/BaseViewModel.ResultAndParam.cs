using MvvmCross.ViewModels;

namespace Xamarin.Forms.TikTok.Core.ViewModels._Base
{
    public abstract class BaseViewModel<TParameter, TResult> : BaseViewModelResult<TResult>, IMvxViewModel<TParameter, TResult>
    {
        public abstract void Prepare(TParameter parameter);
    }
}
