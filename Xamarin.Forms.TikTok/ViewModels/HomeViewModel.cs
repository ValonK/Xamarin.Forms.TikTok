using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PanCardView.EventArgs;
using Xamarin.Forms.TikTok.Models;

namespace Xamarin.Forms.TikTok.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Fields

        private ObservableCollection<TikTokItem> _items;
        private TikTokItem _currentItem;
        #endregion

        public HomeViewModel()
        {
            ItemAppearingCommand = new Command<object>(OnItemAppearing);
            ItemDisappearingCommand = new Command<object>(OnItemDisapearing);
        }

        #region Properties

        public ObservableCollection<TikTokItem> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public TikTokItem CurrentItem
        {
            get => _currentItem;
            set => SetProperty(ref _currentItem, value);
        }
        #endregion

        #region Commands

        public Command<object> ItemAppearingCommand { get; set; }

        public Command<object> ItemDisappearingCommand { get; set; }
        #endregion

        #region Appearing / Disappearing

        public async void Appearing()
        {
            IsBusy = true;

            CurrentItem = new TikTokItem()
            {
                Username = "@shanselman",
                FullName = "Scott Hanselman",
                VideoUrl = "ms-appx:///tikvideo2.mp4",
                Song = "Some music artist Artist - Music",
                Comments = "10.6K",
                Likes = "5.9K",
                Shares = "2100",
                ProfileImage = "profileImage.jpeg"
            };
            await Task.Delay(2500);

            CreateItems();

            IsBusy = false;
        }

        private void OnItemDisapearing(object obj)
        {
            if (obj is ItemDisappearingEventArgs itemDisappearingEventArgs)
            {
                if (itemDisappearingEventArgs.Item is TikTokItem item)
                {
                    item.IsPlaying = false;
                }
            }
        }

        public void Disappearing()
        {
            Items?.Clear();
        }

        private void OnItemAppearing(object obj)
        {
            if (obj is ItemAppearingEventArgs itemAppearedEventArgs)
            {
                if (itemAppearedEventArgs.Item is TikTokItem item)
                {
                    item.IsPlaying = true;
                }
            }
        }
        #endregion

        #region Create Items

        private void CreateItems()
        {
            Items = new ObservableCollection<TikTokItem>
            {
                new()
                {
                    Username = "@shanselman",
                    FullName = "Scott Hanselman",
                    VideoUrl = "ms-appx:///tikvideo1.mp4",
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
                    VideoUrl = "ms-appx:///tikvideo2.mp4",
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
                    VideoUrl = "ms-appx:///tikvideo3.mp4",
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
                    VideoUrl = "ms-appx:///tikvideo4.mp4",
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
                    VideoUrl = "ms-appx:///tikvideo5.mp4",
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
                    VideoUrl = "ms-appx:///tikvideo6.mp4",
                    Song = "Some music artist Artist - Music",
                    Comments = "10.6K",
                    Likes = "5.9K",
                    Shares = "6100",
                    ProfileImage = "profileImage.jpeg"
                }
            };

            CurrentItem = Items[0];
        } 
        #endregion
    }
}

//VideoUrl = "https://v16-webapp.tiktok.com/de3e85059c5103b4435419b55cdb231b/61c75451/video/tos/useast2a/tos-useast2a-ve-0068c001/07ad886076b24a38bf6cff508e5a5244/?a=1988&br=2372&bt=1186&cd=0%7C0%7C1&ch=0&cr=0&cs=0&cv=1&dr=0&ds=3&er=&ft=Yu12_FIQkag3-I&l=2021122511261601022309816117B99238&lr=tiktok_m&mime_type=video_mp4&net=0&pl=0&qs=0&rc=ajppdDM6ZndzNzMzNzczM0ApODgzZzZnOmQ7NzkzNWllM2dyaXJpcjRvNl5gLS1kMTZzc2MuYzMyMWE2YF40MGAzYS86Yw%3D%3D&vl=&vr=",
//VideoUrl = "https://v16-webapp.tiktok.com/2b06c0dc1a871aad76a81b6b89ebe181/61c75475/video/tos/useast2a/tos-useast2a-pve-0068/2524e2200be54d57a6a0bf6994a771a6/?a=1988&br=1834&bt=917&cd=0%7C0%7C1&ch=0&cr=0&cs=0&cv=1&dr=0&ds=3&er=&ft=Yu12_FIQkag3-I&l=202112251125440102230771540EB60F0F&lr=tiktok_m&mime_type=video_mp4&net=0&pl=0&qs=0&rc=ajZpczM6ZjU4NzMzNzczM0ApOGg3PGRnNzw8N2ZmNjw3aGdxYi5zcjRvM29gLS1kMTZzc2EvMWAzNl4yLjJhYjJjMC06Yw%3D%3D&vl=&vr="
//VideoUrl = "https://v16-webapp.tiktok.com/c65a0ab474bb10ee25bc570949b93390/61c753ed/video/tos/useast2a/tos-useast2a-ve-0068c004/6b32913ab10a4d19818f35811fee0e81/?a=1988&br=2930&bt=1465&cd=0%7C0%7C1&ch=0&cr=0&cs=0&cv=1&dr=0&ds=3&er=&ft=Yu12_FIQkag3-I&l=2021122511245101022309914019B830C6&lr=tiktok_m&mime_type=video_mp4&net=0&pl=0&qs=0&rc=M3hqOjY6ZjdwODMzNzczM0ApPGZoZjQ3aGRoNzZoPGk8PGduNHIvcjRvYmtgLS1kMTZzczEwMy0vYWBiMTAvMDY2NWA6Yw%3D%3D&vl=&vr="
//VideoUrl = "https://v16-webapp.tiktok.com/e0907e77cbeeffa3ac78f2d0524925bb/61c753e6/video/tos/useast5/tos-useast5-ve-0068c001-tx/f135081c6276439eb6c25f0f68d875ef/?a=1988&br=3272&bt=1636&cd=0%7C0%7C1&ch=0&cr=0&cs=0&cv=1&dr=0&ds=3&er=&ft=Yu12_FIQkag3-I&l=2021122511242201022309815618B80551&lr=tiktok_m&mime_type=video_mp4&net=0&pl=0&qs=0&rc=amc6bDc6ZnhsOTMzZzczNEApOWY2NWk7N2Q5N2g4PDY5aWduZGpycjRnYWxgLS1kMS9zczAyYjNiXzBfXi40MWNiMDY6Yw%3D%3D&vl=&vr="
//VideoUrl = "https://v16-webapp.tiktok.com/1c175f64b90a3d2af61840e7844e4aef/61c753d9/video/tos/useast5/tos-useast5-pve-0068-tx/c13dbf4434b2401a8256291a6a2f9def/?a=1988&br=2002&bt=1001&cd=0%7C0%7C1&ch=0&cr=0&cs=0&cv=1&dr=0&ds=3&er=&ft=Yu12_FIQkag3-I&l=2021122511234401019216806600B8FFAD&lr=tiktok_m&mime_type=video_mp4&net=0&pl=0&qs=0&rc=M2pxajQ6ZnI2OTMzZzczNEApPDQ5Zjk3ZWVoNzZpaWRnPGcxXjVfcjRvMG5gLS1kMS9zczQvYmJeLl42NTNiLy0xMi46Yw%3D%3D&vl=&vr="
//VideoUrl = "https://v16-webapp.tiktok.com/9216302beb7202fb3bfe4452de3482ed/61c7538f/video/tos/useast2a/tos-useast2a-ve-0068c003/466430ee63864be3a0f65d8cfed80a99/?a=1988&br=2360&bt=1180&cd=0|0|1&ch=0&cr=0&cs=0&cv=1&dr=0&ds=3&er=&ft=Yu12_FIQkag3-I&l=2021122511222801022307813818B88A0E&lr=tiktok_m&mime_type=video_mp4&net=0&pl=0&qs=0&rc=ajRuZ2xrc3Y7MzMzNTczM0ApPDk7OTU8aWQ1NzQ2aDppN2dqXmVsbGRlb3BgLS00MTZzc15jX2EvMjMwMl4zX142Yi86Yw==&vl=&vr="
