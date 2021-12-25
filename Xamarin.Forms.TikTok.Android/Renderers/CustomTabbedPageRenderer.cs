using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Google.Android.Material.BottomNavigation;
using Google.Android.Material.Internal;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.TikTok.Droid.Renderers;
using BottomNavigationView = Google.Android.Material.BottomNavigation.BottomNavigationView;

[assembly: ExportRenderer(typeof(TabbedPage), typeof(CustomTabbedPageRenderer))]
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
            ChangeFont();
        }

        private void ChangeFont()
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
                    smallTextView?.SetTextColor(global::Android.Graphics.Color.White);
                    largeTextView?.SetTextColor(global::Android.Graphics.Color.White);
                    smallTextView?.SetHintTextColor(global::Android.Graphics.Color.White);
                    largeTextView?.SetHintTextColor(global::Android.Graphics.Color.White);
                    smallTextView?.SetTypeface(fontFace, TypefaceStyle.Normal);
                    largeTextView?.SetTypeface(fontFace, TypefaceStyle.Normal);
                }
            }
        }
    }
}