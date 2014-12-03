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
                        UsernameMessage.Text = "<strong>Username already taken!</strong>";
                        UsernameMessage.ForeColor = Color.Red;
                    }
                    else
                    {
                        UsernameMessage.Text = "<strong>Username is available!</strong>";
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
            UserValidator.Visible = enabled;
            Password.Enabled = enabled;
            PasswordValidator.Visible = enabled;
            ConfirmPassword.Enabled = enabled;
            ComparePasswords.Visible = enabled;
            UserType.Enabled = enabled;
            UserTypeValidator.Visible = enabled;
            AccountType.Enabled = enabled;
            AccountTypeValidator.Visible = enabled;
        }

        private void FirstStudentPanelSwitch(bool enabled)
        {
            StudentFirstName.Enabled = enabled;
            StudentFirstNameValidator.Visible = enabled;
            StudentLastName.Enabled = enabled;
            StudentLastNameValidator.Visible = enabled;
            StudentEmail.Enabled = enabled;
            StudentEmailValidator.Visible = enabled;
            StudentPhone.Enabled = enabled;
            StudentPhoneValidator.Visible = enabled;
            StudentAddress.Enabled = enabled;
            StudentAddressValidator.Visible = enabled;
            StudentCity.Enabled = enabled;
            StudentCityValidator.Visible = enabled;
            StudentState.Enabled = enabled;
            StudentStateValidator.Visible = enabled;
            StudentZip.Enabled = enabled;
            StudentZipValidator.Visible = enabled;
        }

        private void SecondStudentPanelSwitch(bool enabled)
        {
            /*
            StudentSchoolValidator.Visible = enabled;
            StudentMajorValidator.Visible = enabled;
            StudentGPAValidator.Visible = enabled;
            StudentACTValidator.Visible = enabled;
             */
        }

        private void RecruiterPanelSwitch(bool enabled)
        {
            RecruiterFirstName.Enabled = enabled;
            RecruiterFirstNameValidator.Visible = enabled;
            RecruiterLastName.Enabled = enabled;
            RecruiterLastNameValidator.Visible = enabled;
            RecruiterEmail.Enabled = enabled;
            RecruiterEmailValidator.Visible = enabled;
        }

        protected void CreateAccountInfo_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    HttpContext.Current.Session.Add("pass", Password.Text);
                    FirstPanelSwitch(false);
                    if (UserType.SelectedValue.Equals("student"))
                    {
                        ActivateStudentPanel.Attributes.Remove("style");
                        ActivateStudentPanel.Attributes.Add("style", "display:block");
                        FirstStudentPanelSwitch(true);
                    }
                    else
                    {
                        ActivateRecruiterPanel.Attributes.Remove("style");
                        ActivateRecruiterPanel.Attributes.Add("style", "display:block");
                        RecruiterPanelSwitch(true);
                    }
                    Password.Attributes.Add("value", Password.Text);
                    ConfirmPassword.Attributes.Add("value", Password.Text);
                }
            }
        }

        protected void EditPreviousInfo_Click(object sender, EventArgs e)
        {
            FirstPanelSwitch(true);
            Password.Attributes.Add("value", HttpContext.Current.Session["pass"].ToString());
            ConfirmPassword.Attributes.Add("value", HttpContext.Current.Session["pass"].ToString());
            HttpContext.Current.Session.Remove("pass");
            if (UserType.SelectedValue.Equals("student"))
            {
                ActivateStudentPanel.Attributes.Remove("style");
                ActivateStudentPanel.Attributes.Add("style", "display:none");
                FirstStudentPanelSwitch(false);
            }
            else
            {
                ActivateRecruiterPanel.Attributes.Remove("style");
                ActivateRecruiterPanel.Attributes.Add("style", "display:none");
                RecruiterPanelSwitch(false);
            }
        }

        protected void NextStudentStep_Click(object sender, EventArgs e)
        {
            /*
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    FirstStudentPanelSwitch(false);
                    ActivateStudentPanel2.Attributes.Remove("style");
                    ActivateStudentPanel2.Attributes.Add("style", "display:block");
                    SecondStudentPanelSwitch(true);
                }
            }
             */
        }

        protected void EditStudentStep_Click(object sender, EventArgs e)
        {
            /*
            SecondStudentPanelSwitch(false);
            ActivateStudentPanel2.Attributes.Remove("style");
            ActivateStudentPanel2.Attributes.Add("style", "display:none");
            FirstStudentPanelSwitch(true);
             */
        }

        private int getUserID(string username)
        {
            int uid = 0;
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            try
            {
                dbConnection.Open();
                try
                {
                    SqlCommand getUser = new SqlCommand("select userID from userDetails where userName = @uname", dbConnection);
                    getUser.Parameters.Add(new SqlParameter("@uname", username));
                    SqlDataReader reader = getUser.ExecuteReader();
                    if (reader.Read())
                    {
                        uid = reader.GetInt32(0);
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                }
                dbConnection.Close();
            }
            catch (SqlException ex)
            {
                Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            }
            return uid;
        }

        protected void CreateNewStudent_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
                    try
                    {
                        dbConnection.Open();
                        string newUserQuery = "insert into userDetails values (@uname, @upass, @utype, @acct)";
                        try
                        {
                            SqlCommand addNewUser = new SqlCommand(newUserQuery, dbConnection);
                            addNewUser.Parameters.Add(new SqlParameter("@uname", Username.Text));
                            addNewUser.Parameters.Add(new SqlParameter("@upass", HttpContext.Current.Session["pass"]));
                            addNewUser.Parameters.Add(new SqlParameter("@utype", UserType.SelectedValue.ToString()));
                            addNewUser.Parameters.Add(new SqlParameter("@acct", AccountType.SelectedValue.ToString()));
                            addNewUser.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                        }
                        int uid = getUserID(Username.Text);
                        string newStudentQuery = "insert into studentPersonal values (@uid, @fname, @lname, @email, @phone, @address, @state, @city, @zip, @subscribe)";
                        try
                        {
                            SqlCommand addNewStudent = new SqlCommand(newStudentQuery, dbConnection);
                            addNewStudent.Parameters.Add(new SqlParameter("@uid", uid));
                            addNewStudent.Parameters.Add(new SqlParameter("@fname", StudentFirstName.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@lname", StudentLastName.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@email", StudentEmail.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@phone", StudentPhone.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@address", StudentAddress.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@state", StudentState.SelectedValue.ToString()));
                            addNewStudent.Parameters.Add(new SqlParameter("@city", StudentCity.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@zip", StudentZip.Text));
                            addNewStudent.Parameters.Add(new SqlParameter("@subscribe", 1));
                            addNewStudent.ExecuteNonQuery();
                            HttpContext.Current.Session["userID"] = uid;
                            Response.Redirect("Default.aspx");
                        }
                        catch (SqlException ex)
                        {
                            Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                        }
                        dbConnection.Close();
                    }
                    catch (SqlException ex)
                    {
                        Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                    }
                }
            }
        }

        protected void CreateNewRecruiter_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
                    try
                    {
                        dbConnection.Open();
                        string newUserQuery = "insert into userDetails values (@uname, @upass, @utype, @acct)";
                        try
                        {
                            SqlCommand addNewUser = new SqlCommand(newUserQuery, dbConnection);
                            addNewUser.Parameters.Add(new SqlParameter("@uname", Username.Text));
                            addNewUser.Parameters.Add(new SqlParameter("@upass", HttpContext.Current.Session["pass"]));
                            addNewUser.Parameters.Add(new SqlParameter("@utype", UserType.SelectedValue.ToString()));
                            addNewUser.Parameters.Add(new SqlParameter("@acct", AccountType.SelectedValue.ToString()));
                            addNewUser.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                        }
                        int uid = getUserID(Username.Text);
                        string newRecruiterQuery = "insert into recruiter values (@uid, @fname, @lname, @email, @subscribe)";
                        try
                        {
                            SqlCommand addNewRecruiter = new SqlCommand(newRecruiterQuery, dbConnection);
                            addNewRecruiter.Parameters.Add(new SqlParameter("@uid", uid));
                            addNewRecruiter.Parameters.Add(new SqlParameter("@fname", RecruiterFirstName.Text));
                            addNewRecruiter.Parameters.Add(new SqlParameter("@lname", RecruiterLastName.Text));
                            addNewRecruiter.Parameters.Add(new SqlParameter("@email", RecruiterEmail.Text));
                            addNewRecruiter.Parameters.Add(new SqlParameter("@subscribe", 1));
                            addNewRecruiter.ExecuteNonQuery();
                            HttpContext.Current.Session["userID"] = uid;
                            Response.Redirect("Default.aspx");
                        }
                        catch (SqlException ex)
                        {
                            Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                        }
                        dbConnection.Close();
                    }
                    catch (SqlException ex)
                    {
                        Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                    }
                }
            }
        }
    }
}