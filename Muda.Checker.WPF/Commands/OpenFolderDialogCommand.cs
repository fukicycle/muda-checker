using Microsoft.Win32;
using Muda.Checker.Domain.ValueObjects;
using Muda.Checker.WPF.ViewModels;
using System.Windows.Input;

namespace Muda.Checker.WPF.Commands
{
    internal class OpenFolderDialogCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;
        public event EventHandler? CanExecuteChanged;

        public OpenFolderDialogCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
        }

        public bool CanExecute(object? parameter)
        {
            return !_viewModel.IsRunning;
        }

        public void Execute(object? parameter)
        {
            OpenFolderDialog ofd = new OpenFolderDialog();
            if (ofd.ShowDialog() == true)
            {
                _viewModel.StatusMessage = StatusMessage.Empty;
                _viewModel.TargetDirectory = new TargetDirectory(ofd.FolderName);
            }
        }
    }
}
