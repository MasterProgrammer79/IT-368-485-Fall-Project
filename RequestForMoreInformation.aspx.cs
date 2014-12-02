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
    public partial class RequestForMoreInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Request.QueryString["userID"]);
        }

        protected void requestSubmit_Click(object sender, EventArgs e)
        {
            int uid = Convert.ToInt32(Request.QueryString["userID"]);
            string fromName = FromUserTextbox.Text;
             SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            string newRequestQuery = "insert into moreinformation values (@uid, @Desc, @request, @fromname)";
                        try
                        {
                            dbConnection.Open();
                            SqlCommand addNewRequest = new SqlCommand(newRequestQuery, dbConnection);
                            addNewRequest.Parameters.Add(new SqlParameter("@uid", uid));
                            addNewRequest.Parameters.Add(new SqlParameter("@fromname", fromName));
                            addNewRequest.Parameters.Add(new SqlParameter("@Desc", DescriptionTextbox.Text));
                            addNewRequest.Parameters.Add(new SqlParameter("@request", "Yes"));
                           
                            addNewRequest.ExecuteNonQuery();
                          
                        }
                        catch (SqlException ex)
                        {
                            Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
                        }
                        dbConnection.Close();
                        RequestOutputLabel.Text = "You have successfully send an request for more information student will contact you soon with their information";
                        MultiView1.ActiveViewIndex = 1;
        }
      
    }
}