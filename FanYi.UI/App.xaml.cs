using FanYi.UI.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using FanYi.UI.Models;
using FanYi.UI.Options;


namespace FanYi.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration(ConfigureAppConfigurations)
                .ConfigureServices(ConfigureAppServices)
                .Build();

            AppHost.RunAsync();
        }

        private static void ConfigureAppConfigurations(HostBuilderContext host, IConfigurationBuilder builder)
        {
            //throw new NotImplementedException();
            var env = host.HostingEnvironment;
            builder.AddJsonFile(env.IsDevelopment()
                    ? "appsettings.{env.EnvironmentName}.json"
                    : "appsettings.json",
                true, true);
        }

        private static void ConfigureAppServices(HostBuilderContext context, IServiceCollection services)
        {
            services.Configure<BaiduTranslateApi>(context.Configuration.GetSection("BaiduTranslateApi"));
            services.AddHttpClient(
                nameof(BaiduTranslateApi),
                client =>
                {
                    client.Timeout = TimeSpan.FromSeconds(10);
                    client.DefaultRequestHeaders.UserAgent.ParseAdd("TranslationByBaidu");//不能使用中文写？？？
                });

            services.ConfigureViews();
            services.ConfigureViewModels();
            services.ConfigureCustomServices(context.Configuration);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var start = AppHost!.Services.GetRequiredService<MainWindow>();
            start.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();
            base.OnExit(e);
        }

    }

}
