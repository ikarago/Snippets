using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snippets.Core.Models
{
    public class SnippetModel
    {
        [PrimaryKey][AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }
}
