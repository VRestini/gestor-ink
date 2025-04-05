using GestorInk.Page.ProductPage;
using GestorInk.Page.StockProductPage;

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
            Routing.RegisterRoute(nameof(StockProductFeed), typeof(StockProductFeed));
            Routing.RegisterRoute(nameof(StockProductCreate), typeof(StockProductCreate));
        }
        protected void RegisterForRoute<T>()
        {
            Routing.RegisterRoute(typeof(T).Name, typeof(T));
        }
    }
}
