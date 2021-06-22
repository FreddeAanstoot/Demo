using Demo.BaseClasses;
using Demo.Services;

namespace Demo.GitHub
{
    public class UserDetailsPageViewModel : NotifyPropertyChanged
    {

        private UserDetailViewModel userDetail;
        public UserDetailViewModel UserDetail
        {
            get => userDetail;
            set => SetValue(ref userDetail, value);
        }

        public UserDetailsPageViewModel(User user)
        {
            UserDetail = GetUserDetailViewModel(user);
        }

        private UserDetailViewModel GetUserDetailViewModel(User user)
        {
            return new UserDetailViewModel
            {
                Login = user.Login,
                Id = user.Id,
                NodeId = user.NodeId,
                AvatarUrl = user.AvatarUrl,
                GravatarId = user.GravatarId,
                Url = user.Url,
                HtmlUrl = user.HtmlUrl,
                FollowersUrl = user.FollowersUrl,
                FollowingUrl = user.FollowingUrl,
                GistsUrl = user.GistsUrl,
                StarredUrl = user.StarredUrl,
                SubscriptionsUrl = user.SubscriptionsUrl,
                OrganizationsUrl = user.OrganizationsUrl,
                ReposUrl = user.ReposUrl,
                EventsUrl = user.EventsUrl,
                ReceivedEventsUrl = user.ReceivedEventsUrl,
                Type = user.Type,
                SiteAdmin = user.SiteAdmin,
                Score = user.Score
            };
        }
    }
}
