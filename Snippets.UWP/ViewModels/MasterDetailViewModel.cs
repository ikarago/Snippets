using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Snippets.Core.ViewModels;
using Snippets.UWP.Helpers;
using Snippets.UWP.Views;

namespace Snippets.UWP.ViewModels
{
    public class MasterDetailViewModel : Observable
    {
        // Properties
        public CollectionViewModel Data { get; } = new CollectionViewModel();


        // Constructor
        public MasterDetailViewModel()
        {
            Initialize();
        }
        // Initialize
        private void Initialize()
        {

        }


        // Commands
        private ICommand _settingsCommand;
        public ICommand SettingsCommand
        {
            get
            {
                if (_settingsCommand == null)
                {
                    _settingsCommand = new RelayCommand(
                        () =>
                        {
                            ShowSettingsDialogAsync();
                        });
                }
                return _settingsCommand;
            }
        }

        private ICommand _aboutCommand;
        public ICommand AboutCommand
        {
            get
            {
                if (_aboutCommand == null)
                {
                    _aboutCommand = new RelayCommand(
                        () =>
                        {
                            ShowAboutDialogAsync();
                        });
                }
                return _aboutCommand;
            }
        }



        // Methods
        private async void ShowSettingsDialogAsync()
        {
            var dialog = new SettingsDialog();
            await dialog.ShowAsync();
        }

        private async void ShowAboutDialogAsync()
        {
            var dialog = new AboutDialog();
            await dialog.ShowAsync();
        }
    }
}
