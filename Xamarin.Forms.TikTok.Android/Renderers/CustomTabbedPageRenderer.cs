using Android.Content;
using Android.Graphics;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Internal;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.TikTok.Droid.Renderers;
using Xamarin.Forms.TikTok.Views;
using BottomNavigationView = Google.Android.Material.BottomNavigation.BottomNavigationView;

[assembly: ExportRenderer(typeof(MvxTabbedPage), typeof(CustomTabbedPageRenderer))]
namespace Xamarin.Forms.TikTok.Droid.Renderers
{
    public class CustomTabbedPageRenderer : TabbedPageRenderer
    {
        private BottomNavigationView _bottomNavigationView;

        public CustomTabbedPageRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            _bottomNavigationView = (GetChildAt(0) as global::Android.Widget.RelativeLayout)?.GetChildAt(1) as BottomNavigationView;
            ChangeFont(Color.White);

            MessagingCenter.Subscribe<MainView, Color>(this, "TabColor", OnTabColorChanged);
        }

        private void OnTabColorChanged(MainView arg1, Color color)
        {
            ChangeFont(color);
        }

        private void ChangeFont(Color color)
        {
            if (Context != null)
            {
                var fontFace = Typeface.CreateFromAsset(Context.Assets, "tiktokfont.ttf");

                if (_bottomNavigationView.GetChildAt(0) is not BottomNavigationMenuView bottomNavMenuView)
                {
                    return;
                }

                for (var i = 0; i < bottomNavMenuView.ChildCount; i++)
                {
                    var item = bottomNavMenuView.GetChildAt(i) as BottomNavigationItemView;
                    var itemTitle = item?.GetChildAt(1);

                    var smallTextView = ((TextView)((BaselineLayout)itemTitle)?.GetChildAt(0));
                    var largeTextView = ((TextView)((BaselineLayout)itemTitle)?.GetChildAt(1));
                    smallTextView?.SetTextColor(color.ToAndroid());
                    largeTextView?.SetTextColor(color.ToAndroid());
                    smallTextView?.SetHintTextColor(color.ToAndroid());
                    largeTextView?.SetHintTextColor(color.ToAndroid());
                    smallTextView?.SetTypeface(fontFace, TypefaceStyle.Normal);
                    largeTextView?.SetTypeface(fontFace, TypefaceStyle.Normal);
                }
            }
        }
    }
}