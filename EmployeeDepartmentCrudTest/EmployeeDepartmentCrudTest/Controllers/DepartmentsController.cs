using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDepartmentCrudTest.Models;
using EmployeeDepartmentCrudTest.Models.DBContext;

namespace EmployeeDepartmentCrudTest.Controllers
{
    public class DepartmentsController : Controller
    {
        private EmployeeDepartmentContext db = new EmployeeDepartmentContext();

        #region Department/Index/Get
        public ActionResult Index()
        {
            return View(db.Departments.ToList());
        }
        #endregion

        #region Departments/Create/Get
        public ActionResult Create()
        {
            return View();
        }
        #endregion

        #region Departments/Create/post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeptId,DeptName,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }
        #endregion
        #region Departments/Edit/Get

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        #endregion

        #region Departments/Edit/Post
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeptId,DeptName,Description")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }
        #endregion

        #region Departments/Delete/Get
      
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        #endregion

        #region Departments/Delete/Post

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

    }
}
