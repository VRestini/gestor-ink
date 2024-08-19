
using AppGestorInk.Services;
namespace AppGestorInk
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();
        
            MainPage = new AppShell();
        }
    }
}
