using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Billing.Models.ViewModel;
using Billing.Models;

namespace Billing.Controllers
{
    public class BillController : Controller
    {
        static BillTemplate billTemplateObj = new Models.ViewModel.BillTemplate();
        //
        // GET: /Bill/
        List<SelectListItem> service = new List<SelectListItem>();
        List<SelectListItem> billParticular = new List<SelectListItem>();
        List<SelectListItem> billPaulOffset = new List<SelectListItem>();
        List<SelectListItem> colorList = new List<SelectListItem>();
        BillingEntities entityObject = new BillingEntities();
        private SelectList GetServices()
        {
            service.Add(new SelectListItem { Text = "Manufacturing", Value = "12" });
            service.Add(new SelectListItem { Text = "Labour-Job", Value = "18" });
            return new SelectList(service,"Value", "Text",  "id");
        }
        private SelectList BillTemplateParticular()
        {
            billParticular.Add(new SelectListItem { Text = "Paul Offset", Value = "pauloffset" });
            //billParticular.Add(new SelectListItem { Text = "Paul Offset", Value = "1" });
            billParticular.Add(new SelectListItem { Text = "Paul Boxes", Value = "paulboxes" });
            //billParticular.Add(new SelectListItem { Text = "Paul Boxes", Value = "2" });
            return new SelectList(billParticular, "Value", "Text",  "id");
        }

        public SelectList NoOfColor()
        {
            colorList.Add(new SelectListItem { Text = "Special", Value = "1" });
            colorList.Add(new SelectListItem { Text = "Bi", Value = "2" });
            colorList.Add(new SelectListItem { Text = "Tri", Value = "3" });
            colorList.Add(new SelectListItem { Text = "Four", Value = "4" });
            return new SelectList(colorList, "Value", "Text", "id");
        }
        [ValidateAntiForgeryToken]
        public ActionResult GenerateBillTemplate()
        {
            ViewBag.Service = GetServices();
            ViewBag.Biller = BillTemplateParticular();
            return View();
        }
        public ActionResult BillTemplate(FormCollection objForm)
        {
            

            var chk2 = objForm["ddlNoOfColor"];
            var chk = Request.Form["Biller"];
            var chk1 = Request.Form["ChargePerThousand"];
            var p = Request.Form["Address"];
            var pn = Request.Form["CompanyName"];
            return View(billTemplateObj);
        }
        private List<SelectListItem> GetNoOfColors()
        {
            
            billPaulOffset.Add(new SelectListItem { Text = "Bi-Color", Value = "2" });
            billPaulOffset.Add(new SelectListItem { Text = "Tri-Color", Value = "3" });
            billPaulOffset.Add(new SelectListItem { Text = "Four-Color", Value = "4" });
            billPaulOffset.Add(new SelectListItem { Text = "Special-Color", Value = "1" });
            return billPaulOffset;
        }
        [HttpGet]
        public ActionResult BillPaulOffset()
        {
            PaulOffsetBillTemplateVM vmObj = new PaulOffsetBillTemplateVM();
            vmObj.NoOfColor = new SelectList(DataAccessLayer.DalLayer.GetAvailableColor(),"ColorValue","ColorName");
            return View(vmObj);
        }
        [HttpPost]
        public ActionResult BillPaulOffsetPost()
        {
            //var k = obj;
            int noOfColor = System.Convert.ToInt32(Request.Form["NoOfColor"]);
            double ratePerThousand = System.Convert.ToDouble(Request.Form["ChargePerThousand"]);
            double quantity = System.Convert.ToDouble(Request.Form["Quantity"]);
            double plateCharge = System.Convert.ToDouble(Request.Form["PlateCharge"]);
            var k = DataAccessLayer.DalLayer.GetPartyList();
            //double total = 
            return View("Success");
        }
        public double GetRate(string noOfColor)
        {
            return DataAccessLayer.DalLayer.GetRate(System.Convert.ToInt32(noOfColor));
        }
        public ActionResult AddPartyDetailsBill()
        {
            PartyDetailsBill vmObject = new PartyDetailsBill();
            vmObject.CompanyName = new SelectList(DataAccessLayer.DalLayer.GetPartyList());
            return PartialView("PartyDetailsBill",vmObject);
        }
        public JsonResult GetPartyDetails(string companyName)
        {
            Party k = DataAccessLayer.DalLayer.GetPartyDetails(companyName);
            return Json(k, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult GenerateBill(PartyDetailsBill obj)
        {
            var k = Request.Form["CompanyName"];
            var c = Request.Form["Address"];
            var p = Request.Form["Total"];
            return View();
        }

        public ActionResult GeneratePaulOffsetPartial()
        {
            ViewBag.NoOfColor = GetNoOfColors();
            return PartialView("Partial_PaulOffset");
        }
        public ActionResult Manufacturing()
        {
            return View();
        }

        public ActionResult RenderConditionalPartialPage(string service,string biller)
        {
            if(service == "18")
            {
                if(biller == "pauloffset")
                {
                    ViewBag.NoOfColor = GetNoOfColors();
                    return PartialView("Partial_PaulOffset");
                }
                else
                {
                    return View("Error");
                }
            }
            if(service == "12")
            {
                return PartialView("Partial_Manufacturing");
            }
            else
            {
                return null;
            }

            //return PartialView();
            //return null;
        }
        public ActionResult ModalPopUpPrinting()
        {
            return View();
        }

        public ActionResult BillActual(string biller,string partyName,string partyAddress,string partyGST, string total, string taxRate, string itemName, string itemDESC,string quantity)
        {
            
            billTemplateObj.Biller = biller;
            billTemplateObj.BilledTo = partyName;
            billTemplateObj.BilledTo_Address = partyAddress;
            billTemplateObj.BilledTo_GST = partyGST;
            billTemplateObj.TaxRate = taxRate;
            billTemplateObj.TotalAmount = total;
            billTemplateObj.ItemName = itemName;
            billTemplateObj.ItemDescription = itemDESC;
            billTemplateObj.Quantity = quantity;
            var t = System.Convert.ToInt32(taxRate);
            billTemplateObj.SGST = (t/2).ToString();
            billTemplateObj.CGST = (t/2).ToString();
            billTemplateObj.TaxAmount = ((System.Convert.ToDouble(total)) * t / 100).ToString();
            return View(billTemplateObj);
        }
    }
}