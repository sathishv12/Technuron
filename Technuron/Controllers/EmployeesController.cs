using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Technuron;
using System.Data;

namespace Technuron.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees/Index
        public ActionResult Index()
        {
            using(curdEntities m = new curdEntities())
            {
                return View(m.Employees.ToList());
            }
           
        }

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {

            using(curdEntities m = new curdEntities())
            {
                return View(m.Employees.Where(x=>x.Id==id).FirstOrDefault());
            }
            
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                using (curdEntities m = new curdEntities())
                {
                    m.Employees.Add(employee);
                    m.SaveChanges();
                }
                
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {

            using (curdEntities m = new curdEntities())
            {
                return View(m.Employees.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employee employee)
        {
            try
            {
                using (curdEntities m = new curdEntities())
                {
                    m.Entry(employee).State = EntityState.Modified;
                    m.SaveChanges();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            using (curdEntities m = new curdEntities())
            {
                return View(m.Employees.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                using (curdEntities m = new curdEntities())
                {
                   employee=m.Employees.Where(x => x.Id == id).FirstOrDefault();
                    m.Employees.Remove(employee);
                    m.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
