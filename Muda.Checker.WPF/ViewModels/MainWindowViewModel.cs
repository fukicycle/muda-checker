using Muda.Checker.Domain.ValueObjects;
using Muda.Checker.WPF.Commands;
using System.Windows.Input;

namespace Muda.Checker.WPF.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private TargetDirectory _targetDirectory = TargetDirectory.Empty;
        private TargetYear _targetYear = TargetYear.Empty;

        public MainWindowViewModel()
        {
            RunCommand = new RunCommand(this);
        }
        public TargetDirectory TargetDirectory
        {
            get => _targetDirectory;
            set
            {
                SetProperty(ref _targetDirectory, value);
            }
        }

        public TargetYear TargetYear
        {
            get => _targetYear;
            set
            {
                SetProperty(ref _targetYear, value);
            }
        }

        public ICommand RunCommand { get; }
    }
}
