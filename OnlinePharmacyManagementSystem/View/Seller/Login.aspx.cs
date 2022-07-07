using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacyManagementSystem.View.Seller
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
        }
        public static string SName, SEmaill;
        public static int SId;
        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Query = "select Selid,SelName,SelEmail,SelPass from SellerTbl where SelEmail = '{0}' and SelPass = '{1}'";
                Query = string.Format(Query, EmailTb.Value, PasswordTb.Value);
                DataTable dt = con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    ErrMSg.InnerText = "Invalid Seller !";

                }
                else
                {
                    SId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    SName = dt.Rows[0][0].ToString();
                    Response.Redirect("Billing.aspx");


                }
            }
            catch (Exception Ex)
            {
                
                  ErrMSg.InnerText = Ex.Message;
            }
        }
    }
}