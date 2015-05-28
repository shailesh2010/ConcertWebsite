using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class posts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("showpost", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid",int.Parse( Request.QueryString["id"]));
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Label1.Text = (string)rdr[0];
                    Label2.Text = (string)rdr[1];
                    Label4.Text = (string)rdr[2];
                    Label3.Text = Convert.ToDateTime(rdr[3]).ToString();
                }
                rdr.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[userrecommendpost] where pid=@pid and uid=@uid", con);
                cmd.Parameters.AddWithValue("@pid", int.Parse(Request.QueryString["id"]));
                cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                int i = (int)cmd.ExecuteScalar();
                if (i > 0)
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
                SqlCommand getuser = new SqlCommand("getcomments", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@pid",int.Parse( Request.QueryString["id"]));
                con.Open();
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label5.Text = "No comments";
                }
                else
                {
                    //string s = "";
                    while (rdr.Read())
                    {
                        Label lbl = new Label();
                        lbl.Text = (string)rdr[0] + "  ";
                        Label lbl1 = new Label();
                        lbl1.Text = (string)rdr[1] + "  ";
                        Label lbl2 = new Label();
                        lbl2.Text = (string)rdr[2] + "  ";
                        Label lbl3 = new Label();
                        lbl3.Text = Convert.ToDateTime(rdr[3]).ToString() + "  ";                        
                        Panel2.Controls.Add(lbl);
                        Panel2.Controls.Add(lbl1);
                        Panel2.Controls.Add(lbl2);
                        Panel2.Controls.Add(lbl3); 
                        Panel2.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("usrrecommendpost", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid",int.Parse( Request.QueryString["id"]));
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
            SqlCommand cmd = new SqlCommand("postcmnt", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid",int.Parse( Request.QueryString["id"]));
            cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            cmd.Parameters.AddWithValue("@comment",TextBox1.Text);
            cmd.ExecuteNonQuery();
            TextBox1.Text = "";
            Label6.Text = "comment posted successfully";
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/user.aspx");
    }
}