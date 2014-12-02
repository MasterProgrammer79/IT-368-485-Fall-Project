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
    public partial class AdminEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Session["userID"] != null)
            {
                string userid = Session["userID"].ToString();


                if (!IsPostBack)
                {

                    int schoolID = Convert.ToInt32(Request.QueryString["schoolID"]);
                    Literal1.Visible = false;


                    string connStr = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                    SqlConnection dbConnection = new SqlConnection(connStr);
                    try
                    {
                        dbConnection.Open();

                        string query = "select * from schoolInfo where schoolID=@id ";
                        SqlCommand cmd = new SqlCommand(query, dbConnection);
                        cmd.Parameters.AddWithValue("@id", schoolID);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string filePath = "~/" + reader.GetString(0);
                            ImagePreview.ImageUrl = filePath;

                            schoolName.Text = reader.GetString(2);
                            rank.Text = reader.GetInt32(3).ToString();
                            city.Text = reader.GetString(4);
                            state.Text = reader.GetString(5);
                            description.Text = reader.GetString(6);
                            website.Text = reader.GetString(7);
                            deadline.Text = reader.GetDateTime(8).ToString();
                            address.Text = reader.GetString(9);
                            phone.Text = reader.GetString(10);
                        }
                    }
                    catch (SqlException exception)
                    {
                        Response.Write("<p>Error code " + exception.Number
                            + ": " + exception.Message + "</p>");
                    }
                    dbConnection.Close();
                }
            }
            else {
                Response.Redirect("Default.aspx");
            }
        }


        protected void updateButton_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {

                photouploadPanel.Visible = false;
                profilePanel1.Visible = false;
                Literal1.Visible = true;
                string name = schoolName.Text;
                int schoolRank = Convert.ToInt32(rank.Text);
                string schoolCity = city.Text;
                string schoolState = state.Text;
                string schoolDescription = description.Text;
                string schoolWebsite = website.Text;
                DateTime appDeadline = Convert.ToDateTime(deadline.Text);
                string schoolAddress = address.Text;
                string schoolPhoneNumber = phone.Text;


                Response.Write(schoolDescription);

                string connStr = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                SqlConnection dbConnection = new SqlConnection(connStr);
                dbConnection.Open();
                //int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);


                string strQuery = "update schoolInfo set schoolRank=@schoolRank," +
                    "schoolCity= @schoolCity , schoolState=@schoolState,"
                + " schoolDescription=@schoolDescription, schoolWebsite= @schoolWebsite, applicationDeadline=@applicationDeadline," +
                " schoolAddress=@schoolAddress, schoolPhone= @schoolPhone where schoolName=@schoolName";

                SqlCommand cmd = new SqlCommand(strQuery, dbConnection);


                cmd.Parameters.AddWithValue("@schoolRank", schoolRank);
                cmd.Parameters.AddWithValue("@schoolCity", schoolCity);
                cmd.Parameters.AddWithValue("@schoolState", schoolState);
                cmd.Parameters.AddWithValue("@schoolDescription", schoolDescription);
                cmd.Parameters.AddWithValue("@schoolWebsite", schoolWebsite);
                cmd.Parameters.AddWithValue("@applicationDeadline", appDeadline);
                cmd.Parameters.AddWithValue("@schoolAddress", schoolAddress);
                cmd.Parameters.AddWithValue("@schoolPhone", schoolPhoneNumber);
                cmd.Parameters.AddWithValue("@schoolName", name);
                cmd.ExecuteNonQuery();
                dbConnection.Close();
                Literal1.Text = "Updated Sucessfully !";
            }
        }
    }

}
