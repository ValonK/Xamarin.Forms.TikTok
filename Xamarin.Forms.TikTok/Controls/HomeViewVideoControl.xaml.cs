using System;
using System.Diagnostics;
using System.Reflection;
using LibVLCSharp.Shared;
using Xamarin.Essentials;
using Xamarin.Forms.Xaml;

namespace Xamarin.Forms.TikTok.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeViewVideoControl
    {
        public HomeViewVideoControl()
        {
            InitializeComponent();
        }
        
        public static readonly BindableProperty MediaPlayerProperty =
            BindableProperty.Create(nameof(MediaPlayer), typeof(bool),
                typeof(HomeViewVideoControl), null);
        
        public MediaPlayer MediaPlayer
        {
            get => (MediaPlayer)GetValue(MediaPlayerProperty);
            set => SetValue(MediaPlayerProperty, value);
        }
        
        public static readonly BindableProperty PositionProperty =
            BindableProperty.Create(nameof(Position), typeof(double),
                typeof(HomeViewVideoControl));
        
        public double Position
        {
            get => (double)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
        
        public static readonly BindableProperty PositionVisibleProperty =
            BindableProperty.Create(nameof(PositionVisible), typeof(bool),
                typeof(HomeViewVideoControl));
        
        public bool PositionVisible
        {
            get => (bool)GetValue(PositionProperty);
            set => SetValue(PositionProperty, value);
        }
    }
}