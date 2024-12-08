using AppGestorInk.MVVM.Popups;
using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.MVVM.Views;
using AppGestorInk.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;

namespace AppGestorInk
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
                    fonts.AddFont("Inter28pt-SemiBold.ttf", "InterSemiBold");
                    fonts.AddFont("Inter18pt-Light.ttf", "InterLight");
                    fonts.AddFont("Lobster-Regular.ttf", "Lobster");
                });
            SyncfusionLicenseProvider.RegisterLicense("MzUwODIxNEAzMjM3MmUzMDJlMzBubWlpZFY2cnYzUmhFTzk2Sk4ycmtLL3FqZnlZZ1dSeDdNZm9sZ2wyZVlFPQ==");
#if DEBUG
            builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<EstoqueViewModel>();
            builder.Services.AddTransient<AddProdutoViewModel>();
            builder.Services.AddTransient<EditarProdutoViewModel>();
            builder.Services.AddTransient<RelatorioEstoqueViewModel>();
            builder.Services.AddTransient<AddItemViewModel>();
            builder.Services.AddTransient<AgendaViewModel>();
            builder.Services.AddTransient<AddSessaoViewModel>();
            builder.Services.AddTransient<EditarSessaoViewModel>();
            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddSingleton<Estoque>();
            builder.Services.AddTransient<AddItemPop>();
            builder.Services.AddTransient<AddProdutoPop>();
            builder.Services.AddTransient<EditarProduto>();
            builder.Services.AddTransient<EstoqueRelatorio>();
            builder.Services.AddTransient<Agenda>();
            builder.Services.AddTransient<AddSessaoView>();
            builder.Services.AddTransient<EditarSessaoView>();
            builder.Services.AddTransient<Home>();
           

            builder.Services.AddSingleton<IProdutoService, ProdutoService>();
            builder.Services.AddSingleton<IServiceItem, ItemService>();
            builder.Services.AddSingleton<ISessaoService, SessaoService>();
            return builder.Build();
        }
    }
}
