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

        public string ReadBooksIntoTable()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string SqlString = "SELECT * FROM Books ORDER BY Title";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            StringBuilder responseString = new StringBuilder();

            //Table title content/formatiing
            responseString.Append("<table style=\"width: 100 % \">");
            responseString.Append("<tr><th>ISBN</th><th>Title</th><th>Author</th>");

            foreach (var book in ourBooks)
            {
                responseString.Append("<tr>");
                responseString.Append("<td>" + book.Isbn + "</td>");
                responseString.Append("<td>" + book.Title + "</td>");
                responseString.Append("<td>" + book.Author + "</td>");
                responseString.Append("</tr>");
            }
            responseString.Append("</table>");

            return responseString.ToString();
        }

        public string SearchBooksIntoTable(string term, string type)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string SqlString = "SELECT * FROM Books WHERE " + type +  " LIKE '%" + term + "%' ORDER BY Title";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            StringBuilder responseString = new StringBuilder();

            //Table title content/formatiing
            responseString.Append("<table style=\"width: 100 % \">");
            responseString.Append("<tr><th>ISBN</th><th>Title</th><th>Author</th>");

            foreach (var book in ourBooks)
            {
                responseString.Append("<tr>");
                responseString.Append("<td>" + book.Isbn + "</td>");
                responseString.Append("<td>" + book.Title + "</td>");
                responseString.Append("<td>" + book.Author + "</td>");
                responseString.Append("</tr>");
            }
            responseString.Append("</table>");

            return responseString.ToString();
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
    }
}
