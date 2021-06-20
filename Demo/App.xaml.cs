using System;
using Demo.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //Basic navigation
            //TODO: Write a navigation service
            MainPage = new NavigationPage(new MenuPage());
        }

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
