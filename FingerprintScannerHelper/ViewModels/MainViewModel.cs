using FingerprintScannerHelper.Commands;
using System.Windows.Input;

namespace FingerprintScannerHelper.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel { get => _selectedViewModel; set { _selectedViewModel = value; OnPropertyChanged(); } }

        private string _menuVisibility;
        public string MenuVisibility { get => _menuVisibility; set { _menuVisibility = value; OnPropertyChanged(); } }
        public ICommand UpdateView { get; set; }

        public MainViewModel()
        {
            _menuVisibility = "Hidden";
            _selectedViewModel = new SetupViewModel(this);
            UpdateView = new UpdateViewCommand(this);
        }
    }
}
