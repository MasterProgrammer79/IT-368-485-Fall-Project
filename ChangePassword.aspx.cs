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
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string usernameQuery = Request.QueryString["username"];
        }
        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            string newPassword = Password.Text;
            string usernameQuery = Request.QueryString["username"];
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            try
            {
                dbConnection.Open();
                string query = "update userDetails set userPassword = @pass where userName = @uname";
                try
                {
                    SqlCommand passwordUpdate = new SqlCommand(query, dbConnection);
                    passwordUpdate.Parameters.Add(new SqlParameter("@uname", usernameQuery));
                    passwordUpdate.Parameters.Add(new SqlParameter("@pass", newPassword));
                    passwordUpdate.ExecuteNonQuery();

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
            MultiView1.ActiveViewIndex = 1;
            OutputLabel1.Text = "You have succesfully changed your password <br/>  ";
        }
    }
}