using System.Collections.Generic;
using Xamarin.Forms.TikTok.Models;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiscoverItemControl : ContentView
    {
        public DiscoverItemControl()
        {
            InitializeComponent();
        }

        #region Subtitle
        
        public string Subtitle
        {
            get => (string)GetValue(SubtitleProperty);
            set => SetValue(SubtitleProperty, value);
        }

        public static readonly BindableProperty SubtitleProperty =
            BindableProperty.Create(nameof(Subtitle), typeof(string),
                typeof(DiscoverItemControl));
        #endregion

        #region Title

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(nameof(Title), typeof(string),
                typeof(DiscoverItemControl));
        #endregion

        #region Items
        
        public static readonly BindableProperty ItemsProperty =
            BindableProperty.Create(nameof(Items), typeof(IList<DiscoverItem>), typeof(DiscoverItemControl));

        public IList<DiscoverItem> Items
        {
            get => (IList<DiscoverItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        } 
        #endregion
    }
}