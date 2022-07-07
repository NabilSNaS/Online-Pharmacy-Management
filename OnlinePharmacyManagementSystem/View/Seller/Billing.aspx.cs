using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.IO;


namespace OnlinePharmacyManagementSystem.View.Seller
{
    public partial class Billing : System.Web.UI.Page
    {
        Models.Functions con;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new Models.Functions();
            if (!IsPostBack)
            {
                ShowMedicines();
                
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[5]
                    {
                        new DataColumn("ID"),
                        new DataColumn("Product"),
                        new DataColumn("Price"),
                        new DataColumn("Quantity"),
                        new DataColumn("Total"),
                    });
                ViewState["Bill"] = dt;
                this.BindGrid();          
              
            }
        }

        protected void BindGrid()
        {
            BillGV.DataSource = (DataTable)ViewState["Bill"];
            BillGV.DataBind();
        }
       
        private void ShowMedicines()
        {
            string Query = "select MedCode as Code,MedName as Medicine,MedPrice as Price,MedStock as Stock from MedicineTbl";
            MedicinesList.DataSource = con.GetData(Query);
            MedicinesList.DataBind();
        }
        string MCode = "";
        int Stock;
        protected void MedicinesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MCode = MedicinesList.SelectedRow.Cells[1].Text;
            MedNameTb.Value = MedicinesList.SelectedRow.Cells[2].Text;
            MedPriceTb.Value = MedicinesList.SelectedRow.Cells[3].Text;
            Stock = Convert.ToInt32(MedicinesList.SelectedRow.Cells[4].Text);
      
        }
        int Seller = Login.SId;
        private void insertBill()
        {
            try
            {
                string Query = "Insert into BillingTbl values('{0}','{1}','{2}')";
                Query = string.Format(Query, BillingDate.Value,Seller,Amount);
                con.SetData(Query);
                ErrMSg.InnerText = "Bill Inserted.";
            }
            catch (Exception Ex)
            {

                ErrMSg.InnerText = Ex.Message;
            }
        }

        private void UpdateStock()
        {
            int newQty;
            newQty = Convert.ToInt32(MedicinesList.SelectedRow.Cells[4].Text) - Convert.ToInt32(MedQtyTb.Value);
            string Query = "Update MedicineTbl set MedStock = '{0}' where MedCode = '{1}'";
            Query = string.Format(Query, newQty, MedicinesList.SelectedRow.Cells[1].Text);
            con.SetData(Query);
            ShowMedicines();
          

        }

        int GrdTotal=0;
        public static  int Amount;
        protected void AddBtn_Click(object sender, EventArgs e)
        {
            if (MedNameTb.Value == "" || MedPriceTb.Value == "" || MedQtyTb.Value == "")
            {
                ErrMSg.InnerText = "Missing Information!!!";
            }
            else
            {
                 int Total = Convert.ToInt32(MedPriceTb.Value) * Convert.ToInt32(MedQtyTb.Value);
                 DataTable dt = (DataTable)ViewState["Bill"];
                dt.Rows.Add(BillGV.Rows.Count + 1,
                MedNameTb.Value.Trim(),
                MedPriceTb.Value.Trim(),
                MedQtyTb.Value.Trim(),
                Total
                );
            ViewState["Bill"] = dt;
            this.BindGrid();
            UpdateStock();
            ErrMSg.InnerText = "Medicine Added To Bill.";


            GrdTotal = 0;
            for (int i = 0; i <= BillGV.Rows.Count - 1; i++)
            {
                GrdTotal = GrdTotal + Int32.Parse(BillGV.Rows[i].Cells[4].Text);
            }
            Amount = GrdTotal;
            GridTotTb.InnerText = "Total: " + GrdTotal + "TK." ;
            MedNameTb.Value = "";
            MedPriceTb.Value = "";
            MedQtyTb.Value = "";
            BillingDate.Value = "";
           

                   

            }
           
        }

      
        protected void ResetBtn_Click(object sender, EventArgs e)
        {
            MedNameTb.Value = "";
            MedPriceTb.Value = "";
            MedQtyTb.Value = "";
            BillingDate.Value = "";
        }

        protected void PrintBtn_Click(object sender, EventArgs e)
        {
            insertBill();
           

        }

        protected void ClearBtn_Click(object sender, EventArgs e)
        {
            BillGV.DataSource = null;
            BillGV.DataBind();
            GridTotTb.InnerText = "";
        }
        

    }
}