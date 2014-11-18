using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Configuration;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace LinkedU
{
    public partial class UserProfile : System.Web.UI.Page
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
                   string filePath = "~/"+reader.GetString(0);
                   ImagePreview.ImageUrl = filePath;

                }
                   
                }
            }
        }

        public int getuserID()
        {
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            return uid;
        }

        private string GetYouTubeID(string youTubeUrl)
        {
            //RegEx to Find YouTube ID
            Match regexMatch = Regex.Match(youTubeUrl, "^[^v]+v=(.{11}).*",
                               RegexOptions.IgnoreCase);
            if (regexMatch.Success)
            {
                return "http://www.youtube.com/v/" + regexMatch.Groups[1].Value +
                       "&hl=en&fs=1";
            }
            return youTubeUrl;
        }

        protected void btnAddLink_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDB"].ToString());
            string url = TextBox1.Text;
            if (url.Contains("youtube.com"))
            {
                string ytFormattedUrl = GetYouTubeID(url);
                int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                if (!CheckDuplicate(ytFormattedUrl))
                {
                   
                    SqlCommand cmd = new SqlCommand("INSERT INTO YouTubeVideos (userID,[url]) VALUES ("+uid+",'" + ytFormattedUrl + "')", con);
                    using (con)
                    {
                        con.Open();
                        int result = cmd.ExecuteNonQuery();
                        if (result != -1)
                        {
                            Repeater1.DataBind();
                        }
                        else { Response.Write("Error inserting new url!"); }
                    }
                }
                else { Response.Write("This video already exists in our database!"); }
            }
            else
            {
                Response.Write("This URL is not a valid YOUTUBE video link because it does not contain youtube.com in it");
            }
        }

        public bool CheckDuplicate(string youTubeUrl)
        {
            bool exists = false;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ProjectDB"].ToString());
            SqlCommand cmd = new SqlCommand(String.Format("select * from YouTubeVideos where url='{0}'", youTubeUrl), con);

            using (con)
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                exists = (dr.HasRows) ? true : false;
            }

            return exists;
        }

        protected void saveButtonStep1_Click(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connStr);
            int uidDB=0;
            int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                dbConnection.Open();
                string checkUserID = "select userID from studentProfessional where userID=@userID";
                SqlCommand sqlCommandCheck = new SqlCommand(checkUserID, dbConnection);
                sqlCommandCheck.Parameters.Add(new SqlParameter("@userID", uid));
                SqlDataReader reader = sqlCommandCheck.ExecuteReader();
                if (reader.Read())
                {
                    uidDB = reader.GetInt32(0);
                    reader.Close();
                    string updateuserInfo = "UPDATE studentProfessional set summary=@summary, pschoolName=@schoollName,fieldOfStudy=@fieldOfStudy, major=@major,minor=@minor where userID=" +uid;
                    SqlCommand sqlCommand = new SqlCommand(updateuserInfo, dbConnection);
                    sqlCommand.Parameters.AddWithValue("@summary", summaryTxt.Text);
                    sqlCommand.Parameters.AddWithValue("@schoollName", schoolName.Text);
                    sqlCommand.Parameters.AddWithValue("@fieldOfStudy", fieldOfStudy.Text);
                    sqlCommand.Parameters.AddWithValue("@major", major.Text);
                    sqlCommand.Parameters.AddWithValue("@minor", minor.Text);
                    sqlCommand.ExecuteNonQuery();
                    saveStatus.Text = "Your profile has been updated successfully";
                }
                else{
                    reader.Close();
                    string userInfo = "INSERT INTO studentProfessional (userID, major, summary, pschoolName, fieldOfStudy, minor) VALUES(@userID, @summary, @schoollName,@fieldOfStudy,@major,@minor)";
                    SqlCommand sqlCommand = new SqlCommand(userInfo, dbConnection);
                    sqlCommand.Parameters.AddWithValue("@userID", uid);
                    sqlCommand.Parameters.AddWithValue("@summary", summaryTxt.Text);
                    sqlCommand.Parameters.AddWithValue("@schoollName", schoolName.Text);
                    sqlCommand.Parameters.AddWithValue("@fieldOfStudy", fieldOfStudy.Text);
                    sqlCommand.Parameters.AddWithValue("@major", major.Text);
                    sqlCommand.Parameters.AddWithValue("@minor", minor.Text);
                    sqlCommand.ExecuteNonQuery();
                    saveStatus.Text = "Your profile has been saved successfully";
                    saveStatus.Font.Bold = true;
                    
                }
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
                        firstname = nameReader.GetString(0).ToUpper()+ " " + nameReader.GetString(1).ToUpper();
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

                 protected void NextButton1_Click(object sender, EventArgs e)
                 {
                     OtherInfoPanel.Attributes.Remove("style");
                     OtherInfoPanel.Attributes.Add("style", "display:block");
                 }

                 protected void NextButton2_Click(object sender, EventArgs e)
                 {
                     educationInformation.Attributes.Remove("style");
                     educationInformation.Attributes.Add("style", "display:block");
                 }

                 protected void saveOtherInfobtn_Click(object sender, EventArgs e)
                 {
                     string connStr = ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                     SqlConnection dbConnection = new SqlConnection(connStr);
                     int uidDB = 0;
                     int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                     dbConnection.Open();
                     string checkUserID = "select userID from studentScore where userID=@userID";
                     SqlCommand sqlCommandCheck = new SqlCommand(checkUserID, dbConnection);
                     sqlCommandCheck.Parameters.Add(new SqlParameter("@userID", uid));
                     SqlDataReader reader = sqlCommandCheck.ExecuteReader();
                     if (reader.Read())
                     {
                         uidDB = reader.GetInt32(0);
                         reader.Close();
                         string updateuserInfo = "UPDATE studentScore set ACT=@act, SAT=@sat, PSAT=@psat, GPA=@gpa, skill=@skill where userID=" + uid;
                         //string updateuserInfoScore = "UPDATE studentScore set ACT=@act, SAT=@sat, PSAT=@psat where userID=" + uid;
                         SqlCommand sqlCommand = new SqlCommand(updateuserInfo, dbConnection);
                         sqlCommand.Parameters.AddWithValue("@act", actScoreTxt.Text);
                         sqlCommand.Parameters.AddWithValue("@sat", satScoreTxt.Text);
                         sqlCommand.Parameters.AddWithValue("@psat", psatScoreTxt.Text);
                         sqlCommand.Parameters.AddWithValue("@gpa", gpaTxt.Text);
                         sqlCommand.Parameters.AddWithValue("@skill", skillsTxt.Text);
                         sqlCommand.ExecuteNonQuery();
                         savestatus2.Text = "Your profile has been updated successfully";
                         savestatus2.Font.Bold = true;
                      
                       }
                       else {
                           reader.Close();
                           string userScoreInfo = "INSERT INTO studentScore (userID,ACT, SAT, PSAT, GPA, skill) VALUES(@userID, @act, @sat, @psat, @gpa, @skill)";
                           SqlCommand sqlCommandScore = new SqlCommand(userScoreInfo, dbConnection);
                           sqlCommandScore.Parameters.AddWithValue("@userID", uid);
                           sqlCommandScore.Parameters.AddWithValue("@act", actScoreTxt.Text);
                           sqlCommandScore.Parameters.AddWithValue("@sat", satScoreTxt.Text);
                           sqlCommandScore.Parameters.AddWithValue("@psat", psatScoreTxt.Text);
                         sqlCommandScore.Parameters.AddWithValue("@gpa", gpaTxt.Text);
                         sqlCommandScore.Parameters.AddWithValue("@skill", skillsTxt.Text);
                           sqlCommandScore.ExecuteNonQuery();
                           savestatus2.Text = "Your profile has been saved successfully";
                           savestatus2.Font.Bold = true;
                       }
                         
                     }
                     
                     
                 

                 protected void choosePhoto_Click(object sender, EventArgs e)
                 {
                     Session["ImageBytes"] = PhotoUpload.FileBytes;
                     ImagePreview.ImageUrl = "~/ImageHandler.ashx";
                     if (PhotoUpload.HasFile)
                     {
                         // Get the file extension
                         string fileExtension = System.IO.Path.GetExtension(PhotoUpload.FileName);

                         if (fileExtension.ToLower() != ".png" && fileExtension.ToLower() != ".jpg" && fileExtension.ToLower() != ".gif")
                         {
                             choosePhotolbl.ForeColor = System.Drawing.Color.Red;
                             choosePhotolbl.Text = "Only files with .png and .jpg extension are allowed";
                         }
                         else
                         {
                             // Get the file size
                             int fileSize = PhotoUpload.PostedFile.ContentLength;
                             // If file size is greater than 2 MB
                             if (fileSize > 2097152)
                             {
                                 choosePhotolbl.ForeColor = System.Drawing.Color.Red;
                                 choosePhotolbl.Text = "File size cannot be greater than 2 MB";
                             }
                             else
                             {
                                 // Upload the file
                                 PhotoUpload.SaveAs(Server.MapPath("~/userImages/" + getFirstName()+PhotoUpload.FileName));
                                 choosePhotolbl.ForeColor = System.Drawing.Color.Green;
                                 choosePhotolbl.Text = "File uploaded successfully";
                                 string connStr = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                                 SqlConnection dbConnection = new SqlConnection(connStr);
                                 dbConnection.Open();
                                 int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                                 string path = "userImages/" + getFirstName() + PhotoUpload.FileName;
                                 string strQuery = "insert into userImageTable (userID, ImageFileName, ImageFilePath) values (@userID, @FileName, @FilePath)";
                                 SqlCommand cmd = new SqlCommand(strQuery, dbConnection);
                                 cmd.Parameters.AddWithValue("@userID", uid);
                                 cmd.Parameters.AddWithValue("@FileName", getFirstName() + PhotoUpload.FileName);
                                 cmd.Parameters.AddWithValue("@FilePath", path);
                                 cmd.ExecuteNonQuery();


                             }
                         }
                     }
                     else
                     {
                         choosePhotolbl.ForeColor = System.Drawing.Color.Red;
                         choosePhotolbl.Text = "Please select a file";
                     } 
                     
                 }

                 //TextBox tb;
                 //Label labl;
                 //static int i = 0;
                 //protected void AddTextBox_Click(object sender, EventArgs e)
                 //{ 
                     
                 //    for (int j = 0; j <= i; j++)
                 //    {
                 //        tb = new TextBox();
                 //        tb.ID = j.ToString();
                 //        tb.CssClass = "form-control";
                 //        string textLabel = "<br /> University Name";
                 //        labl = new Label();
                 //        labl.Text = textLabel;
                 //        pnlTextBoxes.Controls.Add(labl);

                 //        pnlTextBoxes.Controls.Add(tb);
                         
                 //    }
                 //    i++;  
                 //foreach (Control ctr in pnlTextBoxes.Controls)
                 //{
                 //    if (ctr is TextBox)
                 //    {
                 //        string listofUniv = ((TextBox)ctr).Text + ",";
                 //        test.Text = listofUniv;
                 //    }
                 //}
                     
                 //}

                 protected void Save3_Click(object sender, EventArgs e)
                 {
                     if (EsaayOfChoiceUpload.HasFile)
                     {
                         // Get the file extension
                         string fileExtension = System.IO.Path.GetExtension(EsaayOfChoiceUpload.FileName);

                         if (fileExtension.ToLower() != ".doc" && fileExtension.ToLower() != ".docx" && fileExtension.ToUpper() != ".pdf")
                         {
                             lblEsaayMessage.ForeColor = System.Drawing.Color.Red;
                             lblEsaayMessage.Text = "Only files with .doc, .pdf and .docx extension are allowed";
                         }
                         else
                         {
                             // Get the file size
                             int fileSize = EsaayOfChoiceUpload.PostedFile.ContentLength;
                             // If file size is greater than 2 MB
                             if (fileSize > 2097152)
                             {
                                 lblEsaayMessage.ForeColor = System.Drawing.Color.Red;
                                 lblEsaayMessage.Text = "File size cannot be greater than 2 MB";
                             }
                             else
                             {
                                 // Upload the file
                                 EsaayOfChoiceUpload.SaveAs(Server.MapPath("~/userEssay/" + getFirstName() + EsaayOfChoiceUpload.FileName));
                                 lblEsaayMessage.ForeColor = System.Drawing.Color.Green;
                                 lblEsaayMessage.Text = "File uploaded successfully";
                                 string connStr = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                                 SqlConnection dbConnection = new SqlConnection(connStr);
                                 dbConnection.Open();
                                 int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                                 string path = "userEssay/" + getFirstName() + EsaayOfChoiceUpload.FileName;
                                 string strQuery = "insert into userEssayTable (userID, EssayFileName, EssayFilePath) values (@userID, @FileName, @FilePath)";
                                 SqlCommand cmd = new SqlCommand(strQuery, dbConnection);
                                 cmd.Parameters.AddWithValue("@userID", uid);
                                 cmd.Parameters.AddWithValue("@FileName", getFirstName() + EsaayOfChoiceUpload.FileName);
                                 cmd.Parameters.AddWithValue("@FilePath", path);
                                 cmd.ExecuteNonQuery();
                             }
                         }
                     }
                     else
                     {
                         lblEsaayMessage.ForeColor = System.Drawing.Color.Red;
                         lblEsaayMessage.Text = "Please select a file";
                     } 
                     

                 }

                 
    }
}