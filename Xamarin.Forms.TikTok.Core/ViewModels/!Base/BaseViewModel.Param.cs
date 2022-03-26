using MvvmCross.ViewModels;

namespace Xamarin.Forms.TikTok.Core.ViewModels._Base
{
    public abstract class BaseViewModel<TParameter> : BaseViewModel, IMvxViewModel<TParameter>
    {
        public abstract void Prepare(TParameter parameter);
    }
}
