using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo.Services
{
    public class AlertService : IAlertService
    {
        readonly Lazy<Page> _rootPage;

        public AlertService(Application application)
        {
            _rootPage = new Lazy<Page>(() => application.MainPage);
        }

        public async Task<bool> ShowAlertAsync(string text, string title, string confirm, string cancel)
        {
            return await _rootPage.Value.DisplayAlert(title, text, confirm, cancel);
        }

        public async Task ShowAlertWithOkAsync(string text, string title)
        {
            await _rootPage.Value.DisplayAlert(title, text, "OK");
        }
    }
}