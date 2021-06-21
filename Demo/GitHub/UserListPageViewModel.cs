using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Demo.BaseClasses;
using Demo.Utils;
using Xamarin.Forms;

namespace Demo.GitHub
{
    public class UserListPageViewModel : NotifyPropertyChanged
    {

        private readonly IGitHubService gitHubService;

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

        private bool showLoadingSpinner;
        public bool ShowLoadingSpinner
        {
            get => showLoadingSpinner;
            set => SetValue(ref showLoadingSpinner, value);
        }

        public ICommand PerformSearch => new Command<string>(async (string query) =>
        {
            ShowLoadingSpinner = true;

            Users.Clear();
            await Task.Delay(2000);

            var users = gitHubService.GetUsers(query).Select(GetUserInfoViewModel);

            Users.AddRange(users);

            ShowLoadingSpinner = false;
        });

        public UserListPageViewModel(IGitHubService gitHubService)
        {
            this.gitHubService = gitHubService;
            Users = new ExtendedObservableCollection<UserInfoViewModel>();
        }

        private UserInfoViewModel GetUserInfoViewModel(User user)
        {
            return new UserInfoViewModel
            {
                Login = user.Login
            };
        }
    }
}
