using System;
using Bookish.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Bookish.Web.Models
{
    public class BookDatabase
    {
        public string Table { get; set; }

        public string SearchTerm { get; set; }

        public string SearchMessage { get; }

        public SearchType SearchSection { get; set; }

        public BookDatabase()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            Table = dbAccess.ReadBooksIntoTable();
            SearchMessage = "";
        }

        public BookDatabase(string search, SearchType section)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();

            Table = dbAccess.SearchBooksIntoTable(search, section.ToString());
            SearchTerm = search;
            SearchMessage = "Showing results for: " + search + "\n\n";
        }
    }

    public class Book
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Number of Copies")]
        public int NumberCopies { get; set; }
    }

    public enum SearchType
    {
        Title,
        Author
    };
}