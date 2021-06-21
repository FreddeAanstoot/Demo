using System;
using System.Threading.Tasks;

namespace Demo.Services
{
    public interface IAlertService
    {
        Task<bool> ShowAlertAsync(string text, string title, string confirm, string cancel);
        Task ShowAlertWithOkAsync(string text, string title);
    }
}
