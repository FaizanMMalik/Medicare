using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Medicare.Models
{
    public class adminlogin
    {
       
        int rowEffected;
        string dbConnection = @"Data Source=SQL8001.site4now.net,1433;Initial Catalog=db_a8c5ab_med;User Id=db_a8c5ab_med_admin;Password=password123";
        public Boolean ValidAdm(string username, string Password)
        {
            Boolean isValid = false;
            try
            {
                SqlConnection con = new SqlConnection(dbConnection);
                string query = @"Select * from dbo.AdminLogin where username=@username and Password =@Password ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@Password", Password);
                con.Open();
                SqlDataReader dataReader1 = cmd.ExecuteReader();
                if (dataReader1.Read())
                {
                    isValid = true;
                }
                con.Close();
                 }
            catch (Exception exp)
            {

            }
            return isValid;
        }
    }
}