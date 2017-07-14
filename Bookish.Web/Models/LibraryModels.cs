using System;
using System.Collections.Generic;
using Bookish.DataAccess;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Bookish.Web.Models
{
    public class BookDatabase
    {
        public string SearchTerm { get; set; }

        public string SearchMessage { get; }

        public SearchType SearchSection { get; set; }

        public List<Book> data { get; set; }

        public BookDatabase()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            data = dbAccess.FetchAllBooksInDb();
            SearchMessage = "";
        }

        public BookDatabase(string search, SearchType section)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();

            data = dbAccess.FetchSearchedBooksInDb(search, section.ToString());
            SearchTerm = search;
            SearchMessage = "Showing results for: " + search + "\n\n";
        }
    }

    public class NewBookModel
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

        public string Table { get; set; }

        public BookData(Book book)
        {
            DatabaseAccess db = new DatabaseAccess();

            Table = db.GetBooksOnLoan(book.Isbn);

            Title = book.Title;
            Author = book.Author;
            ISBN = book.Isbn;

            TotalCopies = 2;
            FreeCopies = 1;
        }
    }

    public enum SearchType
    {
        Title,
        Author
    };
}