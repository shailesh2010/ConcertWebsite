using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class abn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        //string s = "";
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlCommand getmusictype = new SqlCommand("select distinct musictype,subcategory from genre", con);
        con.Open();
        SqlDataReader rdr = getmusictype.ExecuteReader();
        while (rdr.Read())
        {
            //s = s + "" + rdr[0] + "" + rdr[1];
            CheckBox ck = new CheckBox();
            ck.ID = (string)rdr[0] + rdr[1];
            ck.Text = (string)rdr[0] + " " + rdr[1];
            //ck.AutoPostBack = true;
            //ck.Checked = false;            
            Panel1.Controls.Add(ck);
            Panel1.Controls.Add(new LiteralControl("<br>"));
            //ck.CheckedChanged += new EventHandler(cb_Click);

        }
        //Response.Write(s);
        rdr.Close();
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Label1.Text = ASPxCalendar1.SelectedDate.ToShortDateString();
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into [dbo].[try] values(@dob)", con);
            cmd.Parameters.AddWithValue("@dob", ASPxCalendar1.SelectedDate);
            cmd.ExecuteNonQuery();
            Response.Write("date inserted");
        }
    }
    protected void ASPxCalendar1_DayRender(object sender, DevExpress.Web.ASPxEditors.DayRenderEventArgs e)
    {
        if (e.Day.DateTime > DateTime.Now)
        {
            e.Day.Visible = false;
        }
    }
  
       


        //string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(cs))
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("select distinct (musictype,subcategory) from genre",con);
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        CheckBox ck = new CheckBox();
        //        ck.ID =(string) rdr[1];

        //    }
        //}
  
    protected void Button3_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
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
                userlikemusic.Parameters.AddWithValue("@uid","ssc496");
                userlikemusic.Parameters.AddWithValue("@musictype", (string)rdr[0]);
                userlikemusic.Parameters.AddWithValue("@subcategory", (string)rdr[1]);
                con1.Open();
                userlikemusic.ExecuteNonQuery(); con1.Close();
            }
        }        
        rdr.Close();    
        con.Close();
    }

}