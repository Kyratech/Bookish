using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Web.Models;

namespace Bookish.Web.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult BookInfo(string isbn)
        {
            BookData data = new BookData(isbn);
            data.Author = "Ayy";
            data.Title = "Lmao";
            data.ISBN = isbn;

            return View(data);
        }
    }
}