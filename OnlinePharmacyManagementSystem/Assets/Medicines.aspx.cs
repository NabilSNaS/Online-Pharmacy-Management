using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlinePharmacyManagementSystem.Assets
{
    public partial class Medicines : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowMedicines();
                GetCategories();
               
                
        
            }
           
        }
        private void ShowMedicines()
        {
            string Query = "select * from MedicineTbl";
            MedicineList.DataSource = con.GetData(Query);
            MedicineList.DataBind();
        }

        private void GetCategories()
        {
            string Query = "Select * from CategoryTbl";
            CatTb.DataTextField = con.GetData(Query).Columns["CatName"].ToString();
            CatTb.DataValueField = con.GetData(Query).Columns["CatId"].ToString();
            CatTb.DataSource = con.GetData(Query);
            CatTb.DataBind();
        }

        protected void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MedCodeTb.Value == "")
                {
                    ErrMSg.InnerText = "Missing Data !!";
                }
                else
                {
                    string MCode = MedCodeTb.Value;
                    string MName = MedNameTb.Value;
                    string MPrice = PriceTb.Value;
                    string MStock = QtyTb.Value;
                    string MDate = ExpDate.Value;
                    string MCat = CatTb.SelectedValue.ToString();
                    string Query = "Insert into MedicineTbl values('{0}','{1}','{2}','{3}','{4}','{5}')";
                    Query = string.Format(Query, MCode,MName,MPrice,MStock,MDate,MCat);
                    con.SetData(Query);
                    ShowMedicines();
                    ErrMSg.InnerText = "Medicine Added !!!";
                    MedCodeTb.Value = "";
                    MedNameTb.Value = "";
                    PriceTb.Value = "";
                    QtyTb.Value = "";
                    ExpDate.Value = "";

                }

            }
            catch (Exception Ex)
            {
                ErrMSg.InnerText = Ex.Message;
            }
        }
        string key = "";
        protected void MedicineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = MedicineList.SelectedRow.Cells[1].Text;
            MedNameTb.Value = MedicineList.SelectedRow.Cells[2].Text;
            PriceTb.Value = MedicineList.SelectedRow.Cells[3].Text;
            QtyTb.Value = MedicineList.SelectedRow.Cells[4].Text;
            ExpDate.Value = MedicineList.SelectedRow.Cells[5].Text;
            CatTb.SelectedValue = MedicineList.SelectedRow.Cells[6].Text;
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (MedNameTb.Value == "" || PriceTb.Value ==""  || QtyTb.Value =="")
                {
                    ErrMSg.InnerText = "Missing Data !!";
                }
                else
                {
                    string MCode = MedCodeTb.Value;
                    string MName = MedNameTb.Value;
                    string MPrice = PriceTb.Value;
                    string MStock = QtyTb.Value;
                    string MDate = ExpDate.Value;
                    string MCat = CatTb.SelectedValue.ToString();
                   
                    string Query = "Update MedicineTbl set MedName = '{0}', MedPrice = '{1}', MedStock = '{2}',MedExpDate = '{3}',MedCategory = '{4}' where MedCode = '{5}'";
                    Query = string.Format(Query, MName, MPrice, MStock, MDate, MCat, MedicineList.SelectedRow.Cells[1].Text);
                    con.SetData(Query);
                    ShowMedicines();
                    ErrMSg.InnerText = "Medicine List Updated !!!";
                    MedNameTb.Value = "";
                    PriceTb.Value = "";
                    QtyTb.Value = "";
                    CatTb.SelectedIndex = -1;



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
                if (MedNameTb.Value == "" || PriceTb.Value ==""  || QtyTb.Value =="")
                {
                    ErrMSg.InnerText = "Missing Data !!";
                }
                else
                {
                    string MCode = MedCodeTb.Value;
                    string MName = MedNameTb.Value;
                    string MPrice = PriceTb.Value;
                    string MStock = QtyTb.Value;
                    string MDate = ExpDate.Value;
                    string MCat = CatTb.SelectedValue.ToString();
                   
                    string Query = "Delete from MedicineTbl where MedCode = '{0}'";
                    Query = string.Format(Query, MedicineList.SelectedRow.Cells[1].Text);
                    con.SetData(Query);
                    ShowMedicines();
                    ErrMSg.InnerText = " Deleted Successfully !!!";
                    MedNameTb.Value = "";
                    PriceTb.Value = "";
                    QtyTb.Value = "";
                    CatTb.SelectedIndex = -1;



                }

            }
            catch (Exception Ex)
            {
                ErrMSg.InnerText = Ex.Message;
            }

        }
          
    }
}