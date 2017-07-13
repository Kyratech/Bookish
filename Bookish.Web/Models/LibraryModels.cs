using Bookish.DataAccess;

namespace Bookish.Web.Models
{
    public class BookDatabase
    {
        public string Table { get; set; }

        public string SearchTerm { get; set; }

        public string SearchMessage { get; }

        public BookDatabase()
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            Table = dbAccess.ReadBooksIntoTable();
            SearchMessage = "";
        }

        public BookDatabase(string search)
        {
            DatabaseAccess dbAccess = new DatabaseAccess();
            Table = dbAccess.SearchBooksIntoTable(search);
            SearchTerm = search;
            SearchMessage = "Showing results for: " + search + "\n\n";
        }
    }
}