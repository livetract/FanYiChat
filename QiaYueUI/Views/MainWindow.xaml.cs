using QiaYue.UI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace QiaYue.UI.Views
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
