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
    public partial class AdvanceSearchForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = TextBox1.Text;
            string lastName = TextBox2.Text;
            string studentCity = TextBox3.Text;
            string studentState = TextBox4.Text;
            string major = TextBox5.Text;
            string gpa = TextBox6.Text;

            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);
            
          
                DataTable dt1 = new DataTable();

                string queryQuickSearch = "select studentPersonal.userID, userImageTable.ImageFilePath, studentPersonal.firstName,"+
                    " studentPersonal.lastName, studentPersonal.studentEmailID, studentPersonal.studentPhone" +
                    " from studentPersonal, userImageTable where studentPersonal.userID=userImageTable.userID and"+
                    " (firstName=@firstName or" +
                " lastName=@lastName or studentCity=@studentCity or studentState=@studentState) union"+
                " select studentPersonal.userID, userImageTable.ImageFilePath, studentPersonal.firstName,studentPersonal.lastName,"+
                " studentPersonal.studentEmailID, studentPersonal.studentPhone from userImageTable, studentPersonal," +
                " studentProfessional, studentScore" +
                " where studentPersonal.userID=studentProfessional.userID and studentPersonal.userID=userImageTable.userID and"+
                " studentProfessional.userID=studentScore.userID and studentProfessional.userID in (select userId from studentProfessional" +
                " where major=@major) or  studentProfessional.userID in (select userID from studentScore where GPA=@gpa)";

                    SqlCommand getType = new SqlCommand(queryQuickSearch, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@firstName", firstName));
                    getType.Parameters.Add(new SqlParameter("@lastName", lastName));
                    getType.Parameters.Add(new SqlParameter("@studentCity", studentCity));
                    getType.Parameters.Add(new SqlParameter("@studentState", studentState));
                    getType.Parameters.Add(new SqlParameter("@major", major));
                    getType.Parameters.Add(new SqlParameter("@gpa", gpa));

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string schoolName = TextBox7.Text;
            string schoolCity = TextBox8.Text;
            string schoolState = TextBox9.Text;
            string schoolRank = TextBox10.Text;

            SqlConnection dbConnection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString);

            DataTable dt1 = new DataTable();
           
                string queryQuickSearch = "select schoolID, schoolName, schoolWebsite, schoolCity, schoolState from schoolInfo where schoolName=@schoolName" +
                    " or schoolCity=@schoolCity or schoolState=@schoolState or schoolRank=@schoolRank";

                
                    SqlCommand getType = new SqlCommand(queryQuickSearch, dbConnection);
                    getType.Parameters.Add(new SqlParameter("@schoolName", schoolName));
                    getType.Parameters.Add(new SqlParameter("@schoolCity", schoolCity));
                    getType.Parameters.Add(new SqlParameter("@schoolState", schoolState));
                    getType.Parameters.Add(new SqlParameter("@schoolRank", schoolRank));

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
                                 GridView2.DataSource = dt1;
                                 GridView2.DataBind();
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

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue=="student")
            {
                MultiView1.ActiveViewIndex = 0;
            }
            else
                MultiView1.ActiveViewIndex = 1;
        }
    }
}