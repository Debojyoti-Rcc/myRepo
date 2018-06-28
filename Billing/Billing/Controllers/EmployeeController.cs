using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Billing.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeEntities1 entity = new EmployeeEntities1();
        // GET: Employee
        public ActionResult Index()
        {
            List<EMP> empList = (from e in entity.EMPs select e).ToList();
            return View(empList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            EMP obj = (from e in entity.EMPs where e.EMPNO == id select e).FirstOrDefault();
            return View(obj);
        }

        // GET: Employee/Create
        
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EMP obj)
        {
            try
            {
                // TODO: Add insert logic here
                entity.EMPs.Add(obj);
                entity.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
