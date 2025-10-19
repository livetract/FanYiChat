using Microsoft.Extensions.DependencyInjection;
using QiaYue.UI.ViewModels;
using System.Windows.Controls;

namespace QiaYue.UI.Views.Components
{
    /// <summary>
    /// AppConfigPage.xaml 的交互逻辑
    /// </summary>
    public partial class AppConfigPage : UserControl
    {
        public AppConfigPage()
        {
            this.DataContext = App.AppHost!.Services.GetRequiredService<ConfigViewModel>();
            InitializeComponent();
        }
    }
}
