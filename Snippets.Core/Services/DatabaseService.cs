﻿using Snippets.Core.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Snippets.Core.Services
{
    public static class DatabaseService
    {
        // Properties
        private static string DB_PATH_LOCAL = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "db_v1.sqlite");


        // Initialize
        public static void InitializeDatabase()
        {
            // #TODO Check for database
            using (SQLiteConnection db = new SQLiteConnection(DB_PATH_LOCAL))
            {
                db.CreateTable<SnippetModel>();
            }
        }


        // Methods

        // Load Snippets
        public static ObservableCollection<SnippetModel> GetSnippets()
        {
            Debug.WriteLine("Database Service - Getting Snippets");

            ObservableCollection<SnippetModel> snippetList = new ObservableCollection<SnippetModel>();

            // Load data in as models
            using (var db = new SQLiteConnection(DB_PATH_LOCAL))
            {
                var query = db.Table<SnippetModel>().OrderBy(s => s.Id);
                foreach (var snippet in query)
                {
                    snippetList.Add(snippet);
                }
            }
            return snippetList;
        }

        // Write changes to database
        public static SnippetModel Write(SnippetModel snippet)
        {
            Debug.WriteLine("Database Service - Save snippet... START");

            using (var db = new SQLiteConnection(DB_PATH_LOCAL))
            {
                try
                {
                    var existingSnippet = db.Table<SnippetModel>().Where(s => s.Id == snippet.Id).FirstOrDefault();
                    if (existingSnippet != null)
                    {
                        // Update 
                        Debug.WriteLine("Database Service - Save Snippet... UPDATE snippet");

                        existingSnippet.Title = snippet.Title;
                        existingSnippet.Details = snippet.Details;
                        existingSnippet.LastModifiedOn = DateTime.Now;

                        int success = db.Update(existingSnippet);

                        // Write new Modification time to the snippetmodel that gets passed back as well
                        snippet.LastModifiedOn = DateTime.Now;
                    }
                    else
                    {
                        // Create
                        Debug.WriteLine("Database Service - Save Snippet... CREATE snippet");

                        snippet.CreatedOn = DateTime.Now;
                        snippet.LastModifiedOn = DateTime.Now;

                        int success = db.Insert(snippet);
                        // Set the ID with the last entry in the dbase
                        snippet.Id = db.Table<SnippetModel>().ToList().FindLast(s => s.Details == snippet.Details).Id;
                    }

                    Debug.WriteLine("Database Service - Save Snippet... SUCCESSFUL");

                }
                catch { Debug.WriteLine("Database Service - Save snippet... FAILED"); }
            }

            return snippet;
        }


        // Delete
        public static bool Delete(SnippetModel snippet)
        {
            Debug.WriteLine("Database Service - Deleting Snippet, Id = " + snippet.Id + "... START");

            bool success = false;

            using (var db = new SQLiteConnection(DB_PATH_LOCAL))
            {
                // Try to get the existing Snippet from the dbase
                // If there is no snippet like this, this function will fail; this to prevent accidental deletions
                var existingSnippet = db.Table<SnippetModel>().Where(s => s.Id == snippet.Id).FirstOrDefault();
                if (existingSnippet != null)
                {
                    db.RunInTransaction(() =>
                    {
                        db.Delete(existingSnippet);
                        // Now check if the snippet really has been deleted from the dbase
                        if (db.Table<SnippetModel>().Where(s => s.Id == existingSnippet.Id).FirstOrDefault() == null)
                        {
                            Debug.WriteLine("Database Service - Deleting Snippet, Id = " + snippet.Id + "... SUCCESSFUL");
                        }
                        else { Debug.WriteLine("Database Service - Deleting Snippet, Id = " + snippet.Id + "... FAILED"); }
                    });
                }
            }

            return success;
        }
    }
}
