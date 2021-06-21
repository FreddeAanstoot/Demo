using System;
using Demo.BaseClasses;
using System.Windows.Input;
using Xamarin.Forms;
using Demo.GitHub;

namespace Demo.Menu
{
    public class MenuPageViewModel : NotifyPropertyChanged
    {
        public ICommand GitHubUsersCommand { get; }

        public MenuPageViewModel(IGitHubService gitHubService)
        {
            GitHubUsersCommand = new Command(async () =>
            {
                var userListPageViewModel = new UserListPageViewModel(gitHubService);

                var userListPage = new UserListPage();

                userListPage.BindingContext = userListPageViewModel;

                await Application.Current.MainPage.Navigation.PushAsync(userListPage);
            });

        }
    }
}
