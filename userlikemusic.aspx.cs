using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class userlikemusic : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["newuid"] != null)
        {
            Panel1.Visible = true;
            HyperLink1.Visible = false;
            HyperLink2.Visible = false;
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getmusictype = new SqlCommand("select distinct musictype,subcategory from genre", con);
            con.Open();
            SqlDataReader rdr = getmusictype.ExecuteReader();
            while (rdr.Read())
            {
                CheckBox ck = new CheckBox();
                ck.ID = (string)rdr[0] + rdr[1];
                ck.Text = (string)rdr[0] + " " + rdr[1];
                Panel1.Controls.Add(ck);
                Panel1.Controls.Add(new LiteralControl("<br>"));

            }
            rdr.Close();
            con.Close();
        }
        if (Session["newbandid"] != null)
        {
            Panel1.Visible = true;
            HyperLink1.Visible = false;
            HyperLink2.Visible = false;
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getmusictype = new SqlCommand("select distinct musictype,subcategory from genre", con);
            con.Open();
            SqlDataReader rdr = getmusictype.ExecuteReader();
            while (rdr.Read())
            {
                CheckBox ck = new CheckBox();
                ck.ID = (string)rdr[0] + rdr[1];
                ck.Text = (string)rdr[0] + " " + rdr[1];
                Panel1.Controls.Add(ck);
                Panel1.Controls.Add(new LiteralControl("<br>"));

            }
            rdr.Close();
            con.Close();
        }
        if(Session["newuid"]==null && Session["newbandid"]==null)
        {
            Response.Redirect("~/login.aspx");
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        if (Session["newuid"] != null)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getmusictype = new SqlCommand("select distinct musictype,subcategory from genre", con);
            con.Open();
            SqlDataReader rdr = getmusictype.ExecuteReader();
            while (rdr.Read())
            {
                if (((CheckBox)Panel1.FindControl((string)rdr[0] + rdr[1])).Checked)
                {
                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand userlikemusic = new SqlCommand("usrlikemusic", con1);
                    userlikemusic.CommandType = CommandType.StoredProcedure;
                    userlikemusic.Parameters.AddWithValue("@uid", (string)Session["newuid"]);
                    userlikemusic.Parameters.AddWithValue("@musictype", (string)rdr[0]);
                    userlikemusic.Parameters.AddWithValue("@subcategory", (string)rdr[1]);
                    con1.Open();
                    userlikemusic.ExecuteNonQuery();
                    con1.Close();
                }
            }
            rdr.Close();
            con.Close();
            HyperLink1.Visible = true;
            HyperLink2.Visible = false;
        }

        if (Session["newbandid"] != null)
        {
            SqlConnection con = new SqlConnection(cs);
            SqlCommand getmusictype = new SqlCommand("select distinct musictype,subcategory from genre", con);
            con.Open();
            SqlDataReader rdr = getmusictype.ExecuteReader();
            while (rdr.Read())
            {
                if (((CheckBox)Panel1.FindControl((string)rdr[0] + rdr[1])).Checked)
                {
                    SqlConnection con1 = new SqlConnection(cs);
                    SqlCommand bandplaymusic = new SqlCommand("bandplaymusic", con1);
                    bandplaymusic.CommandType = CommandType.StoredProcedure;
                    bandplaymusic.Parameters.AddWithValue("@bid", (string)Session["newbandid"]);
                    bandplaymusic.Parameters.AddWithValue("@musictype", (string)rdr[0]);
                    bandplaymusic.Parameters.AddWithValue("@subcategory", (string)rdr[1]);
                    con1.Open();
                    bandplaymusic.ExecuteNonQuery();
                    con1.Close();
                }
            }
            rdr.Close();
            con.Close();
            HyperLink2.Visible = true;
            HyperLink1.Visible = false;
        }
        Panel1.Visible = false;
        Label1.Text = "Your choice of music is saved";
      
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();


    }
}