using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Billing.Models.ViewModel
{
    public class PaulOffsetBillTemplateVM
    {
        [Display(Name="Number Of Color")]
        public SelectList NoOfColor { get; set; }
        [Display(Name="Charge Per Thousand")]
        public double ChargePerThousand { get; set; }
        public int Quantity { get; set; }
        [Display(Name="Plate Charge")]
        public double PlateCharge { get; set; }

        public double Total { get; set; }
    }
    public class Color
    {
        public string  Name { get; set; }
        public string Value { get; set; }
        public Color(string name,string value)
        {
            this.Name = name;
            this.Value = value;
    }
    }
}