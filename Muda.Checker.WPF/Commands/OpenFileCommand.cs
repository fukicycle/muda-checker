using Muda.Checker.WPF.ViewModels;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Muda.Checker.WPF.Commands
{
    public sealed class OpenFileCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;
        public event EventHandler? CanExecuteChanged;
        public OpenFileCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
        }

        public bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.StatusMessage.FilePath);
        }

        public void Execute(object? parameter)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = _viewModel.StatusMessage.FilePath;
                psi.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ファイルを開くことができませんでした。\nスタックトレース:{ex.StackTrace}");
            }
        }
    }
}
