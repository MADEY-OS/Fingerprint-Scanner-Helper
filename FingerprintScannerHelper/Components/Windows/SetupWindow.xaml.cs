using Microsoft.Win32;
using System;
using System.Windows;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace FingerprintScannerHelper.Components.Windows
{
    /// <summary>
    /// Interaction logic for SetupWindow.xaml
    /// </summary>
    public partial class SetupWindow : Window
    {
        public SetupWindow()
        {
            InitializeComponent();
        }

        private void BtnSrc_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Uri fileUri = new Uri(dialog.FileName);
                TBSrc.Text = fileUri.ToString();
            }
        }
        private void BtnDest_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                TBSrc.Text = fileUri.ToString();
            }
        }

         private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                TBSrc.Text = fileUri.ToString();
            }
        }
    }
}
