using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class anotherband : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select bname,info,picture from [dbo].[band] where bid=@bid", con);
                cmd.Parameters.AddWithValue("@bid", Request.QueryString["id"]);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[2].ToString() == "")
                    {
                        Image1.ImageUrl = "~/uploads/Desert.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = (string)rdr[2];
                    }
                    Label2.Text = (string)rdr[0];
                    Label4.Text = (string)rdr[1];
                }
                rdr.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand count = new SqlCommand("select count(*) from [dbo].[userfollowband] where uid=@uid and bid=@bid", con);
                count.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                count.Parameters.AddWithValue("@bid", Request.QueryString["id"]);
                int i = (int)count.ExecuteScalar();
                if (i > 0)
                {
                    Button1.Visible = false;
                    Button2.Visible = true;
                }
                else
                {
                    Button1.Visible = true;
                    Button2.Visible = false;
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                string s = " ";
                SqlCommand getmusic = new SqlCommand("select musictype,subcategory from [dbo].[bandplays] where bid=@bid", con);
                getmusic.Parameters.AddWithValue("@bid", Request.QueryString["id"]);
                con.Open();
                SqlDataReader rdr = getmusic.ExecuteReader();
                while (rdr.Read())
                {
                    s += rdr[0] + " " + rdr[1] + ", ";
                }
                rdr.Close();
                Label5.Text = "We play " + s;
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand userfollow = new SqlCommand("usrfollowband", con);
            userfollow.CommandType = CommandType.StoredProcedure;
            userfollow.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            userfollow.Parameters.AddWithValue("@bid", Request.QueryString["id"]);
            userfollow.ExecuteNonQuery();
            Button1.Visible = false;
            Button2.Visible = true;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand userfollow = new SqlCommand("delete from [dbo].[userfollowband] where uid=@uid and bid=@bid", con);
            userfollow.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            userfollow.Parameters.AddWithValue("@bid", Request.QueryString["id"]);
            con.Open();
            userfollow.ExecuteNonQuery();
            Button2.Visible = false;
            Button1.Visible = true;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/searchband.aspx?search=" + (string)Session["searchband"]);
    }
}