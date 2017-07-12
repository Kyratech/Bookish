using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class BookDatabase
    {
        public string Table { get; set; }

        public BookDatabase()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            Table = dbAccess.ReadBooksIntoTable();
        }
    }
}