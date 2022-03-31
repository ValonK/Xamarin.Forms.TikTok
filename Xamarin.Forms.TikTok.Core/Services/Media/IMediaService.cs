using System.Collections.Generic;
using Xamarin.Forms.TikTok.Core.Models;

namespace Xamarin.Forms.TikTok.Core.Services.Media;

public interface IMediaService
{
    IEnumerable<TikTokItem> GetMediaItems();
}