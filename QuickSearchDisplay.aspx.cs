using System;
using System.Collections.Generic;
using System.Data;
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

            DataTable dt1 = new DataTable();

            string strQuery = "select userImageTable.ImageFilePath, studentPersonal.firstName, studentPersonal.lastName from studentPersonal, userImageTable where userImageTable.userID=studentPersonal.userID and studentPersonal.firstName=@name";
            SqlCommand cmd = new SqlCommand(strQuery, dbConnection);
            cmd.Parameters.AddWithValue("@name", quickSearch);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = dbConnection;
            try
            {

                dbConnection.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt1);


                if (dt1.Rows.Count > 0)
                {
                    GridView1.DataSource = dt1;
                    GridView1.DataBind();
                   

                }

                else
                {

                    DataTable dt2= new DataTable();
                    string strQuery2 = "select schoolName, schoolCity from schoolInfo where schoolName=@name";
                    SqlCommand cmd2 = new SqlCommand(strQuery2, dbConnection);
                    cmd2.Parameters.AddWithValue("@name", quickSearch);
                    SqlDataAdapter sda2 = new SqlDataAdapter();
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = dbConnection;

                    try
                    {
                       // dbConnection.Open();
                        sda2.SelectCommand = cmd2;
                        sda2.Fill(dt2);

                        if (dt2.Rows.Count > 0)
                        {
                            GridView2.DataSource = dt2;
                            GridView2.DataBind();
                            

                        }
                        else
                        {
                            Label1.Text = "No results Found";

                        }


                    }

                    catch (Exception ec)
                    {
                        Response.Write(ec.Message);
                    }

                    finally
                    {

                       // dbConnection.Close();
                       // sda.Dispose();
                        //dbConnection.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {

                dbConnection.Close();
                sda.Dispose();
                dbConnection.Dispose();
            }








            //try
            //{
            //    dbConnection.Open();
            //    string queryQuickSearch = "select userImageTable.ImageFilePath, studentPersonal.firstName, studentPersonal.lastName from studentPersonal, userImageTable where userImageTable.userID=studentPersonaal.userID and firstName=@name";
            //    //"select schoolName, schoolCity from schoolInfo where schoolName=@name";

            //    try
            //    {
            //        SqlCommand getType = new SqlCommand(queryQuickSearch, dbConnection);
            //        getType.Parameters.Add(new SqlParameter("@name", quickSearch));
            //        SqlDataReader reader = getType.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            string path = reader.GetString(0);
            //        }

            //        GridView1.DataSource = getType.ExecuteReader();
            //        GridView1.
            //        GridView1.DataBind();

            //    }

            //    catch (SqlException ez)
            //    {
            //        Response.Write("<p>Error Code " + ez.Number + ": " + ez.Message + "</p>");
            //    }
            // }
            //    catch (SqlException ex)
            //    {
            //        Response.Write("<p>Error Code " + ex.Number + ": " + ex.Message + "</p>");
            //    }
            //}
        }
    }
}