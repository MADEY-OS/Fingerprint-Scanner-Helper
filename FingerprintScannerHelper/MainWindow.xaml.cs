using FingerprintScannerHelper.Components.Windows;
using System.Windows;

namespace FingerprintScannerHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Arduino_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ArduinoSetupWindow arduinoSetupWindow = new ArduinoSetupWindow();
            arduinoSetupWindow.Show();
        }
        private void Help_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.Show();
        }
    }
}
