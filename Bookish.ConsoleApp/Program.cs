using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Bookish.DataAccess;
using Dapper;

namespace Bookish.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            string SqlString = "SELECT * FROM Books";
            var ourBooks = (List<Book>)db.Query<Book>(SqlString);

            foreach (var book in ourBooks)
            {
                Console.WriteLine(new String('-', 20));
                Console.WriteLine("New book:");
                Console.WriteLine("ID: " + book.BookId);
                Console.WriteLine("ISBN: " + book.Isbn);
                Console.WriteLine("Title: " + book.Title);
                Console.WriteLine("Author: " + book.Author);
                Console.WriteLine(new String('-', 20));
            }
        }
    }
}
