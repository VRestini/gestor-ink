using GestorInk.Page.ProductPage;

namespace GestorInk
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductCreate), typeof(ProductCreate));
            Routing.RegisterRoute(nameof(ProductEditor), typeof(ProductEditor));
            Routing.RegisterRoute(nameof(ProductFeed), typeof(ProductFeed));
        }
        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}
