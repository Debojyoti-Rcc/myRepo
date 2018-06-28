using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Billing.Models.ViewModel
{
    public class PartyDetailsBill
    {
        //public string Name { get; set; }
        public SelectList CompanyName { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> MobileNo { get; set; }
        public string GSTN_Number { get; set; }
        public string PanNo { get; set; }
        //public string Registered { get; set; }
    }
}