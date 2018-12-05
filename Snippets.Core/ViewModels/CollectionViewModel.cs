using Snippets.Core.Helpers;
using Snippets.Core.Models;
using Snippets.Core.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                            // #TODO
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
                            // #TODO
                        });
                }
                return _deleteSnippetCommand;
            }
        }




        // Methods
        private void GetSnippets()
        {
            // #TODO
        }

        private void NewSnippet()
        {
            // #TODO
            SelectedSnippet = new SnippetViewModel();
            SelectedSnippet.Details = _newSnippetString;

            NewSnippetString = "";

            SaveSnippet();

            Snippets.Add(SelectedSnippet);
        }

        private void SaveSnippet()
        {
            
            SnippetModel model = new SnippetModel();

            model.Id = SelectedSnippet.Id;
            model.Title = SelectedSnippet.Title;
            model.Details = SelectedSnippet.Details;
            model.CreatedOn = SelectedSnippet.CreatedOn;
            model.LastModifiedOn = SelectedSnippet.LastModifiedOn;

            var savedModel = DatabaseService.Write(model);

            SelectedSnippet.Id = savedModel.Id;
            SelectedSnippet.CreatedOn = savedModel.CreatedOn;
            SelectedSnippet.LastModifiedOn = savedModel.LastModifiedOn;
        }

        private void DeleteSnippet()
        {
            // #TODO
        }
    }
}
