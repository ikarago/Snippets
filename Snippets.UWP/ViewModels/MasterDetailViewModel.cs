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
        public CollectionViewModel Core { get; } = new CollectionViewModel();


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

        private ICommand _newSnippetCommand;
        public ICommand NewSnippetCommand
        {
            get
            {
                if (_newSnippetCommand == null)
                {
                    _newSnippetCommand = new RelayCommand(
                        () =>
                        {
                            // Add the new snippet to the backend
                            Core.NewSnippetCommand.Execute(null);
                            // #TODO Pass the data to the platform specific stuff
                        });
                }
                return _newSnippetCommand;
            }
        }

        private ICommand _saveSnippetCommand;
        public ICommand SaveSnippetCommand
        {
            get
            {
                if (_saveSnippetCommand == null)
                {
                    _saveSnippetCommand = new RelayCommand(
                        () =>
                        {
                            // Save the snippet in the backend
                            Core.SaveSnippetCommand.Execute(null);
                            // #TODO Pass the data changes to the platform specific stuff
                        });
                }
                return _saveSnippetCommand;
            }
        }

        private ICommand _deleteSnippetCommand;
        public ICommand DeleteSnippetCommand
        {
            get
            {
                if (_deleteSnippetCommand == null)
                {
                    _deleteSnippetCommand = new RelayCommand(
                        () =>
                        {
                            // Delete the snippet in the backend
                            Core.DeleteSnippetCommand.Execute(null);
                            // #TODO Pass the deletion of data to the platform specific stuff
                        });
                }
                return _deleteSnippetCommand;
            }
        }

        private ICommand _shareSnippetCommand;
        public ICommand ShareSnippetCommand
        {
            get
            {
                if (_shareSnippetCommand == null)
                {
                    _shareSnippetCommand = new RelayCommand(
                        () =>
                        {
                            // #TODO
                        });
                }
                return _shareSnippetCommand;
            }
        }

        private ICommand _copySnippetCommand;
        public ICommand CopySnippetCommand
        {
            get
            {
                if (_copySnippetCommand == null)
                {
                    _copySnippetCommand = new RelayCommand(
                        () =>
                        {
                            // #TODO
                        });
                }
                return _copySnippetCommand;
            }
        }

        private ICommand _copySnippetContentCommand;
        public ICommand CopySnippetContentCommand
        {
            get
            {
                if (_copySnippetContentCommand == null)
                {
                    _copySnippetContentCommand = new RelayCommand(
                        () =>
                        {
                            // #TODO
                        });
                }
                return _copySnippetContentCommand;
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
