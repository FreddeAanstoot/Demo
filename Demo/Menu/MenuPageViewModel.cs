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

        public MenuPageViewModel()
        {
            GitHubUsersCommand = new Command(async () =>
            {
                //Basic navigation
                //TODO: Write a navigation service
                var userListPageViewModel = new UserListPageViewModel();

                var userListPage = new UserListPage();

                userListPage.BindingContext = userListPageViewModel;

                await Application.Current.MainPage.Navigation.PushAsync(userListPage);
            });

        }
    }
}
