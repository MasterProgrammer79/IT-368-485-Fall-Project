using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU.images
{
    public partial class Unsubscribe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userID = Request.QueryString["userID"];

            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            string updateQuery = "";
            try
            {
                dbConnection.Open();
                string query = "select userType from userDetails where userID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", userID));
                    SqlDataReader reader = getType.ExecuteReader();
                    
                    reader.Read();
                    if (reader.GetString(0).Equals("student"))
                    {
                        updateQuery = "update studentPersonal set emailSubscription=" + 0 + " where userID=" + userID;
                       
                    }
                    else
                    {
                        updateQuery = "update recruiter set emailSubscription=" + 0 + " where userID=" + userID;
                        
                    }

                    
                    reader.Close();


                    try
                    {
                        SqlCommand updateSubscription = new SqlCommand(updateQuery, dbConnection);
                        updateSubscription.ExecuteNonQuery();
                        
                    }
                    catch (SqlException ez)
                    {
                        Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                    }
                }

                catch (SqlException ex)
                {
                    Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                }
                
                dbConnection.Close();
                
            }
            catch (SqlException ez)
            {
                Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
            }
        }
    }
}