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

        public List<BookWithLoanStatus> Data { get; set; }

        public BookData(Book book)
        {
            DatabaseAccess db = new DatabaseAccess();

            Data = db.GetBooksOnLoan(book.Isbn);

            TotalCopies = db.CountCopiesTotal(book.Isbn);
            FreeCopies = TotalCopies - db.CountCopiesBorrowed(book.Isbn);

            Title = book.Title;
            Author = book.Author;
            ISBN = book.Isbn;
        }
    }

    public class UsersBooksModel
    {
        public string Email { get; set; }
        public List<UsersBookWithLoanStatus> Data { get; set; }

        public UsersBooksModel(string email)
        {
            DatabaseAccess db = new DatabaseAccess();

            Data = db.GetUsersBooksOnLoan(email);
            Email = email;
        }
    }

    public enum SearchType
    {
        Title,
        Author
    };
}