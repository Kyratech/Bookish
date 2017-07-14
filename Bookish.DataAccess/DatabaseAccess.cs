using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Dapper;

namespace Bookish.DataAccess
{
    public class DatabaseAccess
    {
        public string ReadAllBooks()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string SqlString = "SELECT * FROM Books";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            StringBuilder responseString = new StringBuilder();

            foreach (var book in ourBooks)
            {
                responseString.Append(new String('-', 20) + "\n");
                responseString.Append("New book:\n");
                responseString.Append("ID: " + book.BookId + "\n");
                responseString.Append("ISBN: " + book.Isbn + "\n");
                responseString.Append("Title: " + book.Title + "\n");
                responseString.Append("Author: " + book.Author + "\n");
                responseString.Append(new String('-', 20) + "\n");
            }

            return responseString.ToString();
        }

        public List<Book> FetchAllBooksInDb()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string SqlString = "SELECT * FROM Books ORDER BY Title";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            return ourBooks;
        }

        public List<Book> FetchSearchedBooksInDb(string term, string type)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string SqlString = "SELECT * FROM Books WHERE " + type +  " LIKE '%" + term + "%' ORDER BY Title";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            return ourBooks;
        }

        public void AddBook(string title, string author, string isbn, int copies)
        {
            for (int i = 0; i < copies; i++)
            {
                IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                string sqlString = "INSERT INTO Books (ISBN, Title, Author) VALUES ( '" + isbn + "', '" + title + "', '" + author + "')";
                db.Query(sqlString);
            }
        }

        public List<BookWithLoanStatus> GetBooksOnLoan(string isbn)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string query = "SELECT ISNULL(AspNetUsers.Email, 'Available') AS Email, BorrowedBooks.Due AS Due FROM BorrowedBooks INNER JOIN AspNetUsers ON BorrowedBooks.Account = AspNetUsers.Id RIGHT JOIN Books ON BorrowedBooks.BookId = Books.BookId WHERE Books.ISBN = '" + isbn+ "'";
            var ourBooks = (List<BookWithLoanStatus>)db.Query<BookWithLoanStatus>(query);

            return ourBooks;
        }

        public List<UsersBookWithLoanStatus> GetUsersBooksOnLoan(string email)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string query = "SELECT Books.Title AS Title, BorrowedBooks.Due AS Due FROM BorrowedBooks INNER JOIN AspNetUsers ON BorrowedBooks.Account = AspNetUsers.Id RIGHT JOIN Books ON BorrowedBooks.BookId = Books.BookId WHERE AspNetUsers.Email = '" + email + "'";
            var ourBooks = (List<UsersBookWithLoanStatus>)db.Query<UsersBookWithLoanStatus>(query);

            return ourBooks;
        }

        public int CountCopiesTotal(string isbn)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string query = "SELECT COUNT(*) FROM Books WHERE Isbn = '"+ isbn +"'";
            int copies = (int) db.ExecuteScalar(query);

            return copies;
        }

        public int CountCopiesBorrowed(string isbn)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string query =
                "SELECT COUNT(*) FROM Books INNER JOIN BorrowedBooks ON Books.BookId = BorrowedBooks.BookId WHERE Books.ISBN = '" + isbn + "'";
            int copies = (int) db.ExecuteScalar(query);

            return copies;
        }
    }
}
