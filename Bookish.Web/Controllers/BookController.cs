using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Web.Models;
using Bookish.DataAccess;

namespace Bookish.Web.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult BookInfo(Book bookToShow)
        {
            BookData data = new BookData(bookToShow);

            return View(data);
        }
    }
}