
using Snippets.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippets.Core.ViewModels
{
    public class SnippetViewModel : NotificationBase<SnippetModel>
    {
        // Properties
        private SnippetModel _snippetModel;

        public int Id
        {
            get { return This.Id; }
            set { SetProperty(This.Id, value, () => This.Id = value); }
        }

        public string Title
        {
            get { return This.Title; }
            set { SetProperty(This.Title, value, () => This.Title = value); }
        }

        public string Details
        {
            get { return This.Details; }
            set { SetProperty(This.Details, value, () => This.Details = value); }
        }

        public DateTime CreatedOn
        {
            get { return This.CreatedOn; }
            set { SetProperty(This.CreatedOn, value, () => This.CreatedOn = value); }
        }

        public DateTime LastModifiedOn
        {
            get { return This.LastModifiedOn; }
            set { SetProperty(This.LastModifiedOn, value, () => This.LastModifiedOn = value); }
        }




        // Constructor
        public SnippetViewModel()
        {
            _snippetModel = new SnippetModel();
        }


        // Methods
        public SnippetModel GetSnippetModel()
        {
            SnippetModel model = new SnippetModel();

            model.Id = This.Id;
            model.Title = This.Title;
            model.Details = This.Details;
            model.CreatedOn = This.CreatedOn;
            model.LastModifiedOn = This.LastModifiedOn;

            return model;
        }


    }
}
