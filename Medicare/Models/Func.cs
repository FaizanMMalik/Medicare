using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.IO;
using System.Linq;
namespace Medicare.Models
{
    public class Func
    {
        public string ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Zipcode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required(ErrorMessage = "Please enter Manafacturing date")]
        [CustomHireDate(ErrorMessage = "Manafacturing  Date must be less than or equal to Today's Date")]
        [DataType(DataType.Date)]
        public string DOB { get; set; }
        int rowEffected=0;
        string dbConnection = @"Data Source=SQL8001.site4now.net,1433;Initial Catalog=db_a8c5ab_med;User Id=db_a8c5ab_med_admin;Password=password123";
       
        public void Getcred()
        {
            ActionExecutedContext context = new ActionExecutedContext();
            var routeData = context.RouteData;
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];

            var url = $"{controller}/{action}";


            //var user = context.HttpContext.User.Identity.Name;

            var ipAddress = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

            SqlConnection con = new SqlConnection(dbConnection);
            con.Open();
            string query = "INSERT INTO cred(url,ip) VALUES('" + url + "','" + ipAddress + "')";
            SqlCommand cmd = new SqlCommand(query, con);

            rowEffected = cmd.ExecuteNonQuery();

            con.Close();
        }

        public int Insert1(Func a)
        {
           
            SqlConnection con = new SqlConnection(dbConnection);
            con.Open();
            string query = "INSERT INTO Customer(Zipcode) VALUES('"+ a.Zipcode +"')";
            SqlCommand cmd = new SqlCommand(query,con);
           
               rowEffected = cmd.ExecuteNonQuery();
            //SqlCommand cd = new SqlCommand(query, con);
            //cmd.Parameters.AddWithValue("id", a.id);
            con.Close();
           
          
            return rowEffected;
        }
        public void Fetch(Func a)
        {
            SqlConnection con = new SqlConnection(dbConnection);
            con.Open();
            string query = @"SELECT TOP 1 * FROM Customer ORDER BY ID DESC";
            SqlCommand cd = new SqlCommand(query, con);
            SqlDataReader dataReader = cd.ExecuteReader();
            while (dataReader.Read())
            {

                a.ID = Convert.ToString(dataReader[0].ToString());

            }
            con.Close();
        }
        public int Insert2(Func a)
        {
            
            SqlConnection con = new SqlConnection(dbConnection);
            con.Open();
            string query = @"UPDATE dbo.Customer SET  FirstName= '"+a.FirstName+ "', LastName= '" + a.LastName + "' WHERE id ='"+a.ID+"';";
            SqlCommand cmd = new SqlCommand(query, con);
            rowEffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowEffected;
        }

        public int Insert3(Func a)
        {
           
            SqlConnection con = new SqlConnection(dbConnection);
            con.Open();
            string query = @"UPDATE dbo.Customer SET  DOB= '" + a.DOB + "' WHERE id ='" + a.ID + "';";
            SqlCommand cmd = new SqlCommand(query, con);
            rowEffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowEffected;
        }
        public int Insert4(Func a)
        {
           
            SqlConnection con = new SqlConnection(dbConnection);
            con.Open();
            string query = @"UPDATE dbo.Customer SET  PhoneNo= '" + a.PhoneNo + "',Email= '" + a.Email + "' WHERE id ='" + a.ID + "';";
            SqlCommand cmd = new SqlCommand(query, con);
            rowEffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowEffected;
        }
        public List<Func> GetData(String searchBy, String search)
        {
            List<Func> DataList = new List<Func>();
            SqlConnection con = new SqlConnection(dbConnection);
            string query = string.Empty;
            if (!String.IsNullOrEmpty(searchBy))
            {
                query = @"select * from Customer where " + searchBy + " like '%" + search + "%'";
            }
            else
            {
                query = @"select * from Customer";
            }
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                DataList.Add(new Func
                {
                    ID= (dataReader["id"].ToString()),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    Zipcode = Convert.ToInt32(dataReader["Zipcode"].ToString()),
                    Email= dataReader["Email"].ToString(),
                    PhoneNo = dataReader["PhoneNo"].ToString(),
                    DOB = dataReader["DOB"].ToString(),
                });

            }
            con.Close();
            return DataList;
        }
        public int Delete(Int64 id)
        {
            int effectedRows = 0;

            try
            {
                SqlConnection con = new SqlConnection(dbConnection);
                string query = @"delete from Customer where ID='" + id + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(query, con);
                effectedRows = cmd.ExecuteNonQuery();
                con.Close();
                return effectedRows;
            }
            catch (Exception exp)
            {
                return effectedRows;
            }

        }
        public int Update(Func e)
        {
            int RowCount = 0;
            try
            {
                SqlConnection con = new SqlConnection(dbConnection);
                con.Open();
                string query = @"update Customer set FirstName='" + e.FirstName + "',LastName='" + e.LastName + "',Zipcode = '" + e.Zipcode + "',Email= '" + e.Email + "',PhoneNo = '" + e.PhoneNo + "',DOB = '" + e.DOB + "' where ID = '" + e.ID + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                rowEffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowEffected;
        }
            catch (Exception exp)
            {
                return RowCount;
            }
}
        public Func GetSingleFunc(Int64 id)

        {
            Func e = null;
            SqlConnection con = new SqlConnection(dbConnection);
            string query = @"select * from Customer where ID='" + id + "' ";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.Read())
            {
                e = new Func
                {
                    ID = (dataReader["id"].ToString()),
                    FirstName = dataReader["FirstName"].ToString(),
                    LastName = dataReader["LastName"].ToString(),
                    Zipcode = Convert.ToInt32(dataReader["Zipcode"].ToString()),
                    Email = dataReader["Email"].ToString(),
                    PhoneNo = dataReader["PhoneNo"].ToString(),
                    DOB = dataReader["DOB"].ToString(),
                };
            }
            con.Close();
            return e;
        }
        public void Export()
        {
        //    DataTable dt = new DataTable("Grid");
        //    dt.Columns.AddRange(new DataColumn[4] { new DataColumn("CustomerId"),
        //                                    new DataColumn("ContactName"),
        //                                    new DataColumn("City"),
        //                                    new DataColumn("Country") });

        //    var customers = from customer in this.Context.Customers.Take(10)
        //                    select customer;

        //    foreach (var customer in customers)
        //    {
        //        dt.Rows.Add(customer.CustomerID, customer.ContactName, customer.City, customer.Country);
        //    }

        //    using (XLWorkbook wb = new XLWorkbook())
        //    {
        //        wb.Worksheets.Add(dt);
        //        using (MemoryStream stream = new MemoryStream())
        //        {
        //            wb.SaveAs(stream);
        //            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
        //        }
        //    }
        }
    }
}