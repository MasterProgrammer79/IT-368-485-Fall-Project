using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class LostPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.IsPostBack)
            //{
            //    if (HttpContext.Current.Session["userID"] != null)
            //    {
            //        Response.Redirect("Default.aspx");
            //    }
            //}
            //this.Form.DefaultButton = this.UserLogin.UniqueID;
        }
        protected void UserLogin_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            string UserName = getUserName();
            string UserEmail = getUserEmail();
            if (Username.Text == getUserName() && getUserEmail()!="")
            {
                //email to user
                MailAddress messageTo = new MailAddress(UserEmail);
                MailMessage emailMessage = new MailMessage("linkedu.services@gmail.com", UserEmail);



                emailMessage.IsBodyHtml = true;
                string bodyRecruiterEmail = "<html><body><h3>Welcome to Linked U <br />"
                    //
                    + " <br/><br/>You have successfully "
                    + " made an rewuest to change your password please click the link below to reset your password <br/> " +
     "<a href=\"http://localhost:56397/ChangePassword.aspx?username=" + UserName + "\">Click</a>"
               
                    + " <br /> <br /> <br />Thank You."
                    + " <br /> <br />LinkedU</body></html>"
                    + "<br/> <img src=\"cid:mylogo\">";
                emailMessage.IsBodyHtml = true;

                AlternateView av1 = AlternateView.CreateAlternateViewFromString(bodyRecruiterEmail, null, System.Net.Mime.MediaTypeNames.Text.Html);
                string urlImage = System.Web.HttpContext.Current.Server.MapPath("~/logo.png");
                LinkedResource logo = new LinkedResource(urlImage, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                logo.ContentId = "mylogo";

                av1.LinkedResources.Add(logo);

                emailMessage.Body = bodyRecruiterEmail;

                emailMessage.AlternateViews.Add(av1);

                emailMessage.Subject = "LinkedU Schedule Appointment Request";

                SmtpClient smtpClient = new SmtpClient();

                smtpClient.Send(emailMessage);

                OutputLabel.Text = "We have sent you a link to your email address to change your password<br/> Please check your email";
            }
            else
            {
                LoginError.Attributes.Remove("style");
                LoginError.Attributes.Add("style", "display:block");
            }
        }
        protected string getUserEmail()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            
            string username = getUserName();
            string emailID = "";
            int uid = 0;
            try
            {
                dbConnection.Open();
                string query = "select * from userDetails where userName = @uname";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uname", username));
                    SqlDataReader reader = getType.ExecuteReader();
                    string nameQuery = "";
                    if (reader.Read())
                    {
                        if (reader.GetString(3).Equals("student"))
                        {
                            uid = reader.GetInt32(0);
                            nameQuery = "select studentEmailID from studentPersonal where userID = @uid";
                            reader.Close();
                        }
                        else
                        {
                            uid = reader.GetInt32(0);
                            nameQuery = "select recruiterEmail from recruiter where userID = @uid";
                            reader.Close();
                        }
                    }
                    reader.Close();
                    try
                    {
                        if(uid!=0)
                        {
                        SqlCommand getEmail = new SqlCommand(nameQuery, dbConnection);
                        getEmail.Parameters.Add(new SqlParameter("@uid", uid));
                        SqlDataReader emailReader = getEmail.ExecuteReader();
                        emailReader.Read();
                        emailID = emailReader.GetString(0);
                        emailReader.Close();
                    }
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
            return emailID;
        }
        protected string getUserName()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
 
            string usernameDB = "";
            string username = Username.Text;
            try
            {
                dbConnection.Open();
                string query = "select userName from userDetails where userName = @uname";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uname", username));
                    SqlDataReader reader = getType.ExecuteReader();
              
                    if (reader.Read()) 
                    {
                        usernameDB = reader.GetString(0);
                        reader.Close();
                    }
                   
                    reader.Close();
                    
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
            return usernameDB;
        }
    }
}