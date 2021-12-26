using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Forms.TikTok.Models
{
    public class TikTokItem : ObservableObject
    {
        private string _username;
        private string _fullName;
        private string _description;
        private string _videoUrl;
        private string _likes;
        private string _comments;
        private string _song;
        private string _shares;
        private string _profileImage;
        private bool _isPlaying;

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

        public string Likes
        {
            get => _likes;
            set => _likes = value;
        }

        public string Comments
        {
            get => _comments;
            set => _comments = value;
        }

        public string Song
        {
            get => _song;
            set => _song = value;
        }

        public string Shares
        {
            get => _shares;
            set => _shares = value;
        }

        public string ProfileImage
        {
            get => _profileImage;
            set => _profileImage = value;
        }

        public bool IsPlaying
        {
            get => _isPlaying;
            set => SetProperty(ref _isPlaying, value);
        }
    }
}
