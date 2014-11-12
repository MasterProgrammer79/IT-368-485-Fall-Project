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
    public partial class LinkedU : System.Web.UI.MasterPage
    {
        public SqlConnection dbConnection;

        public LinkedU()
        {
            dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["userID"] != null)
                {
                    LoginOrSignUp.Attributes.Add("style", "display:none");
                    LoggedInUser_MenuBar.Attributes.Remove("style");
                    LoggedInFirstName_MenuBar.Text = getFirstName();
                }
            }
        }

        protected void SubmitQuickSearch_Click(object sender, EventArgs e)
        {

        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("userID");
            Response.Redirect("Default.aspx");
        }

        protected string getFirstName()
        {
            string firstname = "";
            try
            {
                dbConnection.Open();
                string query = "select userType from userDetails where userID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", HttpContext.Current.Session["userID"]));
                    SqlDataReader reader = getType.ExecuteReader();
                    string nameQuery = "";
                    if (reader.GetString(0).Equals("student"))
                    {
                        nameQuery = "select firstName from studentPersonal where userID = @uid";
                    }
                    else
                    {
                        nameQuery = "select recruiterName from recruiter where userID = @uid";
                    }
                    reader.Close();
                    try
                    {
                        SqlCommand getName = new SqlCommand(nameQuery, dbConnection);
                        getType.Parameters.Add(new SqlParameter("@uid", HttpContext.Current.Session["userID"]));
                        SqlDataReader nameReader = getName.ExecuteReader();
                        firstname = nameReader.GetString(0);
                        nameReader.Close();
                    }
                    catch (SqlException ez)
                    {
                        Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
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
            return firstname;
        }
    }
}