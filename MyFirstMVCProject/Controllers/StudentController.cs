using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstMVCProject.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            
            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 1, StudentName = "Payal", Age = 23});
            //MvcApplication.studentsList.Add(new Models.Student { StudentId = 2, StudentName = "Patel", Age = 33 });

            return View(MvcApplication.studentsList);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            //Display student info depends on id given
            return View(MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id));
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(MyFirstMVCProject.Models.Student student)
        {
            try
            {
                // TODO: Add insert logic here
                student.StudentId = ++MvcApplication.globalStudentId;
                MvcApplication.studentsList.Add(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            //Display student info depends on id given
            return View(MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id));
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MyFirstMVCProject.Models.Student student)
        {
            try
            {
                // TODO: Add update logic here
                //Get student info depends on id given
                Models.Student std = MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id);

                //Apply changes
                std.StudentName = student.StudentName;
                std.Age = student.Age;

                //Redirect to index page which shows listing
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            //Display student info depends on id given
            return View(MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id));
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MyFirstMVCProject.Models.Student student)
        {
            try
            {
                // TODO: Add delete logic here
                //Get student info depends on id given(user choose by clicking)
                Models.Student std = MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id);

                //Remove that student from list
                MvcApplication.studentsList.Remove(std);

                //Redirect to index page which shows listing
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
