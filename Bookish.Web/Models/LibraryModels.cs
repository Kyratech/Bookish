using Bookish.DataAccess;

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

    public enum SearchType
    {
        Title,
        Author
    };
}