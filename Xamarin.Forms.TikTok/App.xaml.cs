using LibVLCSharp.Shared;

namespace Xamarin.Forms.TikTok;

public partial class App
{
    public static LibVLC LibVLC;
 
    public App()
    {
        InitializeComponent();

        LibVLCSharp.Shared.Core.Initialize();
    }
}