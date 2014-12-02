using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["userID"] != null)
            {
                PanelWelcome.Attributes.Add("style", "display:none");
                string requestInfo = getRequest();
                if (requestInfo != "")
                {
                    RequestForInfo.Attributes.Remove("style");
                    RequestLabel.Text = requestInfo;
                }
            }
        }
        protected void accept_Click(object sender, EventArgs e)
        {
            RequestForInfo.Attributes.Remove("style");
            Descritionofrequest.Attributes.Remove("style");

            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            string request = "";

            try
            {
                dbConnection.Open();
                string query = "select * from moreinformation where studentID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string fromUser = "";

                    if (reader.Read())
                    {

                        if (reader.GetString(1).Equals(null))
                        {
                            request = "";
                            //notificationNew = "select notification from notification where studentID = @uid";

                        }
                        else
                        {
                            Description.Text = reader.GetString(1);
                            reader.Close();

                        }

                        reader.Close();

                    }

                    else
                    {

                        reader.Close();

                    }
                }
                catch (SqlException ey)
                {
                    Response.Write("<p>Error Code " + ey.Number + ": " + ey.Message + "</p>");
                }
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            }



        }
        protected void delete_Click(object sender, EventArgs e)
        {
            RequestForInfo.Attributes.Add("style", "display:none");

            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);


            try
            {
                dbConnection.Open();
                string query = "delete from moreinformation where studentID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    getType.ExecuteNonQuery();

                }
                catch (SqlException ey)
                {
                    Response.Write("<p>Error Code " + ey.Number + ": " + ey.Message + "</p>");
                }
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            }


        }
        protected string getRequest()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            string request = "";

            try
            {
                dbConnection.Open();
                string query = "select * from moreinformation where studentID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string fromUser = "";

                    if (reader.Read())
                    {

                        if (reader.GetString(1).Equals(null))
                        {
                            request = "";
                            //notificationNew = "select notification from notification where studentID = @uid";

                        }
                        else
                        {
                            fromUser = reader.GetString(3);
                            request = fromUser + " want some more infromation from you";
                            reader.Close();

                        }

                        reader.Close();
                        //try
                        //{
                        //    SqlCommand getName = new SqlCommand(notificationOld, dbConnection);
                        //    getName.Parameters.Add(new SqlParameter("@uid", uid));
                        //    SqlDataReader nameReader = getName.ExecuteReader();
                        //    while (nameReader.Read())
                        //    {

                        //        notifications1.Add(nameReader.GetString(0));
                        //    }
                        //    nameReader.Close();
                        //}

                        //catch (SqlException ez)
                        //{
                        //    Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                        //}
                    }

                    else
                    {

                        reader.Close();
                        //notifications1.Add("You have no notification");

                    }
                }
                catch (SqlException ey)
                {
                    Response.Write("<p>Error Code " + ey.Number + ": " + ey.Message + "</p>");
                }
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            }
            return request;

        }
    }
}