
using AppGestorInk.Services;
namespace AppGestorInk
{
    public partial class App : Application
    {
        public static ProdutoService ProdutoServiceBD { get; set; }
        public App()
        {
            InitializeComponent();
            ProdutoServiceBD = new ProdutoService();
            MainPage = new AppShell();
        }
    }
}
