using System.Collections.Generic;
using LibVLCSharp.Shared;
using Xamarin.Forms.TikTok.Core.Models;

namespace Xamarin.Forms.TikTok.Core.Services.Media;

public interface IMediaService
{
    IEnumerable<TikTokItem> GetMediaItems();

    StreamMediaInput PrepareMedia(string media);
}