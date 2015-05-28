using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class band : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["bid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select bname,info,picture from [dbo].[band] where bid=@bid", con);
                cmd.Parameters.AddWithValue("@bid", (string)Session["bid"]);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Response.Write("Hello " + (string)rdr[0]);
                    if (rdr[2].ToString() == "")
                    {
                        Image1.ImageUrl = "~/uploads/Desert.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = (string)rdr[2];
                    }
                    Label4.Text = (string)rdr[0];
                    Label1.Text = (string)rdr[1];
                }
                rdr.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                string s = " ";
                SqlCommand getmusic = new SqlCommand("select musictype,subcategory from [dbo].[bandplays] where bid=@bid", con);
                getmusic.Parameters.AddWithValue("@bid", (string)Session["bid"]);
                con.Open();
                SqlDataReader rdr = getmusic.ExecuteReader();
                while (rdr.Read())
                {
                    s += rdr[0] + " " + rdr[1] + ", ";
                }
                rdr.Close();
                Label6.Text = "We play " + s;
            }
        }
        else
        {
            Response.Redirect("~/bandlogin.aspx");
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel4.Visible = false;
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            string fileextension1 = System.IO.Path.GetExtension(FileUpload1.FileName);
            if (fileextension1.ToLower() == ".jpg" || fileextension1.ToLower() == ".jpeg" || fileextension1.ToLower() == ".png")
            {
                FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
                Label3.Text = "files uploaded";
                SqlCommand changepicture = new SqlCommand("update [dbo].[band] set picture=@picture where bid=@bid", con);
                changepicture.Parameters.AddWithValue("@picture", "~/uploads/" + FileUpload1.FileName);
                changepicture.Parameters.AddWithValue("@bid",(string)Session["bid"]);
                con.Open();
                changepicture.ExecuteNonQuery();
                Panel3.Visible = false;
            }
            else
            {
                Label3.Text = "only files with .jpg, .jpeg or .png are allowed ";
                Label3.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Session.RemoveAll();
        Session.Clear();
        Response.Redirect("~/bandlogin.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel4.Visible = false;
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand getdetails = new SqlCommand("select bname,info from [dbo].[band] where bid=@bid", con);
            getdetails.Parameters.AddWithValue("@bid", (string)Session["bid"]);
            con.Open();
            SqlDataReader rdr = getdetails.ExecuteReader();
            while (rdr.Read())
            {
                bandname.Text = (string)rdr[0];
                bandinfo.Text = (string)rdr[1];
            }
            rdr.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand updateprofile = new SqlCommand("update [dbo].[band] set bname=@bname,info=@info where bid=@bid", con);
            updateprofile.Parameters.AddWithValue("@bid", (string)Session["bid"]);
            updateprofile.Parameters.AddWithValue("@bname", bandname.Text);
            updateprofile.Parameters.AddWithValue("@info", bandinfo.Text);
            con.Open();
            updateprofile.ExecuteNonQuery();
            Panel1.Visible = false;
            Label2.Text = "profile updated";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel4.Visible = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getpassword = new SqlCommand("select password from[dbo].[band] where bid=@bid", con);
                getpassword.Parameters.AddWithValue("bid", (string)Session["bid"]);
                con.Open();
                string p = (string)getpassword.ExecuteScalar();
                if (pwd.Text.Equals(p))
                {
                    SqlCommand setpwd = new SqlCommand("update [dbo].[band] set password=@password where bid=@bid", con);
                    setpwd.Parameters.AddWithValue("@bid", (string)Session["bid"]);
                    setpwd.Parameters.AddWithValue("@password", newpwd.Text);
                    setpwd.ExecuteNonQuery();
                    Label5.Text = "password changed succesfully";
                    Panel2.Visible = false;
                }
                else
                {
                    Label5.Text = "old password is incorrect";
                }
            }
        }
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Panel4.Visible = true;
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("select musictype,subcategory from [dbo].[genre] ", con);           
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                DropDownList4.Items.Add(new ListItem((string)rdr[0] + " " + rdr[1], (string)rdr[0] + " " + rdr[1]));
            }
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("addconcerts", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Calendar1.SelectedDate == null)
                {
                    cmd.Parameters.AddWithValue("@cdate", DateTime.Now);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@cdate",Calendar1.SelectedDate);
                }
                cmd.Parameters.AddWithValue("@ctime", TimeSpan.Parse(DropDownList1.Text + ":" + DropDownList2.Text + ":00"));
                cmd.Parameters.AddWithValue("@vname", DropDownList3.Text);
                cmd.Parameters.AddWithValue("@bid", (string)Session["bid"]);
                if (FileUpload1.FileName != null)
                {
                    cmd.Parameters.AddWithValue("@adpicture", "~/uploads/" + FileUpload2.FileName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@adpicture", "~/uploads/Desert.jpg");

                }
                cmd.Parameters.AddWithValue("@ticketprice", int.Parse(TextBox1.Text));
                string s = DropDownList4.Text;
                int a = s.Length;
                int b = s.IndexOf(" ");
                a = a - b - 1;
                string y = s.Substring(0, b);
                string z = s.Substring(b + 1, a);
                cmd.Parameters.AddWithValue("@musictype", y);
                cmd.Parameters.AddWithValue("@subcategory", z);             
                con.Open();
                string fileextension1 = System.IO.Path.GetExtension(FileUpload2.FileName);
                if (fileextension1.ToLower() == ".jpg" || fileextension1.ToLower() == ".jpeg" || fileextension1.ToLower() == ".png")
                {
                    FileUpload2.SaveAs(Server.MapPath("~/uploads/" + FileUpload2.FileName));
                }
                else
                {
                    Label7.Text = "only files with .jpg, .jpeg or .png are allowed ";
                    Label7.ForeColor = System.Drawing.Color.Red;
                }
                cmd.ExecuteNonQuery();
            }
            Panel4.Visible = false;
            Label8.Text = "Concert Added";
        }
    }
  
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.Date < DateTime.Now)
        {
            e.Day.IsSelectable = false;
        }
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
}