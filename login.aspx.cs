using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[user] where uid=@uid and password=@password", con);
                cmd.Parameters.AddWithValue("@uid", txtuserid.Text);
                cmd.Parameters.AddWithValue("@password", txtpassword.Text);
                con.Open();
                int i = (int)cmd.ExecuteScalar();                
                if (i > 0)
                {
                    Session["uid"] = txtuserid.Text;
                    SqlCommand login = new SqlCommand("usrlogin", con);
                    login.CommandType = CommandType.StoredProcedure;
                    login.Parameters.AddWithValue("@uid", txtuserid.Text);
                    login.ExecuteNonQuery();
                    //Session.Timeout = 2;
                    Response.Redirect("~/user.aspx");

                }
                else
                {
                    Label1.ForeColor = System.Drawing.Color.Green;
                    Label1.Text = "invalid username or password";
                }
            }
        }
    }
}