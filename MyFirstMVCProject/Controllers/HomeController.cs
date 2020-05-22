using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public string HelloWorld(string firstName,string lastName)
        {
            return $"Hello World from {firstName} {lastName} !!!";
        }

        public ActionResult GetUser(int id)
        {
            IList<int> myList = new List<int>() { 1,2,3,4};
            myList.Add(5);

            ViewBag.Message = $"Hello from the User_{id}";
            ViewBag.MyList = myList;
            return View(); ;
        }
    }
}