using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksManagement
{
    public partial class AddNewAuthor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthorID.Text = Convert.ToString(AutoIncr());
        }

        int AutoIncr()
        {
            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection Con = new SqlConnection(Connection);

            Con.Open();

            SqlCommand cmd = new SqlCommand("select count(id) from tblAuthor",Con);
            var maxcount = cmd.ExecuteScalar();

            int ReturnCount = Convert.ToInt32(maxcount);
            int ReceivedCount = 0;

            if (ReturnCount > 0)
            {
                SqlCommand cmd2 = new SqlCommand("select max(id) from tblAuthor", Con);
                var FinalId = cmd2.ExecuteScalar();

                int FId = Convert.ToInt32(FinalId);

                ReceivedCount = FId + 1;
            
            }
            else
            {
                ReceivedCount = 1;
            }

            Con.Close();
            return ReceivedCount;
        }

        protected void SubmitAuthor_Click(object sender, EventArgs e)
        {
           
        }

        protected void SubmitAuthor_Click1(object sender, EventArgs e)
        {
            try
            {
                if (AuthorEmail.Text != "")
                {
                    string validRegex = @"/ ^[a - zA - Z0 - 9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/";

                  //  if (validRegex == AuthorEmail.Text)
                  //  {
                        if (AuthorID.Text != "" && AuthorName.Text != "")
                        {
                            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                            SqlConnection Con = new SqlConnection(Connection);

                            Con.Open();

                            int ID = AutoIncr();
                            string name = AuthorName.Text;
                            string mail = AuthorEmail.Text;

                            SqlCommand cmd = new SqlCommand("Insert into tblAuthor(id,authorname,Authoremailid) values(" + ID + ",'" + name + "','" + mail + "')", Con);
                            var SubmitData = cmd.ExecuteNonQuery();

                            if (SubmitData == 1)
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Auther Details Submit Succesfully')", true);
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something Went Wrong !!!')", true);
                            }

                        AuthorName.Text = "";
                        AuthorEmail.Text = "";

                            Con.Close();
                        }
                        else
                        {
                            AuthorID.Style.Add("border-color", "red");
                            AuthorName.Style.Add("border-color", "red");
                        }

                    //}
                    //else
                    //{
                    //    AuthorEmail.Style.Add("border-color", "green");
                    //}
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('First Fill All Records !!!')", true);
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}