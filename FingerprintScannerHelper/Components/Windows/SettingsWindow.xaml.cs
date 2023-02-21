using FingerprintScannerHelper.Interfaces;
using FingerprintScannerHelper.Services;
using System;
using System.Windows;

namespace FingerprintScannerHelper.Components.Windows
{
    public partial class SettingsWindow : Window
    {
        private readonly ISharedServices _shared = new SharedServices();
        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public SettingsWindow()
        {
            InitializeComponent();
            Loaded += ToolWindow_Loaded;

            var config = _shared.GetConfiguration();
            tbSrc.Text = config.SourcePath;
            tbDest.Text = config.DestinationPath;
            tbArduinoPort.Text = config.ArduinoPort;
            tbArduinoBaud.Text = config.ArduinoBaud;
            tbPerson.Text = config.PersonNumber.ToString();
            cbFinger.SelectedIndex = config.FingerNumber - 1;
            foreach (var variant in _shared.GetLibrary())
            {
                cbScan.Items.Add(variant.Description.ToString());
            }
            cbScan.SelectedIndex = config.Step - 1;
        }

        void ToolWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Code to remove close box from window
            var hwnd = new System.Windows.Interop.WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _shared.ModifyConfiguration(tbSrc.Text, tbDest.Text, tbArduinoPort.Text, tbArduinoBaud.Text, Int32.Parse(tbPerson.Text), cbFinger.SelectedIndex + 1, cbScan.SelectedIndex + 1);
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                MessageBox.Show("Konfiguracja została zapisana.", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            catch
            {
                MessageBox.Show("Nie udało się zapisać zmian!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDest_Click(object sender, RoutedEventArgs e)
        {
            tbSrc.Text = _shared.FileDialog();
        }

        private void btnSrc_Click(object sender, RoutedEventArgs e)
        {
            tbSrc.Text = _shared.FileDialog();
        }
    }
}
