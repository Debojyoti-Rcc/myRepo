using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Billing.Models.ViewModel;
using Billing.Models;
namespace Billing.Controllers
{
    public class PartyController : Controller
    {
        public List<SelectListItem> registered = new List<SelectListItem>();
        //
        // GET: /Party/
        [HttpGet]
        public ActionResult RegisterParty()
        {
            PartyVM modelObj = new PartyVM();
            modelObj.Registered = GetOption();
            return View(modelObj);
        }
        [HttpPost]
        public ActionResult RegisterParty(PartyVM vmObject)
        {
            BillingEntities entity = new BillingEntities();
            Party modelObj = new Party();
            modelObj.Name = vmObject.Name;
            modelObj.Address = vmObject.Address;
            modelObj.MobileNo = vmObject.MobileNo;
            modelObj.CompanyName = vmObject.CompanyName;
            modelObj.GSTN_Number = vmObject.GSTN_Number;
            modelObj.PanNo = vmObject.PanNo;
            //modelObj.Registered = vmObject.Registered.Sele ;
            modelObj.Registered = "Registered";
            var val = Request.Form["Registered"];

            //if(ModelState.IsValid)
            //{
                entity.RegisterParty(modelObj.Name, modelObj.CompanyName, modelObj.Address, modelObj.MobileNo, modelObj.GSTN_Number, modelObj.PanNo);
            //}
            //else
            //{
            //    return View("RegisterParty");
            //}
            return View("Success");
        }
        private List<SelectListItem> GetOption()
        {
            registered.Add(new SelectListItem { Text = "Registered", Value = "Y" });
            registered.Add(new SelectListItem { Text = "Un-Registered", Value = "N" });
            //return new SelectList(registered, "Value", "Text", "id");
            return registered;
        }
        //
        // GET: /Party/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Party/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Party/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Party/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Party/Edit/5
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

        //
        // GET: /Party/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Party/Delete/5
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
