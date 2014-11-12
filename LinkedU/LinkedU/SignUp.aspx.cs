using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Username_TextChanged(object sender, EventArgs e)
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            try
            {
                dbConnection.Open();
                string query = "select userName from userDetails where userName = @uname";
                try
                {
                    SqlCommand checkUsernames = new SqlCommand(query, dbConnection);
                    checkUsernames.Parameters.Add(new SqlParameter("@uname", Username.Text));
                    SqlDataReader reader = checkUsernames.ExecuteReader();
                    if (reader.Read())
                    {
                        UsernameMessage.Text = "Username already taken!";
                        UsernameMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        UsernameMessage.Text = "Username is available!";
                        UsernameMessage.ForeColor = Color.Green;
                    }
                    reader.Close();
                }
                catch (SqlException ez)
                {
                    Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                }
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            }
        }

        private void FirstPanelSwitch(bool enabled)
        {
            Username.Enabled = enabled;
            Password.Enabled = enabled;
            ConfirmPassword.Enabled = enabled;
            //UserType.Enabled = enabled;
            AccountType.Enabled = enabled;
        }

        protected void CreateAccountInfo_Click(object sender, EventArgs e)
        {
            //Response.Write("<p>" + UserType.SelectedValue + "</p>");
            FirstPanelSwitch(false);
            /*if (UserType.SelectedValue.Equals("student"))
            {
                ActivateStudentPanel1.Attributes.Remove("style");
                ActivateStudentPanel1.Attributes.Add("style", "display:block");
            }
            else
            {
                ActivateRecruiterPanel.Attributes.Remove("style");
                ActivateRecruiterPanel.Attributes.Add("style", "display:block");
            }*/
        }

        protected void EditPreviousInfo_Click(object sender, EventArgs e)
        {
            FirstPanelSwitch(true);
            /*if (UserType.SelectedValue.Equals("student"))
            {
                ActivateStudentPanel1.Attributes.Remove("style");
                ActivateStudentPanel1.Attributes.Add("style", "display:none");
            }
            else
            {
                ActivateRecruiterPanel.Attributes.Remove("style");
                ActivateRecruiterPanel.Attributes.Add("style", "display:none");
            }*/
        }

        protected void NextStudentStep_Click(object sender, EventArgs e)
        {

        }

        protected void EditStudentStep_Click(object sender, EventArgs e)
        {

        }

        protected void CreateNewStudent_Click(object sender, EventArgs e)
        {

        }

        protected void CreateNewRecruiter_Click(object sender, EventArgs e)
        {

        }
    }
}