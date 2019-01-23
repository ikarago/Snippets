using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Snippets.Core.ViewModels;
using Snippets.UWP.Helpers;
using Snippets.UWP.Views;
using Windows.ApplicationModel.DataTransfer;

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
                            ShareSnippet();
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

        // Share Snippet
        private void ShareSnippet()
        {
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested += DataTransferManager_DataRequested;
            DataTransferManager.ShowShareUI();
        }
        private void DataTransferManager_DataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            // Get the request args
            DataRequest request = args.Request;

            // Construct the string that'll be shared
            StringBuilder shareTextBuilder = new StringBuilder();
            if (Core.SelectedSnippet.Title != "")
            {
                shareTextBuilder.AppendLine(Core.SelectedSnippet.Title);
                shareTextBuilder.AppendLine("");
            }
            shareTextBuilder.AppendLine(Core.SelectedSnippet.Details);
            string shareText = shareTextBuilder.ToString().TrimEnd();

            // Set the data to the text in the Snippet
            request.Data.SetText(shareText);

            // Set the title if it has one
            // #TODO: Fix Title is the title is empty
            if (Core.SelectedSnippet.Title != "")
            {
                request.Data.Properties.Title = (Windows.ApplicationModel.Package.Current.DisplayName + " - " + Core.SelectedSnippet.Title);
            }
            else
            {
                request.Data.Properties.Title = (Windows.ApplicationModel.Package.Current.DisplayName + " - Snippet");
            }

            // #TODO: Handle share failures
        }



        // Dialogs
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
