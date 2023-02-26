using FingerprintScannerHelper.ViewModels;
using System.Windows;

namespace FingerprintScannerHelper
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
