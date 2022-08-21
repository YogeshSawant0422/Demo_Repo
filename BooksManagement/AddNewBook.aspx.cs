using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksManagement
{
    public partial class AddNewBook : System.Web.UI.Page
    {
        static int AutherID;
        protected void Page_Load(object sender, EventArgs e)
        {
            getdata();
        }

        void getdata()
        {
            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection Con = new SqlConnection(Connection);

            Con.Open();

            SqlCommand cmd = new SqlCommand("select distinct(authorname) from tblAuthor", Con);
            var obj = cmd.ExecuteReader();

            while (obj.Read())
            {
                Auther.Items.Add(obj["authorname"].ToString());
            }

            Con.Close();
        }
        protected void Auther_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection Con = new SqlConnection(Connection);

            Con.Open();

            SqlCommand cmd = new SqlCommand("select id from tblAuthor where authorname = '" + Auther.Text + "'",Con);
            var obj = cmd.ExecuteReader();

            while(obj.Read())
            {
                AutherID = Convert.ToInt32((obj["id"].ToString()));
            }

            Con.Close();
        }

        int AutoIncr()
        {
            string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection Con = new SqlConnection(Connection);

            Con.Open();

            SqlCommand cmd = new SqlCommand("select count(id) from tblBooks", Con);
            var maxcount = cmd.ExecuteScalar();

            int ReturnCount = Convert.ToInt32(maxcount);
            int ReceivedCount = 0;

            if (ReturnCount > 0)
            {
                SqlCommand cmd2 = new SqlCommand("select max(id) from tblBooks", Con);
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

        protected void AddBook_Click(object sender, EventArgs e)
        {
            try
            {
                string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection Con = new SqlConnection(Connection);

                Con.Open();

                int ID = AutoIncr();

                if (BookName.Text != "" && Date.Text != "" && Auther.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("insert into tblBooks(id,bookname,bookpublishdate,authorid,authorname) values(" + ID + ",'" + BookName.Text + "','" + Date.Text + "'," + AutherID + ",'" + Auther.Text + "')", Con);
                    var SubmitData = cmd.ExecuteNonQuery();

                    if (SubmitData == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Book Details Submit Succesfully')", true);
                        BookName.Text = "";
                        Auther.SelectedIndex = -1;
                        Auther.Items.Clear();
                        Auther.Items.Insert(0, new ListItem("Select Auther"));
                        getdata();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Something Went Wrong !!!')", true);
                        BookName.Text = "";
                        Auther.SelectedIndex = -1;
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('First Fill All Records !!')", true);
                }

                Con.Close();
            }catch(Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}