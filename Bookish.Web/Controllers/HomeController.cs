using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Bookish.Web.Models;

namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult StartIndex()
        {
            //return RedirectToAction("AccountPage", "Account");
            BookDatabase db = new BookDatabase();
            return View("Index", db);
        }

        public ActionResult Index(BookDatabase model)
        {
            BookDatabase db;
            //return RedirectToAction("AccountPage", "Account");
            if (!model.SearchTerm.IsEmpty())
            {
                db = new BookDatabase(model.SearchTerm, model.SearchSection);
            }
            else
            {
                db = new BookDatabase();
            }

            return View(db);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}