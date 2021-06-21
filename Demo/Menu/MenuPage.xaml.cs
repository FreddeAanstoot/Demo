using Xamarin.Forms;

namespace Demo.Menu
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = App.GetViewModel<MenuPageViewModel>();
        }
    }
}
