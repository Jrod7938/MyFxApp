using Microcharts.Maui;
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
                .UseMicrocharts()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                });

            
            // register api & storage
            builder.Services.AddSingleton<IMyFxBookApiService, MyFxBookApiService>();
            builder.Services.AddSingleton<ILocalStorageService, LocalStorageService>();

            // register view models
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<AccountsViewModel>();
            builder.Services.AddTransient<AccountDetailViewModel>();

            // register views
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<AccountsPage>();
            builder.Services.AddTransient<AccountDetailPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
