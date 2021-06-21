using System;
using Demo.BaseClasses;

namespace Demo.GitHub
{
    public class UserInfoViewModel : NotifyPropertyChanged
    {
        public string Login { get; set; }

        public string AvatarUrl { get; set; }

        public double Score { get; set; }

        public string Type { get; set; }

        public UserInfoViewModel()
        {
        }

        public string ScoreText
        {
            get => $"Score {Score}";
        }
    }
}
