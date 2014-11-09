using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                    LoginSuccess.Attributes.Remove("style");
                    LoginSuccess.Attributes.Add("style", "display:none");
                    string user = Username.Text;
                    string pass = Password.Text;
                    bool login = false;
                    SqlConnection dbConnection = new SqlConnection("");
                    try
                    {
                        dbConnection.Open();
                        SqlCommand checkUsername = new SqlCommand("SELECT *username* FROM *table* WHERE *username* = '" + user + "'", dbConnection);
                        SqlDataReader queryReader = checkUsername.ExecuteReader();
                        if (!queryReader.Read())
                        {
                            queryReader.Close();
                            LoginError.Attributes.Remove("style");
                            LoginError.Attributes.Add("style", "display:block");
                            ErrorMessage.Text = "<strong>Error!</strong> Invalid Username / Password Combination!";
                        }
                        else
                        {
                            queryReader.Close();
                            SqlCommand checkLogin = new SqlCommand("SELECT *pwd* FROM *table* WHERE *username* = '" + user + "' and Pwd = '" + pass + "'", dbConnection);
                            queryReader = checkLogin.ExecuteReader();
                            if (!queryReader.Read())
                            {
                                LoginError.Attributes.Remove("style");
                                LoginError.Attributes.Add("style", "display:block");
                                ErrorMessage.Text = "<strong>Error!</strong> Incorrect Username / Password Combination!";
                            }
                            else
                            {
                                LoginSuccess.Attributes.Remove("style");
                                LoginSuccess.Attributes.Add("style", "display:block");
                                SuccessMessage.Text = "<strong>Success!</strong> Login Successful!";
                                login = true;
                            }
                            queryReader.Close();
                            if (login)
                            {
                                /*SqlCommand getName = new SqlCommand("SELECT FirstName, LastName from UserData where Username = '" + user + "'", dbConnection);
                                SqlDataReader readQuery = getName.ExecuteReader();
                                readQuery.Read();
                                Session["id"] = readQuery.GetString(0) + " " + readQuery.GetString(1);
                                readQuery.Close();*/
                                Response.Redirect("Default.aspx");
                            }
                        }
                        dbConnection.Close();
                    }
                    catch (SqlException ex)
                    {
                        Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                    }*/
                }
            }
        }
    }
}