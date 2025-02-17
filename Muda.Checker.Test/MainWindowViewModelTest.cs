using Muda.Checker.Domain.ValueObjects;
using Muda.Checker.WPF.ViewModels;

namespace Muda.Checker.Test
{
    public class MainWindowViewModelTest
    {
        private MainWindowViewModel _viewModel;
        [SetUp]
        public void Setup()
        {
            _viewModel = new MainWindowViewModel();
        }

        [Test]
        public void ‰Šúó‘Ô‚ª³‚µ‚¢()
        {
            _viewModel.TargetDirectory.Is(TargetDirectory.Empty);
            _viewModel.TargetDirectory.Value.Is("‘I‘ğ‚µ‚Ä‚­‚¾‚³‚¢");
            _viewModel.TargetYear.Is(TargetYear.Empty);
            _viewModel.TargetYear.Value.Is(0);
            _viewModel.TargetYear.DisplayValue.Is("“ü—Í‚µ‚Ä‚­‚¾‚³‚¢");
            _viewModel.RunCommand.CanExecute(null).Is(false);
            _viewModel.IsRunning.Is(false);
        }
    }
}