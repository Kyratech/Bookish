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
            DatabaseAccess dbAccess = new DatabaseAccess();
            Console.WriteLine(dbAccess.ReadAllBooks());
        }
    }
}
