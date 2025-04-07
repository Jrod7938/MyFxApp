using Microsoft.Extensions.Logging;
using MyFxApp.Services;
using MyFxApp.ViewModel;
using MyFxApp.Views;

namespace MyFxApp {
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                });

            
            // register api & storage
            builder.Services.AddSingleton<IMyFxBookApiService, MyFxBookApiService>();
            
            
            // register view models
            builder.Services.AddTransient<LoginViewModel>();
            
            
            // register views
            builder.Services.AddTransient<LoginPage>();

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
