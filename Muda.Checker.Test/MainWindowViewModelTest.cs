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
        public void 初期状態が正しい()
        {
            _viewModel.TargetDirectory.Is(TargetDirectory.Empty);
            _viewModel.TargetDirectory.Value.Is("選択してください");
            _viewModel.TargetYear.Is(TargetYear.Empty);
            _viewModel.TargetYear.Value.Is(0);
            _viewModel.TargetYear.DisplayValue.Is("ボタンで変更してください");
            _viewModel.RunCommand.CanExecute(null).Is(false);
            _viewModel.IsRunning.Is(false);
            _viewModel.StatusMessage.Value.Is(string.Empty);
            _viewModel.StatusMessage.ForegroundColor.Is("Green");
        }
    }
}