using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class anotheruser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select firstname,lastname,dob,city,aboutself,picture from [dbo].[user] where uid=@uid", con);
                cmd.Parameters.AddWithValue("@uid", Request.QueryString["id"]);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[5].ToString() == "")
                    {
                        Image1.ImageUrl = "~/uploads/Desert.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = (string)rdr[5];
                    }
                    Label2.Text = (string)rdr[0];
                    Label3.Text = (string)rdr[1];
                    Label4.Text = "Born on "+rdr[2].ToString().Substring(0,10);
                    Label5.Text = "Lives in "+(string)rdr[3];
                    Label6.Text = "About me :"+(string)rdr[4];
                }
                rdr.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand count = new SqlCommand("select count(*) from [dbo].[userfollowuser] where following=@following and followed=@followed", con);
                count.Parameters.AddWithValue("@following", (string)Session["uid"]);
                count.Parameters.AddWithValue("@followed", Request.QueryString["id"]);
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
                SqlCommand getmusic = new SqlCommand("select musictype,subcategory from [dbo].[userlikemusic] where uid=@uid", con);
                getmusic.Parameters.AddWithValue("@uid", Request.QueryString["id"]);
                con.Open();
                SqlDataReader rdr = getmusic.ExecuteReader();
                while (rdr.Read())
                {
                    s += rdr[0] + " " + rdr[1] + ", ";
                }
                rdr.Close();
                Label5.Text = "I love " + s;
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
            SqlCommand userfollow = new SqlCommand("usrfollowusr", con);
            userfollow.CommandType = CommandType.StoredProcedure;
            userfollow.Parameters.AddWithValue("@followinguid",(string)Session["uid"]);
            userfollow.Parameters.AddWithValue("@followeduid",Request.QueryString["id"]);
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
            SqlCommand userfollow = new SqlCommand("delete from [dbo].[userfollowuser] where following=@following and followed=@followed", con);
            userfollow.Parameters.AddWithValue("@following", (string)Session["uid"]);
            userfollow.Parameters.AddWithValue("@followed", Request.QueryString["id"]);
            con.Open();
            userfollow.ExecuteNonQuery();
            Button2.Visible = false;
            Button1.Visible = true;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/searchuser.aspx?search=" +(string) Session["searchuser"]);
    }
}