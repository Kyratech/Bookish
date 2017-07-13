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

    public class BookData
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }

        public int TotalCopies { get; set; }

        public int FreeCopies { get; set; }

        private string Table { get; set; }

        public BookData(string isbn)
        {
            DatabaseAccess db = new DatabaseAccess();

            Table = db.GetBooksOnLoan(isbn);


        }
    }

    public enum SearchType
    {
        Title,
        Author
    };
}