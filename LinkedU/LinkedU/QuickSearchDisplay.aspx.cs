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
    public partial class QuickSearchDisplay : System.Web.UI.Page
    {
        public SqlConnection dbConnection;

        public QuickSearchDisplay()
        {
            dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string quickSearch = Request.QueryString["quickSearchTerm"];
            //string result = "";
            try
            {
                dbConnection.Open();
                string queryQuickSearch = "select firstName from studentPersonal where firstName=@name union " +
                "select schoolName from schoolInfo where schoolName=@name";

                try
                {
                    SqlCommand getType = new SqlCommand(queryQuickSearch, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@name", quickSearch));
                    //SqlDataReader reader = getType.ExecuteReader();
                    GridView1.DataSource = getType.ExecuteReader();
                    GridView1.DataBind();
                    //while (reader.Read())
                    //{
                    //    result = reader.GetString(0);

                    //}
                }

                catch (SqlException ez)
                {
                    Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
                }
            }
            catch (SqlException ex)
            {
                Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            }
        }
    }
}