using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace OnlinePharmacyManagementSystem.Models
{       
    public class Functions

    {
        private SqlConnection con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConString;

        public Functions()
        {
            ConString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Programming LAB PSTU\documents\visual studio 2013\Projects\OnlinePharmacyManagementSystem\OnlinePharmacyManagementSystem\App_Data\OnlineQuickDB.mdf;Integrated Security=True";
            con = new SqlConnection(ConString);
            cmd = new SqlCommand();
            cmd.Connection = con;
        }
        public DataTable GetData(String Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConString);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int cnt = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.CommandText = Query;
            cnt = cmd.ExecuteNonQuery();
            con.Close();
            return cnt;
        }
    }
}