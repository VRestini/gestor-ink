using CommunityToolkit.Maui;
using GestorInk.Models;
using GestorInk.Page.FinancialPage;
using GestorInk.Page.ProductPage;
using GestorInk.Page.SchedulerPage;
using GestorInk.Page.StockProductPage;
using GestorInk.Repositorys;
using GestorInk.Services;
using GestorInk.ViewModel.ViewModelProduct;
using GestorInk.ViewModel.ViewModelScheduler;
using GestorInk.ViewModel.ViewModelStockProduct;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;
using System.Diagnostics;
using System.Reflection;

namespace GestorInk
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Configuração dos UserSecrets (modificado)
            var configuration = new ConfigurationBuilder()
                .AddUserSecrets(Assembly.GetExecutingAssembly())
                .Build();

            var syncfusionKey = configuration["Syncfusion:LicenseKey"];
            if (!string.IsNullOrEmpty(syncfusionKey))
            {
                SyncfusionLicenseProvider.RegisterLicense(syncfusionKey);
            }

            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Inter28pt-SemiBold.ttf", "InterSemiBold");
                    fonts.AddFont("Inter18pt-Light.ttf", "InterLight");
                    fonts.AddFont("Lobster-Regular.ttf", "Lobster");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            // Configuração de serviços
            builder.Services.AddTransient<IProductService, ProductRepository>();
            builder.Services.AddTransient<ISessionService, SessionRepository>();
            builder.Services.AddTransient<IStockProductService, StockProductRepository>();
            builder.Services.AddTransient<IUserService, UserRepository>();

            // ViewModels
            builder.Services.AddTransient<ProductFeedVM>();
            builder.Services.AddTransient<ProductCreateVM>();
            builder.Services.AddTransient<ProductEditorVM>();
            builder.Services.AddTransient<StockProductCreateVM>();
            builder.Services.AddTransient<StockProductFeedVM>();
            builder.Services.AddTransient<SchedulerCreatorVM>();
            builder.Services.AddTransient<SchedulerFeedVM>();
            builder.Services.AddTransient<SchedulerEditorVM>();

            // Pages
            builder.Services.AddTransient<ProductFeed>();
            builder.Services.AddTransient<ProductEditor>();
            builder.Services.AddTransient<ProductCreate>();
            builder.Services.AddTransient<SchedulerFeed>();
            builder.Services.AddTransient<SchedulerEditor>();
            builder.Services.AddTransient<SchedulerCreate>();
            builder.Services.AddTransient<StockProductFeed>();
            builder.Services.AddTransient<StockProductCreate>();
            builder.Services.AddTransient<FinancialFeed>();

            // Handlers
            builder.ConfigureMauiHandlers(handlers =>
            {
                handlers.AddHandler<SearchBarWithout, Microsoft.Maui.Handlers.SearchBarHandler>();

                Microsoft.Maui.Handlers.SearchBarHandler.Mapper.AppendToMapping(nameof(SearchBarWithout), (handler, view) =>
                {
#if __ANDROID__
                    handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                    handler.PlatformView.Background = null;
#elif __IOS__
                    handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                    handler.PlatformView.SearchBarStyle = UIKit.UISearchBarStyle.Minimal;
                    handler.PlatformView.BarTintColor = UIKit.UIColor.Clear;
#endif
                });
            });

            // Lifecycle Events
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