using MAUIFoodApplication.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace MAUIFoodApplication
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if ANDROID
        builder.Services.AddSingleton<IDeviceService, MAUIFoodApplication.Platforms.Android.DeviceService>();
#elif WINDOWS        
            builder.Services.AddSingleton<IDeviceService, MAUIFoodApplication.Platforms.Windows.DeviceService>();
#endif
            builder.Services.AddTransient<MainPage>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
