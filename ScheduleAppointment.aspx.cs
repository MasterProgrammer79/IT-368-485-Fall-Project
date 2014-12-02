using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace LinkedU
{
    public partial class ScheduleAppointment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Request.QueryString["userID"]);
            StudentNameLabel.Text = getToName();
            RecruiterNameLabel.Text = getFromName();
        }
        protected string getFromName()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            string firstname = "";
            try
            {
                dbConnection.Open();
                string query = "select userType from userDetails where userID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string nameQuery = "";
                    reader.Read();
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
                        getName.Parameters.Add(new SqlParameter("@uid", uid));
                        SqlDataReader nameReader = getName.ExecuteReader();
                        nameReader.Read();
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

        protected string getToName()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(Request.QueryString["userID"]);
            string firstname = "";
            try
            {
                dbConnection.Open();
                string query = "select userType from userDetails where userID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string nameQuery = "";
                    reader.Read();
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
                        getName.Parameters.Add(new SqlParameter("@uid", uid));
                        SqlDataReader nameReader = getName.ExecuteReader();
                        nameReader.Read();
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
        protected string getUserEmail()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            string emailID = "";
            try
            {
                dbConnection.Open();
                string query = "select userType from userDetails where userID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string nameQuery = "";
                    reader.Read();
                    if (reader.GetString(0).Equals("student"))
                    {
                        nameQuery = "select studentEmailID from studentPersonal where userID = @uid";
                    }
                    else
                    {
                        nameQuery = "select recruiterEmail from recruiter where userID = @uid";
                    }
                    reader.Close();
                    try
                    {
                        SqlCommand getEmail = new SqlCommand(nameQuery, dbConnection);
                        getEmail.Parameters.Add(new SqlParameter("@uid", uid));
                        SqlDataReader emailReader = getEmail.ExecuteReader();
                        emailReader.Read();
                        emailID = emailReader.GetString(0);
                        emailReader.Close();
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

        protected string getStudentEmail()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(Request.QueryString["userID"]);
            string emailID = "";
            try
            {
                dbConnection.Open();
                string query = "select userType from userDetails where userID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string nameQuery = "";
                    reader.Read();
                    if (reader.GetString(0).Equals("student"))
                    {
                        nameQuery = "select studentEmailID from studentPersonal where userID = @uid";
                    }
                    else
                    {
                        nameQuery = "select recruiterEmail from recruiter where userID = @uid";
                    }
                    reader.Close();
                    try
                    {
                        SqlCommand getEmail = new SqlCommand(nameQuery, dbConnection);
                        getEmail.Parameters.Add(new SqlParameter("@uid", uid));
                        SqlDataReader emailReader = getEmail.ExecuteReader();
                        emailReader.Read();
                        emailID = emailReader.GetString(0);
                        emailReader.Close();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Request.QueryString["userID"]);

            int recruiterUID = Convert.ToInt32(HttpContext.Current.Session["userID"]);

            if (Page.IsValid)
            {
                
                Panel1.Visible = false;
                Panel2.Visible = true;
                string ToStudentName = getToName();
                string FromName = getFromName();
                string fromEmail = getUserEmail();
                string StudentEmailID = getStudentEmail();

                SqlConnection dbConnection = new SqlConnection("Data Source=itksqlexp8;Integrated Security=true");
                int userIDDB;

                // displayed on the page confirmation

                Label1.Text = "<b>Your request for an appointment has been sent, you will be contacted soon!!</b>" +
            "  Please check Your Email Address for Confirmation Email";

                // inserting notification into the database
                dbConnection.Open();
                dbConnection.ChangeDatabase("jemj_Final_Project");

                string SQLString = "SELECT * FROM userDetails WHERE userID=" + "'" + uid + "'";
                SqlCommand checkIDTable = new SqlCommand(SQLString, dbConnection);
                SqlDataReader userIdRecords = checkIDTable.ExecuteReader();
                if (userIdRecords.Read())
                {
                    userIDDB = userIdRecords.GetInt32(0);

                    userIdRecords.Close();


                    string notification = "INSERT INTO notification  VALUES('"
                                  + userIDDB + "', '"
                                  + " You Have Meeting With " + FromName + " at " + Calendar1.SelectedDate.Date.ToShortDateString() + "  " + DropDownList1.SelectedItem.Text +
                                 "'" + ", 'Not'" + ")";

                    SqlCommand notificationFill = new SqlCommand(notification, dbConnection);
                    notificationFill.ExecuteNonQuery();

                }
                userIdRecords.Close();

                string checkSubscription = "SELECT emailSubscription FROM RECRUITER WHERE userID=" + "'" + recruiterUID + "'";
                SqlCommand checkSub = new SqlCommand(checkSubscription, dbConnection);
                SqlDataReader userIdRecords2 = checkSub.ExecuteReader();
                if (userIdRecords2.Read())
                {
                    bool b = userIdRecords2.GetBoolean(0);

                    if (b)
                    {
                        // email to the reruiter
                        MailAddress messageTo = new MailAddress(fromEmail, FromName);
                        MailMessage emailMessage = new MailMessage("linkedu.services@gmail.com", fromEmail);



                        emailMessage.IsBodyHtml = true;
                        string bodyRecruiterEmail = "<html><body><h3>Welcome to Linked U <br />"
                            //
                            + " <br/><br/>You have successfully "
                            + " made an appointment with " + ToStudentName + " on "
                            + Calendar1.SelectedDate.Date.ToShortDateString() + " at " + DropDownList1.SelectedItem.Text
                            //+ " <br />Your First Name:" + fnametxt.Text
                            //+ " <br /><br />Your Last Name:" + lnametxt.Text
                            //+ " <br /><br />Your User ID:" + userIDTxt.Text
                            //+ " <br /><br />Your Email Address:" + emailTxt.Text
                            //+ " <br /><br />Your Password:" + passwordTxt.Text
                            //+ " <br /><br />Your Security Qusetion:" + securityQTxt.Text
                            //+ " <br /><br />Your Security Answer:" + securityATxt.Text
                            //+ "<br /> <br /> <a href='http://localhost:56397/Unsubscribe.aspx?userID=" + uid + "'>Click Here to Unsubscribe ";
                        +"<br /> <br /><a href='http://localhost:56397/Unsubscribe.aspx?userID=" + recruiterUID + "'>Click Here to Unsubscribe</a>"
                           
                            + " <br /> <br /> <br />Thank You."
                            + " <br /> <br />LinkedU</body></html>"
                            + "<br/> <img src=\"cid:mylogo\">";
                        emailMessage.IsBodyHtml = true;

                        AlternateView av1 = AlternateView.CreateAlternateViewFromString(bodyRecruiterEmail, null, System.Net.Mime.MediaTypeNames.Text.Html);
                        string urlImage = System.Web.HttpContext.Current.Server.MapPath("~/images/logo1.png");
                        LinkedResource logo = new LinkedResource(urlImage, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        logo.ContentId = "mylogo";

                        av1.LinkedResources.Add(logo);

                        emailMessage.Body = bodyRecruiterEmail;

                        emailMessage.AlternateViews.Add(av1);

                        emailMessage.Subject = "LinkedU Schedule Appointment Request";

                        SmtpClient smtpClient = new SmtpClient();

                        smtpClient.Send(emailMessage);
                    }
                    else
                    {
                        Response.Write("Recruiter has not subscribed for email !");
                    }
                    
                }
                userIdRecords2.Close();
                string checkSubscriptionStudent = "SELECT emailSubscription FROM studentPersonal WHERE userID=" + "'" + uid + "'";
                SqlCommand checkSubStudent = new SqlCommand(checkSubscriptionStudent, dbConnection);
                SqlDataReader userIdRecords3 = checkSubStudent.ExecuteReader();
                if (userIdRecords3.Read())
                {
                    bool b = userIdRecords3.GetBoolean(0);

                    if (b)
                    {

                        //email to the student


                        MailAddress messageToStudent = new MailAddress(StudentEmailID, ToStudentName);
                        MailMessage emailMessageStudent = new MailMessage("linkedu.services@gmail.com", StudentEmailID);

                        emailMessageStudent.IsBodyHtml = true;

                        string bodyStudentEmail = "<html><body><h3>Welcome to Linked U <br />"
                            //+ "<br/> <img src=\"cid:mylogo\">"
                            + " <br/><br/> " + FromName + " has schedule an appointment with you <br />"
                          + " on "
                            + Calendar1.SelectedDate.Date.ToShortDateString() + "at" + DropDownList1.SelectedItem.Text
                            //+ " <br />Your First Name:" + fnametxt.Text
                            //+ " <br /><br />Your Last Name:" + lnametxt.Text
                            //+ " <br /><br />Your User ID:" + userIDTxt.Text
                            //+ " <br /><br />Your Email Address:" + emailTxt.Text
                            //+ " <br /><br />Your Password:" + passwordTxt.Text
                            //+ " <br /><br />Your Security Qusetion:" + securityQTxt.Text
                            //+ " <br /><br />Your Security Answer:" + securityATxt.Text
                            + "<br /> <br /><a href='http://localhost:56397/Unsubscribe.aspx?userID=" + uid + "'>Click Here to Unsubscribe</a>"
                            + " <br /> <br /> <br />Thank You."
                            + " <br /> <br /><b>LinkedU</b></body></html>" +
                            "<br/> <img src=\"cid:mylogo\">";

                        AlternateView av1 = AlternateView.CreateAlternateViewFromString(bodyStudentEmail, null, System.Net.Mime.MediaTypeNames.Text.Html);
                        string urlImage = System.Web.HttpContext.Current.Server.MapPath("~/images/logo1.png");
                        LinkedResource logo = new LinkedResource(urlImage, System.Net.Mime.MediaTypeNames.Image.Jpeg);
                        logo.ContentId = "mylogo";

                        av1.LinkedResources.Add(logo);



                        emailMessageStudent.AlternateViews.Add(av1);
                        emailMessageStudent.Body = bodyStudentEmail;
                        emailMessageStudent.Subject = "Your Appointment Details";

                        SmtpClient smtpClientStudent = new SmtpClient();
                        smtpClientStudent.Send(emailMessageStudent);
                    }
                    else
                    {
                        Response.Write("Student has not subscribed for email !");
                    }
                    userIdRecords3.Close();
                }
            }
            else
            {
                Response.Write("UserID already Exists, please use another User ID to sign up");
            }
        }
    }
}