using System;
using Demo.GitHub;
using Demo.Menu;
using Demo.BaseClasses;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;
using Demo.Services;

namespace Demo
{
    public partial class App : Application
    {
        protected static IServiceProvider ServiceProvider { get; set; }

        public static string GitHubUrl = "https://api.github.com";

        public App()
        {
            InitializeComponent();

            SetupServices();

            MainPage = new NavigationPage(new MenuPage());
        }

        void SetupServices()
        {
            var services = new ServiceCollection();

            //Add ViewModels
            services.AddTransient<MenuPageViewModel>();
            services.AddTransient<UserListPageViewModel>();

            //Core services
            services.AddSingleton<IGitHubService, GitHubService>();
            services.AddSingleton<IAlertService>(provider => new AlertService(this));

            ServiceProvider = services.BuildServiceProvider();
        }

        public static NotifyPropertyChanged GetViewModel<TViewModel>()
            where TViewModel : NotifyPropertyChanged => ServiceProvider.GetService<TViewModel>();

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
