using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.DataAccess
{
    public class Book
    {
        public int BookId { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }
}
