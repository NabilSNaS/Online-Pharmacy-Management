using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacyManagementSystem.Assets
{
    public partial class Category : System.Web.UI.Page
    {
        Models.Functions con;

        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowCategories();
            }
            
        }                                                                                        

        private void ShowCategories()
        {
            string Query = "select CatId as Number,CatName [Category Names] from CategoryTbl";
            CategoryList.DataSource = con.GetData(Query);
            CategoryList.DataBind();
        }
            
     
        protected void SaveBtn_Click(object sender, EventArgs e)
        {
               try{
                   if (CatNameTb.Value == "")
                   {
                       ErrMSg.InnerText = "Missing Data !!";
                   }
                   else
                   {
                       string CatName = CatNameTb.Value;
                       string Query = "Insert into CategoryTbl values('{0}')";
                       Query = string.Format(Query, CatName);
                       con.SetData(Query);
                       ShowCategories();
                       ErrMSg.InnerText = "Category Added !!!";
                       CatNameTb.Value = "";

                   }

       }
        catch(Exception Ex){
            ErrMSg.InnerText = Ex.Message;
    }
        
           

        }

        protected void CategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatNameTb.Value = CategoryList.SelectedRow.Cells[2].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "")
                {
                    ErrMSg.InnerText = "Missing Data !!";
                }
                else
                {
                    string CatName = CatNameTb.Value;
                    string Query = "Update CategoryTbl set CatName = '{0}' where CatId = '{1}'";
                    Query = string.Format(Query, CatName, CategoryList.SelectedRow.Cells[1].Text);
                    con.SetData(Query);
                    ShowCategories();
                    ErrMSg.InnerText = "Category Updated !!!";
                    CatNameTb.Value = "";

                }

            }
            catch (Exception Ex)
            {
                ErrMSg.InnerText = Ex.Message;
            }
        }

        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatNameTb.Value == "")
                {
                    ErrMSg.InnerText = "Missing Data !!";
                }
                else
                {
                    string CatName = CatNameTb.Value;
                    string Query = "Delete from CategoryTbl where CatId = '{0}'";
                    Query = string.Format(Query, CategoryList.SelectedRow.Cells[1].Text);
                    con.SetData(Query);
                    ShowCategories();
                    ErrMSg.InnerText = "Category Deleted !!!";
                    CatNameTb.Value = "";

                }

            }
            catch (Exception Ex)
            {
                ErrMSg.InnerText = Ex.Message;
            }
        }
    }
}