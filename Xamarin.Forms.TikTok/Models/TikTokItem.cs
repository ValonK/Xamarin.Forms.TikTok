using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.TikTok.Models
{
    public class TikTokItem
    {
        private string _username;
        private string _fullName;
        private string _description;
        private string _videoUrl;
        private int _likes;
        private int _followers;

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string FullName
        {
            get => _fullName;
            set => _fullName = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string VideoUrl
        {
            get => _videoUrl;
            set => _videoUrl = value;
        }

        public int Likes
        {
            get => _likes;
            set => _likes = value;
        }

        public int Followers
        {
            get => _followers;
            set => _followers = value;
        }
    }
}
