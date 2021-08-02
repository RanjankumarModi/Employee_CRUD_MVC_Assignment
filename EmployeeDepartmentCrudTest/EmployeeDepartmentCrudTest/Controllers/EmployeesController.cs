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
    public class EmployeesController : Controller
    {
        private EmployeeDepartmentContext db = new EmployeeDepartmentContext();
        #region employee/Index/Get
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Salary)
                                        .OrderByDescending(e => e.Salary.SalaryAmount)
                                        .ToList();
           //var orderedlist = from e in employees
           //                   orderby e.Salary.SalaryAmount d, e.Name
           //                   select e;
            return View(employees);
        }
        #endregion



        #region Employees/Create/get
        public ActionResult Create()
        {
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName");
            //ViewBag.Id = new SelectList(db.Salaries, "EmpId", "EmpId");
            return View();
        }

        #endregion

        #region Employee/Create/Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,DeptId,Name,DOJ,Mobile,Email,Address,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.EmployeeId = new SelectList(db.Salaries, "EmployeeId", "EmployeeId", employee.EmployeeId);
            return View(employee);
        }

        #endregion

        #region Employee/Get/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.EmployeeId = new SelectList(db.Salaries, "EmployeeId", "EmployeeId", employee.EmployeeId);
            return View(employee);
        }
        #endregion

        #region Employee/post/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,DeptId,Name,DOJ,Mobile,Email,Address,Salary")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Salary.EmployeeId = employee.EmployeeId;
                db.Entry(employee.Salary).State = EntityState.Modified;
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeptId = new SelectList(db.Departments, "DeptId", "DeptName", employee.DeptId);
            ViewBag.EmployeeId = new SelectList(db.Salaries, "EmployeeId", "EmployeeId", employee.EmployeeId);
            return View(employee);
        }
        #endregion


        #region  Employees/Delete/get

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        #endregion

        #region Employee/Delete/get
   
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion
        
    }
}
