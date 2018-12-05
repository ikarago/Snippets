
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippets.Core.ViewModels
{
    public class SnippetViewModel : NotificationBase
    {
        // Properties
        private int _id;
        public int Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set { SetProperty(ref _details, value); }
        }

        private DateTime _createdOn;
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { SetProperty(ref _createdOn, value); }
        }

        private DateTime _lastModifiedOn;
        public DateTime LastModifiedOn
        {
            get { return _lastModifiedOn; }
            set { SetProperty(ref _lastModifiedOn, value); }
        }




        // Constructor



        // Methods



    }
}
