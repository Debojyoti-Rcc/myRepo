using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Billing.Models.ViewModel
{
    public class BillTemplate
    {
        public string Biller { get; set; }
        public string Biller_Address { get; set; }
        public string Biller_GST { get; set; }
        public string BilledTo { get; set; }
        public string BilledTo_GST { get; set; }
        public string BilledTo_Address { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string Quantity { get; set; }
        public string TotalAmount { get; set; }
        public string TaxRate { get; set; }
        public string SGST { get; set; }
        public string CGST { get; set; }
        public string TaxAmount { get; set; }
    }
}