using Snippets.Core.Helpers;
using Snippets.Core.Models;
using Snippets.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace Snippets.Core.ViewModels
{
    public class CollectionViewModel : NotificationBase
    {
        // Properties
        private ObservableCollection<SnippetViewModel> _snippets;
        public ObservableCollection<SnippetViewModel> Snippets
        {
            get { return _snippets; }
            set { SetProperty(ref _snippets, value); }
        }

        private SnippetViewModel _selectedSnippet;
        public SnippetViewModel SelectedSnippet
        {
            get { return _selectedSnippet; }
            set { SetProperty(ref _selectedSnippet, value); }
        }

        private string _newSnippetString;
        public string NewSnippetString
        {
            get { return _newSnippetString; }
            set { SetProperty(ref _newSnippetString, value); }
        }



        // Constructor
        public CollectionViewModel()
        {
            Initialize();
        }

        // Initialize
        private void Initialize()
        {
            _snippets = new ObservableCollection<SnippetViewModel>();

            GetSnippets();

            _selectedSnippet = null;
        }


        // Commands
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
                            NewSnippet();
                        });
                }
                return _newSnippetCommand;
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
                            DeleteSnippet();
                        });
                }
                return _deleteSnippetCommand;
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
                            SaveSnippet();
                        });
                }
                return _saveSnippetCommand;
            }
        }



        // Methods
        private void GetSnippets()
        {
            // #TODO Let the ViewModel import an Model automagically
            var _snippetModels = DatabaseService.GetSnippets();

            foreach(var sm in _snippetModels)
            {
                SnippetViewModel svm = new SnippetViewModel();
                svm.Id = sm.Id;
                svm.Title = sm.Title;
                svm.Details = sm.Details;
                svm.CreatedOn = sm.CreatedOn;
                svm.LastModifiedOn = sm.LastModifiedOn;

                _snippets.Add(svm);
            }
        }

        private void NewSnippet()
        {
            // #TODO: Test and documentation
            // #TEMP
            NewSnippetString = "Hello!";

            SnippetViewModel newSnippet = new SnippetViewModel();
            newSnippet.Details = _newSnippetString;

            NewSnippetString = "";

            newSnippet = SaveNewSnippet(newSnippet);

            Snippets.Add(newSnippet);
            //SelectedSnippet = Snippets.IndexOf(newSnippet).
        }

        private void SaveSnippet()
        {
            
            //SnippetModel model = new SnippetModel();

            //model.Id = SelectedSnippet.Id;
            //model.Title = SelectedSnippet.Title;
            //model.Details = SelectedSnippet.Details;
            //model.CreatedOn = SelectedSnippet.CreatedOn;
            //model.LastModifiedOn = SelectedSnippet.LastModifiedOn;

            var savedModel = DatabaseService.Write(_selectedSnippet.GetSnippetModel());

            SelectedSnippet.Id = savedModel.Id;
            SelectedSnippet.CreatedOn = savedModel.CreatedOn;
            SelectedSnippet.LastModifiedOn = savedModel.LastModifiedOn;
        }

        private SnippetViewModel SaveNewSnippet(SnippetViewModel snippet)
        {

            //SnippetModel model = new SnippetModel();

            //model.Id = snippet.Id;
            //model.Title = snippet.Title;
            //model.Details = snippet.Details;
            //model.CreatedOn = snippet.CreatedOn;
            //model.LastModifiedOn = snippet.LastModifiedOn;

            var savedModel = DatabaseService.Write(snippet.GetSnippetModel());

            snippet.Id = savedModel.Id;
            snippet.CreatedOn = savedModel.CreatedOn;
            snippet.LastModifiedOn = savedModel.LastModifiedOn;

            return snippet;
        }

        private void DeleteSnippet()
        {
            Debug.WriteLine("CollectionViewModel - Delete Snippet... START");

            SnippetViewModel snippet = _selectedSnippet;

            try
            {
                // #TODO Convert Snippet to Model via the SnippetViewModel only
                //SnippetModel model = new SnippetModel();

                //model.Id = SelectedSnippet.Id;
                //model.Title = SelectedSnippet.Title;
                //model.Details = SelectedSnippet.Details;
                //model.CreatedOn = SelectedSnippet.CreatedOn;
                //model.LastModifiedOn = SelectedSnippet.LastModifiedOn;

                DatabaseService.Delete(snippet.GetSnippetModel());
                Snippets.Remove(snippet);
                SelectedSnippet = null;
                Debug.WriteLine("CollectionViewModel - Delete Snippet... SUCCESSFUL");
            }
            catch { Debug.WriteLine("CollectionViewModel - Delete Snippet... FAILED"); }
        }
    }
}
