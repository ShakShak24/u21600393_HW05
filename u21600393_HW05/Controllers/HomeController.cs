using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21600393_HW05.Models;


namespace u21600393_HW05.Controllers
{
    public class HomeController : Controller
    {
        private DataServiceClass dataService = DataServiceClass.getInstance();
        public ActionResult Index()
        {
            BooksVM bookR = new BooksVM();
            bookR.Authors = dataService.GetAuthors();
            bookR.Books = dataService.GetBooks();
            bookR.Types = dataService.GetTypes();

            return View(bookR);

        }

        //[HttpPost]
        //public ActionResult searchBooks(string bookName)
        //{
        //    List<Books> books = dataService.searchBooks(bookName);
        //    return View("Index", books);
        //}

        //public ActionResult SearchBookName(string book)

        public ActionResult Borrows(int bookId)
        {
            List<Borrowed> borrows = dataService.GetBorroweds(bookId);
            return View(borrows);
        }

        //public ActionResult getCount(int bookId)
        //{
        //    List<Borrowed> count = dataService.getCount(bookId);
        //    return RedirectToAction("Borrows");
        //}

        public ActionResult Students()
        {
            List<Students> students = dataService.GetStudents();


            return View(students);
        }

        

    }
}