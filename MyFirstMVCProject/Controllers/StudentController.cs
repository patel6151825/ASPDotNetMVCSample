using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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

            //return View(MvcApplication.studentsList);
            //above commented is previous code

            return View(DataAccessLayer.DBContext.SelectAllStudents());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            //Display student info depends on id given
            //return View(MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id));
            //above commented is previous code

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = DataAccessLayer.DBContext.SelectStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
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

                //student.StudentId = ++MvcApplication.globalStudentId;
                //MvcApplication.studentsList.Add(student);
                //above commented is previous code

                if (ModelState.IsValid)
                {
                    if (student == null)
                    {
                        return HttpNotFound();
                    }
                    DataAccessLayer.DBContext.CreateStudent(student);
                }   
                return RedirectToAction("Index");
            }
            catch(DataException)
            {
                ModelState.AddModelError("", "Unable to create student, Try Again!!!");
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            //Display student info depends on id given
            //return View(MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id));
            //above commented is previous code

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = DataAccessLayer.DBContext.SelectStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MyFirstMVCProject.Models.Student student)
        {
            try
            {
                // TODO: Add update logic here
                ////Get student info depends on id given
                //Models.Student std = MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id);

                ////Apply changes
                //std.StudentName = student.StudentName;
                //std.Age = student.Age;

                //above commented is previous code

                if (ModelState.IsValid)
                {
                    if (student == null)
                    {
                        return HttpNotFound();
                    }
                    DataAccessLayer.DBContext.UpdateStudentById(id,student);
                }
                
                //Redirect to index page which shows listing
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to edit student, Try Again!!!");
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            //Display student info depends on id given
            //return View(MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id));

            //above commented is previous code

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Student student = DataAccessLayer.DBContext.SelectStudentById(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, MyFirstMVCProject.Models.Student student)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (student == null)
            {
                return HttpNotFound();
            }
            try
            {
                //// TODO: Add delete logic here
                ////Get student info depends on id given(user choose by clicking)
                //Models.Student std = MvcApplication.studentsList.FirstOrDefault(s => s.StudentId == id);

                ////Remove that student from list
                //MvcApplication.studentsList.Remove(std);

                //above commented is previous code

                
                DataAccessLayer.DBContext.DeleteStudentById(id);
                
                //Redirect to index page which shows listing
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to delete student, Try Again!!!");
                return View();
            }
        }
    }
}
