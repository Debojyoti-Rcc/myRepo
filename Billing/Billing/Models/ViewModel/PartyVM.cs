using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace Billing.Models.ViewModel
{
    public class PartyVM
    {
        public string Name { get; set; }
        [Display(Name="Company Name")]
        [Required(ErrorMessage="This field can not be left blank")]
        public string CompanyName { get; set; }
        public string Address { get; set; }
        [Display(Name="Mobile No")]
        public Nullable<decimal> MobileNo { get; set; }
        [Display(Name="GST Number")]
        public string GSTN_Number { get; set; }
        [Display(Name="Pan Number")]
        public string PanNo { get; set; }
        public List<SelectListItem> Registered { get; set; }
    }

    //public class Option
    //{
    //    public string Value { get; set; }
    //    public string Text { get; set; }
    //}
}