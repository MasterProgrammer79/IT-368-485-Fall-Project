using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class UserViewProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["userID"] != null)
                {
                    userName.Text = getFirstName();
                    string connStr = ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                    SqlConnection dbConnection = new SqlConnection(connStr);

                    int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                    dbConnection.Open();
                    string getImagePath = "select ImageFilePath from userImageTable where userID=@userID";
                    SqlCommand sqlCommandgetPath = new SqlCommand(getImagePath, dbConnection);
                    sqlCommandgetPath.Parameters.Add(new SqlParameter("@userID", uid));
                    SqlDataReader reader = sqlCommandgetPath.ExecuteReader();
                    if (reader.Read())
                    {
                        string filePath = "~/" + reader.GetString(0);
                        ImagePreview.ImageUrl = filePath;
                        reader.Close();

                    }

                    string nameQuery = "select studentEmailID, studentPhone, studentAddress, studentState, studentCity, studentZip from studentPersonal where userID = @userID";
                    SqlCommand sqlCommanduserPersonal = new SqlCommand(nameQuery, dbConnection);
                    sqlCommanduserPersonal.Parameters.Add(new SqlParameter("@userID", uid));
                    SqlDataReader readRecords2 = sqlCommanduserPersonal.ExecuteReader();
                    if (readRecords2.Read())
                    {
                        string emailaddress = readRecords2.GetString(0).ToString();
                        string phone = readRecords2.GetString(1).ToString();
                        string address = readRecords2.GetString(2).ToString();
                        string state = readRecords2.GetString(3).ToString();
                        string city = readRecords2.GetString(4).ToString();
                        string zip = readRecords2.GetString(5).ToString();
                        emailIdlbl.Text = emailaddress;
                        PhoneLbl.Text = phone;
                        citylbl.Text = city +","+state+"-"+zip;
                        readRecords2.Close();

                    }

                    string ProfessionalInfo = "select major, summary, pschoolName, fieldOfStudy, minor from studentProfessional where userID = @userID";
                    SqlCommand sqlCommanduserProfessional = new SqlCommand(ProfessionalInfo, dbConnection);
                    sqlCommanduserProfessional.Parameters.Add(new SqlParameter("@userID", uid));
                    SqlDataReader readRecords3 = sqlCommanduserProfessional.ExecuteReader();
                    if (readRecords3.Read() && readRecords3.GetString(0).ToString() != null)
                    {
                        readRecords2.Close();
                        string major = readRecords3.GetString(0).ToString();
                        string summary = readRecords3.GetString(1).ToString();
                        string pschoolName = readRecords3.GetString(2).ToString();
                        string fieldOfStudy = readRecords3.GetString(3).ToString();
                        string minor = readRecords3.GetString(4).ToString();
                        majorlbl.Text = major;
                        summarylbl.Text = summary;
                        schoolname.Text = pschoolName;
                        fieldofstudylbl.Text = fieldOfStudy;
                        minorlbl.Text = minor;
                        readRecords3.Close();

                    }
                    else {
                        readRecords3.Close();
                    }

                    string ScoreInfo = "select ACT, SAT, PSAT, GPA, skill from studentScore where userID = @userID";
                    SqlCommand sqlCommanduserScore = new SqlCommand(ScoreInfo, dbConnection);
                    sqlCommanduserScore.Parameters.Add(new SqlParameter("@userID", uid));
                    SqlDataReader readRecords4 = sqlCommanduserScore.ExecuteReader();
                    if (readRecords4.Read() && readRecords4.GetInt32(0).ToString() != null)
                    {
                        readRecords3.Close();
                        string act = readRecords4.GetInt32(0).ToString();
                        string sat = readRecords4.GetInt32(1).ToString();
                        string psat = readRecords4.GetInt32(2).ToString();
                        string gpa = readRecords4.GetInt32(3).ToString();
                        string skill = readRecords4.GetString(4).ToString();
                        actlbl.Text = act;
                        satlbl.Text = sat;
                        psatlbl.Text = psat;
                        gpalbl.Text = gpa;
                        skilllbl.Text = skill;
                        readRecords4.Close();

                    }
                    else {
                        readRecords4.Close();
                    }

                }
            }

        }

        public int getuserID()
        {
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            return uid;
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
                        nameQuery = "select firstName, lastName from studentPersonal where userID = @uid";
                    }
                    else
                    {
                        nameQuery = "select recruiterName, recruiterLastName from recruiter where userID = @uid";
                    }
                    reader.Close();
                    try
                    {
                        SqlCommand getName = new SqlCommand(nameQuery, dbConnection);
                        getName.Parameters.Add(new SqlParameter("@uid", uid));
                        SqlDataReader nameReader = getName.ExecuteReader();
                        nameReader.Read();
                        firstname = nameReader.GetString(0).ToUpper() + " " + nameReader.GetString(1).ToUpper();
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