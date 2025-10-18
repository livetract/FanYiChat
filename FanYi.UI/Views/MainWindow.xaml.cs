using FanYi.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FanYi.UI.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.DataContext = App.AppHost!.Services.GetRequiredService<MainViewModel>();
            InitializeComponent();
        }
    }
}
