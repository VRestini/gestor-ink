using AppGestorInk.MVVM.Models;
using AppGestorInk.Services;
namespace AppGestorInk
{
    public partial class App : Application
    {
        
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCd0x0Q3xbf1x0ZFFMYFtbQXJPIiBoS35RckVqWHZfdnRSQ2ReVkxw");

            InitializeComponent();
        
            MainPage = new AppShell();
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(EntryWithoutBorder), (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif

            });
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping(nameof(EditorWithoutBorder), (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
               
#endif

            });
        }
    }
}
