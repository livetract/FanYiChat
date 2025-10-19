using QiaYue.UI.Services;
using QiaYue.UI.ViewModels;
using QiaYue.UI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using QiaYue.UI.Views.Components;

namespace QiaYue.UI
{
    public static class ExtensionServices
    {
        public static void ConfigureViews(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddScoped<DialogWindow>();

            services.AddScoped<AppConfigPage>();
        }
        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
            services.AddScoped<ConfigViewModel>();
        }

        public static void ConfigureCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITranslateService, BaiduTranslateService>();
            services.AddScoped<IConfigFileManager, ConfigFileManager>();
            services.AddScoped<IDialogManager, DialogManager>();
        }
        public static void AddFormFactory<TForm>(this IServiceCollection services)
            where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => x.GetRequiredService<TForm>);
        }
    }
}
