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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["userID"] != null)
                {
                    int userID = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                    LoggedInUser_AdvancedSearch.Attributes.Remove("style");
                    LoginOrSignUp.Attributes.Add("style", "display:none");
                    LoggedInUser_ProfileLink.Attributes.Remove("style");
                    LoggedInUser_MenuBar.Attributes.Remove("style");
                    LoggedInFirstName_MenuBar.Text = getFirstName();
                   
                    List<string> notification = new List<string>();
                    
                    notification = getNotifications();
                    int noOfNotification = notification.Count();

                    if (noOfNotification > 0)
                    {
                        Notificationslabel.Text = noOfNotification + " New Notifications";
                        if (Session["No Of Notification"] == null)
                        {
                            Notificationslabel.ForeColor = System.Drawing.Color.Red;
                            Session["No Of Notification"] = noOfNotification;
                            
                        }
                        else {
                            Notificationslabel.ForeColor = System.Drawing.Color.Green;
                        }
                        

                        foreach (string item in notification)
                        {
                            Label1.Text = Label1.Text + "<br />" + item;
                            //Notifications.Text = Notifications.Text + item;
                        }
                    }
                    else {
                        Notificationslabel.Text = "No New Notifications";
                        Notificationslabel.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        public int getUserID()
        {
            int userID = Convert.ToInt32(HttpContext.Current.Session["userID"]);

            return userID;
        }
        
        protected void SubmitQuickSearch_Click(object sender, EventArgs e)
        {
            string quickSearch = QuickSearch.Text;
            Response.Redirect("QuickSearchDisplay.aspx?quickSearchTerm=" + quickSearch);
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("userID");

            Response.Redirect("Default.aspx");
        }
        protected List<string> getNotifications()
        {
            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            string notifications = "";
            List<string> notifications1 = new List<string>();
            List<string> notifications12 = new List<string>();
            try
            {
                dbConnection.Open();
                string query = "select * from notification where studentID = @uid";
                try
                {
                    SqlCommand getType = new SqlCommand(query, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@uid", uid));
                    SqlDataReader reader = getType.ExecuteReader();
                    string notificationNew = "";
                    string notificationOld = "";
                    if (reader.Read())
                    {

                        if (reader.GetString(1).Equals(null))
                        {
                            notifications = "You have no notification";
                            //notificationNew = "select notification from notification where studentID = @uid";

                        }
                        else
                        {
                            notificationOld = "select notification from notification where studentID = @uid";


                        }

                        reader.Close();
                        try
                        {
                            SqlCommand getName = new SqlCommand(notificationOld, dbConnection);
                            getName.Parameters.Add(new SqlParameter("@uid", uid));
                            SqlDataReader nameReader = getName.ExecuteReader();
                            while (nameReader.Read())
                            {
                             
                                notifications1.Add(nameReader.GetString(0));
                            }
                            nameReader.Close();
                        }

                        catch (SqlException ez)
                        {
                            Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                        }
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
            return notifications1;
            
        }

        protected string getFirstName()
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
    }
}