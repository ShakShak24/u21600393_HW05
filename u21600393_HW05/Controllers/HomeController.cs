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
            List<Books> bookR = dataService.GetBooks();
            return View(bookR);

        }

        [HttpPost]
        public ActionResult booksearch(string bookname, string authorname, string typename)
        {
            List<Books> books = dataService.searchbooks(bookname, authorname, typename);
            return View("Index", books);
        }

        public ActionResult clearIndex()
        {
            return RedirectToAction("Index");
        }

        

        public ActionResult Borrows(int bookId)
        {
            List<Borrowed> borrows = dataService.GetBorroweds(bookId);
            return View(borrows);
        }

        

        public ActionResult Students()
        {
            List<Students> students = dataService.GetStudents();
            return View(students);
        }

        [HttpPost]
        public ActionResult studentsearch(string name, string cla)
        {
            List<Students> stu = dataService.SearchStudents(name, cla);
            return View("Students", stu);
        }

        public ActionResult clearStudents()
        {
            return RedirectToAction("Students");
        }



    }
}