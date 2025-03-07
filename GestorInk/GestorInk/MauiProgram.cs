using CommunityToolkit.Maui;
using GestorInk.Page.FinancialPage;
using GestorInk.Page.ProductPage;
using GestorInk.Page.SchedulerPage;
using GestorInk.Page.StockProductPage;
using GestorInk.Repositorys;
using GestorInk.Services;
using GestorInk.ViewModel.ViewModelProduct;
using GestorInk.ViewModel.ViewModelScheduler;
using GestorInk.ViewModel.ViewModelStockProduct;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;

namespace GestorInk
{
    public static class MauiProgram
    {
        
        public static MauiApp CreateMauiApp()
        {
            
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            SyncfusionLicenseProvider.RegisterLicense("CHAVE SYNCFUSION");
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddTransient<IProductService, ProductRepository>();
            builder.Services.AddTransient<ISessionService, SessionRepository>();
            builder.Services.AddTransient<IStockProductService, StockProductRepository>();
            builder.Services.AddTransient<IUserService, UserRepository>();

            builder.Services.AddTransient<ProductFeedVM>();
            builder.Services.AddTransient<ProductCreateVM>();
            builder.Services.AddTransient<ProductEditorVM>();
            builder.Services.AddTransient<StockProductEditorVM>();
            builder.Services.AddTransient<StockProductCreateVM>();
            builder.Services.AddTransient<StockProductFeedVM>();
            builder.Services.AddTransient<SchedulerCreatorVM>();
            builder.Services.AddTransient<SchedulerFeedVM>();
            builder.Services.AddTransient<SchedulerEditorVM>();

            builder.Services.AddTransient<ProductFeed>();
            builder.Services.AddTransient<ProductEditor>();
            builder.Services.AddTransient<ProductCreate>();
            builder.Services.AddTransient<SchedulerFeed>();
            builder.Services.AddTransient<SchedulerEditor>();
            builder.Services.AddTransient<SchedulerCreate>();
            builder.Services.AddTransient<StockProductFeed>();
            builder.Services.AddTransient<StockProductEditor>();
            builder.Services.AddTransient<StockProductCreate>();
            builder.Services.AddTransient<FinancialFeed>();
            builder.ConfigureLifecycleEvents(events =>
            {
#if ANDROID
    events.AddAndroid(android => android.OnCreate((activity, bundle) =>
    {
        
        activity.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#101010")); 
    }));
#endif
            });


            return builder.Build();
        }
    }
}
