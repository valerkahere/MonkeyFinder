using Microsoft.Extensions.Logging;
using MonkeyFinder.View;
using MonkeyFinder.Services;
using MonkeyFinder.ViewModel;


namespace MonkeyFinder
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

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<MainPage>();
            // addTransient means getting new instance each time
            builder.Services.AddSingleton<MonkeyService>();
            builder.Services.AddTransient<MonkeyViewModel>();

            return builder.Build();
        }
    }
}
