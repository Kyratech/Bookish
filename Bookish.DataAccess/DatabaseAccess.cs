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
    }
}
