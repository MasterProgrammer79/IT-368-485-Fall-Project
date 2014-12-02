using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LinkedU
{
    public partial class AdminDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            int schoolID = Convert.ToInt32(Request.QueryString["schoolID"]);
            results.Visible = false;

            if (!Page.IsPostBack)
            {


                string connStr = ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
                SqlConnection dbConnection = new SqlConnection(connStr);

                //int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
                dbConnection.Open();
                string getImagePath = "select schoolName from schoolInfo where schoolID=@ID";
                SqlCommand sqlCommandgetPath = new SqlCommand(getImagePath, dbConnection);
                sqlCommandgetPath.Parameters.Add(new SqlParameter("@ID", schoolID));
                SqlDataReader reader = sqlCommandgetPath.ExecuteReader();
                if (reader.Read())
                {
                    deleteUniversity.Text = reader.GetString(0);
                }
            }
            }
            

        protected void Button1_Click(object sender, EventArgs e)
        {
            deleteUniversity.Visible = false;
            results.Visible = true;

            string name = deleteUniversity.Text;
            string connStr = ConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;
            SqlConnection dbConnection = new SqlConnection(connStr);

            //int uid = Convert.ToInt32(HttpContext.Current.Session["userID"]);
            try
            {
                dbConnection.Open();
                string deleteQuery = "delete from schoolInfo where schoolName=@name";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, dbConnection);
                deleteCmd.Parameters.Add(new SqlParameter("@name", name));
                deleteCmd.ExecuteNonQuery();
                results.Text = "Deleted Successfully !";

            }
            catch (SqlException exception)
            {
                Response.Write("<p>Error code " + exception.Number
                    + ": " + exception.Message + "</p>");
            }
            dbConnection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {    
        Response.Redirect("AdminHome.aspx");
        }
    }
}