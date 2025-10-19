using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QiaYue.UI.Options;
using QiaYue.UI.Services;
using QiaYue.UI.Views;
using System;
using System.IO;
using System.Windows;


namespace QiaYue.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // 先扫描一下程序是否有appsettings文件；
        public static IHost? AppHost { get; private set; }
        public static readonly string _ApplName = "QiaYue";
        public static readonly string _AppSettingsFileName = "settings.json";
        public static readonly string _AppSettingsBasePath = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),_ApplName);
        public static readonly string _AppSettingsFileFullPath = Path.Combine(_AppSettingsBasePath, _AppSettingsFileName);

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
            CheckFileAndCreate();
            var env = host.HostingEnvironment;
            builder.SetBasePath(_AppSettingsBasePath)
                .AddJsonFile(_AppSettingsFileName, true, true)
                .AddEnvironmentVariables();
        }

        private static void CheckFileAndCreate()
        {
            var fileManager = new ConfigFileManager();
            if(!fileManager.CheckDirectory(_AppSettingsBasePath))
            {
                fileManager.CreateDirectory(_AppSettingsBasePath);
            }
            var r3 = fileManager.CheckFile(_AppSettingsFileFullPath);
            if (!r3)
            {
                fileManager.CreateFile(_AppSettingsFileFullPath, new ConfigModel());
            }
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
