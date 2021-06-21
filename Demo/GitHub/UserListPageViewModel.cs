using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Demo.BaseClasses;
using Demo.Services;
using Demo.Utils;
using Xamarin.Forms;

namespace Demo.GitHub
{
    public class UserListPageViewModel : NotifyPropertyChanged
    {

        private readonly IGitHubService gitHubService;
        private readonly IAlertService alertService;

        public ExtendedObservableCollection<UserInfoViewModel> Users { get; internal set; }

        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    Users.Clear();
                    NoResultHeaderText = string.Empty;
                    NoResultText = string.Empty;
                }
                searchText = value;
            }
        }

        private string noResultText;
        public string NoResultText
        {
            get => noResultText;
            set => SetValue(ref noResultText, value);
        }

        private string noResultHeaderText;
        public string NoResultHeaderText
        {
            get => noResultHeaderText;
            set => SetValue(ref noResultHeaderText, value);
        }

        private bool showLoadingSpinner;
        public bool ShowLoadingSpinner
        {
            get => showLoadingSpinner;
            set => SetValue(ref showLoadingSpinner, value);
        }

        private UserInfoViewModel selectedUser;
        public UserInfoViewModel SelectedUser
        {
            get => selectedUser;
            set => SetValue(ref selectedUser, value);
        }

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            ShowLoadingSpinner = true;

            Users.Clear();

            try
            {
                var users = await gitHubService.SearchUsersAsync(query);
                Users.AddRange(users.Select(GetUserInfoViewModel));
            }
            catch
            {
                await alertService.ShowAlertWithOkAsync("Unable to retrieve data from GitHub", "");
            }

            ShowLoadingSpinner = false;

            if (!Users.Any())
            {
                NoResultHeaderText = "No users found.";
                NoResultText = "Please check the spelling or try again with another search term.";
            }
        });

        public UserListPageViewModel(IAlertService alertService, IGitHubService gitHubService)
        {
            this.gitHubService = gitHubService;
            this.alertService = alertService;
            Users = new ExtendedObservableCollection<UserInfoViewModel>();
        }

        private async Task ShowUser(UserInfoViewModel userInfoViewModel)
        {
            //TODO
        }

        private UserInfoViewModel GetUserInfoViewModel(User user)
        {
            return new UserInfoViewModel
            {
                Login = user.Login,
                AvatarUrl = user.AvatarUrl,
                Score = user.Score,
                Type = user.Type
            };
        }
    }
}
