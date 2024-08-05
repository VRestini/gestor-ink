using AppGestorInk.MVVM.Popups;
using AppGestorInk.MVVM.Views;
namespace AppGestorInk
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterForRoute<AddProdutoPop>();
            RegisterForRoute<EditarProduto>();
            RegisterForRoute<Estoque>();
        }
        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}
