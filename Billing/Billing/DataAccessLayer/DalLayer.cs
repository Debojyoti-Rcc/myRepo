using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Billing.Models;
namespace Billing.DataAccessLayer
{
    public class DalLayer
    {
        public static BillingEntities entity = new BillingEntities();
        public static List<ColorRate> GetAvailableColor()
        {
            List<ColorRate> colorList = new List<ColorRate>();
            try
            {
                //con = new SqlConnection(ConfigurationManager.ConnectionStrings["BillingEntities"].ToString());
                //SqlCommand cmd = new SqlCommand("select ColorName,ColorValue from ColorRate", con);
                //con.Open();
                //SqlDataAdapter da = new SqlDataAdapter(cmd);
                //da.Fill(dt);
                colorList = (from c in entity.ColorRates select c).ToList();
                
            }
            catch
            {
                
            }
            finally
            {
                
            }
            return colorList;
        }

        public static double GetRate(int noOfColor)
        {
            double result;
            try
            {
                //result = 5.0;
                result = System.Convert.ToDouble((from colorRate in entity.ColorRates where colorRate.ColorValue == noOfColor select colorRate.RatePerThousand).FirstOrDefault());
            }
            catch
            {
                result = 0.0;
            }
            return result;
        }

        public static List<string> GetPartyList()
        {
            List<string> partyList = new List<string>();
            try
            {
                //partyList = (from party in entity.Parties select party.CompanyName).ToList();
                if(partyList == null)
                {
                    partyList.Add("DemoParty1");
                    partyList.Add("DemoParty2");
                }
                partyList.Add("DemoParty1");
                partyList.Add("DemoParty2");
            }
            catch
            {

            }
            return partyList;
        }
        public static Party GetPartyDetails(string companyName)
        {
            try
            {
                //Uncommnt when DB is ready
                //var k = (from party in entity.Parties where party.CompanyName == companyName select party).FirstOrDefault();
                //return (from party in entity.Parties where party.CompanyName == companyName select party).FirstOrDefault();
                Party obj = new Party();
                obj.Address = "Kolkata";
                obj.GSTN_Number = "525252";
                return obj;
            }
            catch
            {
                return null;
            }
        }
    }
}