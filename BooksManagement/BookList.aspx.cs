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
    public partial class BookList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }
        }

        protected void grdView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lnkbtnEdit")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("UpdateBookDetails.aspx?id=" + id);
            }

            if (e.CommandName == "lnkbtnDelete")
            {
                int id = int.Parse(e.CommandArgument.ToString());
                string connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
               
                SqlCommand cmd = new SqlCommand("delete from tblBooks where id='" + id + "'", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                getData(); /* Reload gridview */
            }


        }
        public void getData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("select a.id,a.bookname,a.bookpublishdate,a.authorid,b.authorname,b.Authoremailid from tblBooks as a INNER JOIN tblAuthor as b ON a.authorname = b.authorname", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grdView.DataSource = dt;
            grdView.DataBind();
        }
    }
}