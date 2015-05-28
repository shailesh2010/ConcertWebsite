using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class upcomingconcert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Now;
        if (Session["uid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("searchconcert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cid", int.Parse(Request.QueryString["id"]));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[4].ToString() == "")
                    {
                        Image1.ImageUrl = "~/uploads/Desert.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = (string)rdr[4];
                    }
                    Label2.Text = "Band Name : "+(string)rdr[0];
                    Label3.Text = "Date and Time : " + Convert.ToDateTime(rdr[1]).ToString().Substring(0, 10)+"  ";
                    dt = Convert.ToDateTime(rdr[1]);
                    Label4.Text = rdr[2].ToString();
                    Label5.Text = "Music : " + (string)rdr[6];
                    Label6.Text = (string)rdr[7];
                    Label7.Text = rdr[3]+"<br>"+rdr[8]+"<br>"+rdr[9];
                    Label8.Text = "Capacity= " + rdr[10] + "<br>" + "Ticket Price= " + rdr[5];
                    HyperLink1.NavigateUrl = "#";
                }
                rdr.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[userwillattend] where cid=@cid and uid=@uid", con);
                cmd.Parameters.AddWithValue("@cid",int.Parse( Request.QueryString["id"]));
                cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                int i = (int)cmd.ExecuteScalar();
                if (i > 0 )
                {
                    Button1.Visible = false;
                }
                else
                {
                    Button1.Visible = true;
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[userrecommendconcert] where cid=@cid and uid=@uid", con);
                cmd.Parameters.AddWithValue("@cid",int.Parse( Request.QueryString["id"]));
                cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                int i = (int)cmd.ExecuteScalar();
                if (i > 0 )
                {
                    Button2.Visible = false;
                }
                else
                {
                    Button2.Visible = true;
                }
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
        if (dt < DateTime.Now)
        {
            Button1.Visible = false;
            Button2.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usrwillattend", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            cmd.ExecuteNonQuery();
            Button1.Visible = false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usrrecommendconcert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cid", Request.QueryString["id"]);
            cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            cmd.ExecuteNonQuery();
            Button2.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/user.aspx");
    }
}