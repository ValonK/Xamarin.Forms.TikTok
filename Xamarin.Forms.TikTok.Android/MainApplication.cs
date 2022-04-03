using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.CurrentActivity;

namespace Xamarin.Forms.TikTok.Droid;

//Do not delete thise file! It was here because plugins depend on it. 
//If you have an existing Application class you can merte the two together
//if you have existing assembly:Application, you can remove them.
public partial class MainApplication : global::Android.App.Application, global::Android.App.Application.IActivityLifecycleCallbacks
{
	public MainApplication(IntPtr handle, JniHandleOwnership transer)
		: base(handle, transer)
	{
	}

	public override void OnCreate()
	{
		base.OnCreate();
		RegisterActivityLifecycleCallbacks(this);
	}

	public override void OnTerminate()
	{
		base.OnTerminate();
		UnregisterActivityLifecycleCallbacks(this);
	}

	public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
	{
		CrossCurrentActivity.Current.Activity = activity;
	}

	public void OnActivityDestroyed(Activity activity)
	{
	}

	public void OnActivityPaused(Activity activity)
	{
	}

	public void OnActivityResumed(Activity activity)
	{
		CrossCurrentActivity.Current.Activity = activity;
	}

	public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
	{
	}

	public void OnActivityStarted(Activity activity)
	{
		CrossCurrentActivity.Current.Activity = activity;
	}

	public void OnActivityStopped(Activity activity)
	{
	}
}