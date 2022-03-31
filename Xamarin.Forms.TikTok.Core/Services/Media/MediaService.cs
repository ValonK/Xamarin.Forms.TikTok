using System.Collections.Generic;
using Xamarin.Forms.TikTok.Core.Models;

namespace Xamarin.Forms.TikTok.Core.Services.Media;

public class MediaService : IMediaService
{
    public IEnumerable<TikTokItem> GetMediaItems()
    {
        return new List<TikTokItem>
        {
            new()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "tikvideo1.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "2100",
                ProfileImage = "profileImage.jpeg"
            },
            new()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "tikvideo2.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "1100",
                ProfileImage = "profileImage.jpeg"
            },
            new()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "tikvideo3.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "100",
                ProfileImage = "profileImage.jpeg"
            },
            new()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "tikvideo4.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "3100",
                ProfileImage = "profileImage.jpeg"
            },
            new()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "tikvideo5.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "5100",
                ProfileImage = "profileImage.jpeg"
            },
            new()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "tikvideo6.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "6100",
                ProfileImage = "profileImage.jpeg"
            }
        };
    }
}