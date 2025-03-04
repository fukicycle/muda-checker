﻿using Muda.Checker.Domain.Logics;
using Muda.Checker.Domain.ValueObjects;
using Muda.Checker.WPF.ViewModels;
using System.Windows.Input;

namespace Muda.Checker.WPF.Commands
{
    public sealed class RunCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;
        public event EventHandler? CanExecuteChanged;
        public RunCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
            _viewModel.PropertyChanged += (s, e) => CanExecuteChanged?.Invoke(s, e);
        }

        public bool CanExecute(object? parameter)
        {
            return _viewModel.TargetDirectory != TargetDirectory.Empty
                && _viewModel.TargetYear != TargetYear.Empty
                && !_viewModel.IsRunning;
        }

        public async void Execute(object? parameter)
        {
            _viewModel.StatusMessage = StatusMessage.Empty;
            _viewModel.IsRunning = true;
            try
            {
                var directories = await DirectoryService.GetAllDirectoriesAsync(_viewModel.TargetDirectory);
                var targetFiles = await FileService.GetAllFilesAsync(directories, _viewModel.TargetYear);
                string path = await CsvService.SaveAsync(targetFiles);
                _viewModel.StatusMessage = new StatusMessage(path);
            }
            catch (Exception e)
            {
                _viewModel.StatusMessage = new StatusMessage(e.Message, true);
            }
            finally
            {
                _viewModel.IsRunning = false;
            }
        }
    }
}
