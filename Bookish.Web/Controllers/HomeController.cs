using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Bookish.Web.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Globalization;
using System.Security.Claims;
using Bookish.DataAccess;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Book = Bookish.Web.Models.Book;

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

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult AddBook()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public ActionResult AddBook(Book model)
        {
            if (ModelState.IsValid)
            {
                DatabaseAccess dbAccess = new DatabaseAccess();
                dbAccess.AddBook(model.Title, model.Author, model.ISBN, model.NumberCopies);

                return RedirectToAction("Index", "Home");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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