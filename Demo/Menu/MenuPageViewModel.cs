using System;
using Demo.BaseClasses;
using System.Windows.Input;
using Xamarin.Forms;
using Demo.GitHub;
using Demo.Services;

namespace Demo.Menu
{
    public class MenuPageViewModel : NotifyPropertyChanged
    {
        public ICommand GitHubUsersCommand { get; }

        public MenuPageViewModel(IAlertService alertService, IGitHubService gitHubService)
        {
            GitHubUsersCommand = new Command(async () =>
            {
                var userListPageViewModel = new UserListPageViewModel(alertService, gitHubService);

                var userListPage = new UserListPage();

                userListPage.BindingContext = userListPageViewModel;

                await Application.Current.MainPage.Navigation.PushAsync(userListPage);
            });

        }
    }
}
