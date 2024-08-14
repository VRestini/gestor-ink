using AppGestorInk.MVVM.Popups;
using AppGestorInk.MVVM.ViewModels;
using AppGestorInk.MVVM.Views;
using AppGestorInk.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Inter28pt-SemiBold.tff", "InterSemiBold");
                    fonts.AddFont("Inter18pt-Light.tff", "InterLight");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<EstoqueViewModel>();
            builder.Services.AddTransient<AddProdutoViewModel>();
            builder.Services.AddTransient<EditarProdutoViewModel>();

            builder.Services.AddSingleton<Estoque>();
            builder.Services.AddTransient<AddProdutoPop>();
            builder.Services.AddTransient<EditarProduto>();

            builder.Services.AddSingleton<IProdutoService, ProdutoService>();
            return builder.Build();
        }
    }
}
