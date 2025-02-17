using Muda.Checker.Domain.ValueObjects;
using Muda.Checker.WPF.Commands;
using System.Windows.Input;

namespace Muda.Checker.WPF.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        private TargetDirectory _targetDirectory = TargetDirectory.Empty;
        private TargetYear _targetYear = TargetYear.Empty;
        private bool _isRunning = false;
        private StatusMessage _statusMessage = StatusMessage.Empty;

        public MainWindowViewModel()
        {
            RunCommand = new RunCommand(this);
            UpCommand = new UpCommand(this);
            DownCommand = new DownCommand(this);
            OpenFolderDialogCommand = new OpenFolderDialogCommand(this);
            OpenFileCommand = new OpenFileCommand(this);
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

        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                SetProperty(ref _isRunning, value);
            }
        }

        public StatusMessage StatusMessage
        {
            get => _statusMessage;
            set
            {
                SetProperty(ref _statusMessage, value);
            }
        }

        public ICommand RunCommand { get; }
        public ICommand UpCommand { get; }
        public ICommand DownCommand { get; }
        public ICommand OpenFolderDialogCommand { get; }
        public ICommand OpenFileCommand { get; }
    }
}
