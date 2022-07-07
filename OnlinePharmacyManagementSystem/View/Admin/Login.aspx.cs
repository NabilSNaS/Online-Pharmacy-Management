using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacyManagementSystem.View.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();

        }
        public static string AdminName, AdminEmaill;
        public static int AdminId;

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
             try
            {
                string Query = "select AdminId,AdminEmail,AdminPass from Admin where AdminEmail = '{0}' and AdminPass = '{1}'";
                Query = string.Format(Query, Email.Value, Pass.Value);
                DataTable dt = con.GetData(Query);
                if (dt.Rows.Count == 0)
                {
                    ErrMSg.InnerText = "Invalid Admin !";

                }
                else
                {
                    AdminId = Convert.ToInt32(dt.Rows[0][0].ToString());
                    AdminName = dt.Rows[0][0].ToString();
                    Response.Redirect("../../Assets/Medicines.aspx");


                }
            }
             catch (Exception Ex)
             {

                 ErrMSg.InnerText = Ex.Message;
             }

        }
    }
}