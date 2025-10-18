using FanYi.UI.Services;
using FanYi.UI.ViewModels;
using FanYi.UI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FanYi.UI
{
    public static class ExtensionServices
    {
        public static void ConfigureViews(this IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
        }
        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainViewModel>();
        }

        public static void ConfigureCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITranslateService, BaiduTranslateService>();
        }
        public static void AddFormFactory<TForm>(this IServiceCollection services)
            where TForm : class
        {
            services.AddTransient<TForm>();
            services.AddSingleton<Func<TForm>>(x => x.GetRequiredService<TForm>);
        }
    }
}
