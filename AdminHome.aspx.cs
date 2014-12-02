using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU.images
{
    public partial class AdminHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["userID"] != null)
            {
                if (!Page.IsPostBack)
                {

                    int adminID = Convert.ToInt32(HttpContext.Current.Session["userID"]);

                }
            }
            else {
                Response.Redirect("Default.aspx");
            }

        }

        protected void choosePhoto_Click(object sender, EventArgs e)
        {
            Session["ImageBytes"] = PhotoUpload.FileBytes;
            ImagePreview.ImageUrl = "~/ImageHandler.ashx";
        }

        protected void insertButton_Click(object sender, EventArgs e)
        {

            string name = schoolName.Text;
            int schoolRank = Convert.ToInt32(rank.Text);
            string schoolCity = city.Text;
            string schoolState = state.Text;
            string schoolDescription = description.Text;
            string schoolWebsite = website.Text;
            DateTime appDeadline = Convert.ToDateTime(deadline.Text);
            string schoolAddress = address.Text;
            string schoolPhoneNumber = phone.Text;

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
                        PhotoUpload.SaveAs(Server.MapPath("~/universityImages/" + name + PhotoUpload.FileName));
                        choosePhotolbl.ForeColor = System.Drawing.Color.Green;
                        choosePhotolbl.Text = "File uploaded successfully";
                        string connStr = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                        SqlConnection dbConnection = new SqlConnection(connStr);
                        dbConnection.Open();
                        //int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);

                        string path = "universityImages/" + name + PhotoUpload.FileName;
                        string strQuery = "insert into schoolInfo (schoolImagePath,schoolName, schoolRank, schoolCity, schoolState,"
                        + " schoolDescription, schoolWebsite, applicationDeadline, schoolAddress, schoolPhone) values" +
                        " (@FilePath, @schoolName, @schoolRank, @schoolCity, @schoolState, @schoolDescription, @schoolWebsite," +
                        " @applicationDeadline, @schoolAddress, @schoolPhone)";
                        SqlCommand cmd = new SqlCommand(strQuery, dbConnection);
                        cmd.Parameters.AddWithValue("@FilePath", path);
                        cmd.Parameters.AddWithValue("@schoolName", name);
                        cmd.Parameters.AddWithValue("@schoolRank", schoolRank);
                        cmd.Parameters.AddWithValue("@schoolCity", schoolCity);
                        cmd.Parameters.AddWithValue("@schoolState", schoolState);
                        cmd.Parameters.AddWithValue("@schoolDescription", schoolDescription);
                        cmd.Parameters.AddWithValue("@schoolWebsite", schoolWebsite);
                        cmd.Parameters.AddWithValue("@applicationDeadline", appDeadline);
                        cmd.Parameters.AddWithValue("@schoolAddress", schoolAddress);
                        cmd.Parameters.AddWithValue("@schoolPhone", schoolPhoneNumber);
                        cmd.ExecuteNonQuery();
                        dbConnection.Close();

                    }
                }
            }
            else
            {
                choosePhotolbl.ForeColor = System.Drawing.Color.Red;
                choosePhotolbl.Text = "Please select a file";
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (RadioButtonList1.SelectedValue == "add")
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
            {
                MultiView1.ActiveViewIndex = 1;
                SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);

                DataTable dt1 = new DataTable();

                string queryQuickSearch = "select * from schoolInfo";


                SqlCommand getType = new SqlCommand(queryQuickSearch, dbConnection);

                SqlDataAdapter sda = new SqlDataAdapter();
                getType.CommandType = CommandType.Text;
                getType.Connection = dbConnection;

                try
                {

                    dbConnection.Open();
                    sda.SelectCommand = getType;
                    sda.Fill(dt1);


                    if (dt1.Rows.Count > 0)
                    {
                        GridView1.DataSource = dt1;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Label5.Text = "No results Found";
                    }

                }

                catch (SqlException ez)
                {
                    Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                }
                finally
                {

                    dbConnection.Close();
                    sda.Dispose();
                    dbConnection.Dispose();
                }

            }
        }

        protected void SelectShowcase_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connStr);
            try
            {
                dbConnection.Open();
                foreach (GridViewRow row in GridView1.Rows)
                {

                    if (row.RowType == DataControlRowType.DataRow)
                    {
                        CheckBox chkRow = (row.Cells[0].FindControl("showcaseSelector") as CheckBox);
                        if (chkRow.Checked)
                        {
                            string name = row.Cells[2].Text;
                           // Response.Write("<h1>" + id + "</h1>");


                            //int schoolID = Convert.ToInt32(id);

                            string query = "select schoolImagePath, schoolName from schoolInfo where schoolName=@NameSchool ";
                            SqlCommand cmd = new SqlCommand(query, dbConnection);
                            cmd.Parameters.AddWithValue("@NameSchool", name);
                            SqlDataReader reader = cmd.ExecuteReader();

                            if (reader.Read())
                            {
                                string sourcePath = reader.GetString(0);
                                string sName = reader.GetString(1);
                                reader.Close();
                                try
                                {
                                    string insertQuery = "insert into showcaseImages(imagePath, schoolName) values"+
                                        " (@path, @schName)";
                                    SqlCommand cmd2 = new SqlCommand(insertQuery, dbConnection);
                                    cmd2.Parameters.AddWithValue("@path", sourcePath);
                                    cmd2.Parameters.AddWithValue("@schName", sName);
                                    cmd2.ExecuteNonQuery();

                                }
                                catch (SqlException ez)
                                {
                                    Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                                }
                    
                            }

                        }
                    }
                }
            }

            catch (SqlException ez)
            {
                Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
            }
            finally
            {
                 dbConnection.Close();
               
            }
        }
    }
}