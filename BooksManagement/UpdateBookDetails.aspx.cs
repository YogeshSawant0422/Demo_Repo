using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BooksManagement
{
    public partial class UpdateBookDetails : System.Web.UI.Page
    {
        int id;
        public string OldBook = string.Empty;
        public string AuthorName01 = string.Empty;
        public string AuthorDate = string.Empty;
        int NumberID;

        static int AuthorID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
                getdata();

                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"].ToString());
                    //id = int.Parse(BookId.Text);
                    string connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("Select * from tblBooks where id='" + id + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        OldBook = dt.Rows[0][1].ToString();
                        AuthorDate = dt.Rows[0][2].ToString();
                        AuthorName01 = dt.Rows[0][4].ToString();
                        NumberID = int.Parse(dt.Rows[0][3].ToString());
                    }
                }

                BookId.Text = Request.QueryString["id"].ToString();
                BookName.Text = OldBook;
                AName.Text = AuthorName01;
                PublishDate.Text = AuthorDate;            
            //}
        }
        void getdata()
        {
            if(!IsPostBack)
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
        }

        protected void AddBook_Click(object sender, EventArgs e)
        { 
            if (Request.QueryString["id"] != null)
            {
                id = int.Parse(Request.QueryString["id"].ToString());
                //id = int.Parse(BookId.Text);
                string connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();

                SqlDataAdapter da = new SqlDataAdapter("Select * from tblBooks where id='" + id + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    OldBook = dt.Rows[0][1].ToString();
                    AuthorDate = dt.Rows[0][2].ToString();
                    AuthorName01 = dt.Rows[0][4].ToString();
                    NumberID = int.Parse(dt.Rows[0][3].ToString());
                }
            }

            BookId.Text = Request.QueryString["id"].ToString();
            BookName.Text = OldBook;
            AName.Text = AuthorName01;
            PublishDate.Text = AuthorDate;

            try
            {
                string Connection = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection Con = new SqlConnection(Connection);

                Con.Open();

                  if(ChangeBook.Text == "")
                  {
                    ChangeBook.Text = BookName.Text;
                  }

                  if(Auther.Text == "Select Author")
                 {
                    Auther.Text = AName.Text;
                 }
                else
                {
                    if(Auther.Text != AName.Text)
                    {
                        string Connection2 = System.Configuration.ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                        SqlConnection Con2 = new SqlConnection(Connection);

                        Con.Open();

                        SqlCommand cmd2 = new SqlCommand("select id from tblAuthor where authorname = '" + AName.Text + "'", Con);
                        var obj = cmd2.ExecuteReader();

                        while (obj.Read())
                        {
                            NumberID = Convert.ToInt32((obj["id"].ToString()));
                        }

                        Con.Close();
                    }
                }

                  if(ChangeDate.Text == "")
                 {
                    ChangeDate.Text = PublishDate.Text;
                 }

                string cmdText = "Update tblBooks set bookname='" + ChangeBook.Text + "',bookpublishdate='" + ChangeDate.Text + "',authorname='" + AName.Text + "',authorid=" + NumberID + " where id=" + int.Parse(Request.QueryString["id"].ToString()) + "";

                SqlCommand cmd = new SqlCommand(cmdText,Con);
                    var SubmitData = cmd.ExecuteNonQuery();

                    if (SubmitData == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Update Succesfully')", true);
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

                Response.Redirect("UpdateBookDetails.aspx");
                
                Con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void Auther_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();

                if (Request.QueryString["id"] != null)
                {
                    id = int.Parse(Request.QueryString["id"].ToString());
                    string connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);

                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter("Select * from tblBooks where id='" + id + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        OldBook = dt.Rows[0][1].ToString();
                        AuthorDate = dt.Rows[0][2].ToString();
                        AuthorName01 = dt.Rows[0][4].ToString();
                        NumberID = int.Parse(dt.Rows[0][3].ToString());
                    }
                }

                BookId.Text = Request.QueryString["id"].ToString();
                BookName.Text = OldBook;
                AName.Text = AuthorName01;
                PublishDate.Text = AuthorDate;
            }
        }
    }
}