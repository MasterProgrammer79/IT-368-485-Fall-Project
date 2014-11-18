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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["userID"] != null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
            this.Form.DefaultButton = this.UserLogin.UniqueID;
        }

        protected void UserLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    LoginError.Attributes.Remove("style");
                    LoginError.Attributes.Add("style", "display:none");
                    string user = Username.Text;
                    string pass = Password.Text;
                    bool login = false;
                    SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
                    try
                    {
                        dbConnection.Open();
                        string userQuery = "select userName from userDetails where userName = @uname";
                        try
                        {
                            SqlCommand checkUsername = new SqlCommand(userQuery, dbConnection);
                            checkUsername.Parameters.Add(new SqlParameter("@uname", user));
                            SqlDataReader queryReader = checkUsername.ExecuteReader();
                            if (!queryReader.Read())
                            {
                                queryReader.Close();
                                LoginError.Attributes.Remove("style");
                                LoginError.Attributes.Add("style", "display:block");
                            }
                            else
                            {
                                queryReader.Close();
                                string passQuery = "select userPassword from userDetails where userName = @uname and userPassword = @upass";
                                try
                                {
                                    SqlCommand checkLogin = new SqlCommand(passQuery, dbConnection);
                                    checkLogin.Parameters.Add(new SqlParameter("@uname", user));
                                    checkLogin.Parameters.Add(new SqlParameter("@upass", pass));
                                    queryReader = checkLogin.ExecuteReader();
                                    if (!queryReader.Read())
                                    {
                                        LoginError.Attributes.Remove("style");
                                        LoginError.Attributes.Add("style", "display:block");
                                    }
                                    else
                                    {
                                        login = true;
                                    }
                                    queryReader.Close();
                                    if (login)
                                    {
                                        string query = "select userID from userDetails where userName = @uname";
                                        try
                                        {
                                            SqlCommand getName = new SqlCommand(query, dbConnection);
                                            getName.Parameters.Add(new SqlParameter("@uname", user));
                                            SqlDataReader readQuery = getName.ExecuteReader();
                                            readQuery.Read();
                                            HttpContext.Current.Session["userID"] = readQuery.GetInt32(0);
                                            readQuery.Close();
                                            Response.Redirect("Default.aspx");
                                        }
                                        catch (SqlException e3)
                                        {
                                            Response.Write("<p>Error Code " + e3.Number + ": " + e3.Message + "</p>");
                                        }
                                    }
                                }
                                catch (SqlException e2)
                                {
                                    Response.Write("<p>Error Code " + e2.Number + ": " + e2.Message + "</p>");
                                }
                            }
                        }
                        catch (SqlException e1)
                        {
                            Response.Write("<p>Error Code " + e1.Number + ": " + e1.Message + "</p>");
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