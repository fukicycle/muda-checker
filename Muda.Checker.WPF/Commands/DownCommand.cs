using Muda.Checker.Domain.ValueObjects;
using Muda.Checker.WPF.ViewModels;
using System.Windows.Input;

namespace Muda.Checker.WPF.Commands
{
    public sealed class DownCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;
        public event EventHandler? CanExecuteChanged;
        public DownCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
        }

        public bool CanExecute(object? parameter)
        {
            return _viewModel.TargetYear.Value > 1 && !_viewModel.IsRunning;
        }

        public void Execute(object? parameter)
        {
            int current = _viewModel.TargetYear.Value;
            _viewModel.TargetYear = new TargetYear(current - 1);
        }
    }
}
