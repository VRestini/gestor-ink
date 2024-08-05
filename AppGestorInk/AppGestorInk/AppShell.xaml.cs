using AppGestorInk.MVVM.Popups;
namespace AppGestorInk
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterForRoute<AddProdutoPop>();
            RegisterForRoute<EditarProduto>();
            
        }
        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}
