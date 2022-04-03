namespace Xamarin.Forms.TikTok.Core.Models;

public class TikTokItem : ObservableObject
{
    private bool _isPlaying;

    public string Id { get; set; }

    public string Username { get; set; }

    public string FullName { get; set; }

    public string Description { get; set; }

    public string VideoUrl { get; set; }

    public string Likes { get; set; }

    public string Comments { get; set; }

    public string Song { get; set; }

    public string Shares { get; set; }

    public string ProfileImage { get; set; }

    public bool IsPlaying
    {
        get => _isPlaying;
        set => SetProperty(ref _isPlaying, value);
    }
}