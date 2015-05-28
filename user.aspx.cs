using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class user : System.Web.UI.Page
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
                cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Response.Write("Hello " + (string)rdr[0]);
                    if (rdr[5].ToString() == "")
                    {
                        Image1.ImageUrl = "~/uploads/Desert.jpg";
                    }
                    else
                    {
                        Image1.ImageUrl = (string)rdr[5];
                    }
                    Label4.Text = (string)rdr[0];
                    Label5.Text = (string)rdr[1];
                    Label6.Text = "Born on " + rdr[2].ToString().Substring(0,10);
                    Label7.Text = "Lives in " + (string)rdr[3];
                    Label8.Text = "About me :" + (string)rdr[4];                   
                }
                rdr.Close();
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                string s=" ";                
                SqlCommand getmusic = new SqlCommand("select musictype,subcategory from [dbo].[userlikemusic] where uid=@uid",con);
                getmusic.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                con.Open();
                SqlDataReader rdr= getmusic.ExecuteReader();
                while (rdr.Read())
                {
                    s += rdr[0] + " " + rdr[1] + ", "; 
                }
                rdr.Close();
                Label9.Text ="I Love "+ s;
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("recommendedconcert", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                con.Open();
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label10.Text = "No such concert found";
                }
                else
                {
                    string s = "";
                    while (rdr.Read())
                    {
                        using (SqlConnection con1 = new SqlConnection(cs))
                        {
                            SqlCommand getusers = new SqlCommand("getuser", con1);
                            getusers.CommandType = CommandType.StoredProcedure;
                            getusers.Parameters.AddWithValue("@followed", (string)rdr[2]);
                            con1.Open();
                            SqlDataReader rdr1 = getusers.ExecuteReader();
                            while (rdr1.Read())
                            {
                                s = rdr1[0] + " " + rdr1[1];
                            }
                        }
                        HyperLink l1 = new HyperLink();
                        //l1.ID = (string)rdr[1];
                        l1.Text = (string)rdr[1] + " ";
                        l1.NavigateUrl = "~/upcomingconcert.aspx?id=" + (int)rdr[0];
                        Label lbl1 = new Label();
                        //lbl1.ID = Convert.ToDateTime(rdr[3]).ToString().Substring(0, 10);
                        lbl1.Text = Convert.ToDateTime(rdr[3]).ToString().Substring(0, 10) + "  ";
                        Label lbl7 = new Label();
                        //lbl7.ID = rdr[2].ToString();
                        //lbl7.Text = rdr[2].ToString() + "  ";
                        //lbl7.ID = s;
                        lbl7.Text =s+ "  ";
                        Session["userrecommende"] = true;
                        Label lbl2 = new Label();
                        //lbl2.ID = rdr[4].ToString();
                        lbl2.Text = rdr[4].ToString() + "  ";
                        Label lbl3 = new Label();
                        //lbl3.ID = (string)rdr[5];
                        lbl3.Text = (string)rdr[5] + " ";
                        Label lbl4 = new Label();
                        //lbl4.ID = (string)rdr[6];
                        lbl4.Text = (string)rdr[6] + "  ";
                        Label lbl5 = new Label();
                        //lbl5.ID = (string)rdr[7];
                        lbl5.Text = (string)rdr[7] + "  ";
                        Label lbl6 = new Label();
                        //lbl6.ID = (string)rdr[8];
                        lbl6.Text = (string)rdr[8] + "  ";
                        Panel4.Controls.Add(l1);
                        Panel4.Controls.Add(lbl1);
                        Panel4.Controls.Add(lbl7);
                        Panel4.Controls.Add(lbl2);
                        Panel4.Controls.Add(lbl3);
                        Panel4.Controls.Add(lbl4);
                        Panel4.Controls.Add(lbl5);
                        Panel4.Controls.Add(lbl6);
                        Panel4.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("sysrecommendonbandandmusiclike", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                con.Open();
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label11.Text = "No concert found";
                }
                else
                {
                    //string s = "";
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        //l1.ID = (string)rdr[1];
                        l1.Text = (string)rdr[1] + " ";
                        l1.NavigateUrl = "~/upcomingconcert.aspx?id=" + (int)rdr[0];
                        Label lbl1 = new Label();
                        //lbl1.ID = Convert.ToDateTime(rdr[2]).ToString().Substring(0, 10);
                        lbl1.Text = Convert.ToDateTime(rdr[2]).ToString().Substring(0, 10) + "  ";
                        //Label lbl7 = new Label();
                        //lbl7.ID = rdr[2].ToString();
                        //lbl7.Text = rdr[2].ToString() + "  ";
                        //lbl7.ID = s;
                        //lbl7.Text = s + "  ";
                        Label lbl2 = new Label();
                        //lbl2.ID = rdr[3].ToString();
                        lbl2.Text = rdr[3].ToString() + "  ";
                        Label lbl3 = new Label();
                        //lbl3.ID = (string)rdr[4];
                        lbl3.Text = (string)rdr[4] + " ";
                        Label lbl4 = new Label();
                        //lbl4.ID = (string)rdr[5];
                        lbl4.Text = (string)rdr[5] + "  ";
                        Label lbl5 = new Label();
                        //lbl5.ID = (string)rdr[6];
                        lbl5.Text = (string)rdr[6] + "  ";
                        Label lbl6 = new Label();
                        //lbl6.ID = (string)rdr[7];
                        lbl6.Text = (string)rdr[7] + "  ";
                        Panel5.Controls.Add(l1);
                        Panel5.Controls.Add(lbl1);
                        //Panel5.Controls.Add(lbl7);
                        Panel5.Controls.Add(lbl2);
                        Panel5.Controls.Add(lbl3);
                        Panel5.Controls.Add(lbl4);
                        Panel5.Controls.Add(lbl5);
                        Panel5.Controls.Add(lbl6);
                        Panel5.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("concertafterlogout", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                con.Open();
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label12.Text = "No concert found";
                    Panel6.Visible = false;
                }
                else
                {
                    //string s = "";
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        l1.Text = (string)rdr[1] + " ";
                        l1.NavigateUrl = "~/upcomingconcert.aspx?id=" + (int)rdr[0];
                        Label lbl1 = new Label();
                        lbl1.Text = Convert.ToDateTime(rdr[2]).ToString().Substring(0, 10) + "  ";
                        Label lbl2 = new Label();
                        lbl2.Text = rdr[3].ToString() + "  ";
                        Label lbl3 = new Label();
                        lbl3.Text = (string)rdr[4] + " ";
                        Label lbl4 = new Label();
                        lbl4.Text = (string)rdr[5] + "  ";
                        Label lbl5 = new Label();
                        lbl5.Text = (string)rdr[6] + "  ";
                        Label lbl6 = new Label();
                        lbl6.Text = (string)rdr[7] + "  ";
                        Panel6.Controls.Add(l1);
                        Panel6.Controls.Add(lbl1);
                        Panel6.Controls.Add(lbl2);
                        Panel6.Controls.Add(lbl3);
                        Panel6.Controls.Add(lbl4);
                        Panel6.Controls.Add(lbl5);
                        Panel6.Controls.Add(lbl6);
                        Panel6.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("getpost", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                con.Open();
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Panel7.Visible = false;
                }
                else
                {
                    //string s = "";
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        l1.Text = (string)rdr[0] + " "+rdr[1]+" ";
                        l1.NavigateUrl = "~/posts.aspx?id=" + (int)rdr[4];
                        Label lbl1 = new Label();
                        lbl1.Text =rdr[2].ToString()+" ";
                        Label lbl2 = new Label();
                        lbl2.Text = Convert.ToDateTime(rdr[3]).ToString() + "  ";
                        Panel7.Controls.Add(l1);
                        Panel7.Controls.Add(lbl1);
                        Panel7.Controls.Add(lbl2);                       
                        Panel7.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("getuserrecommendedpost", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@uid", (string)Session["uid"]);
                con.Open();
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Panel8.Visible = false;
                }
                else
                {
                    //string s = "";
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        l1.Text = (string)rdr[0] + " " + rdr[1] + " ";
                        l1.NavigateUrl = "~/posts.aspx?id=" + (int)rdr[4];
                        Label lbl1 = new Label();
                        lbl1.Text = rdr[2].ToString() + " ";
                        Label lbl2 = new Label();
                        lbl2.Text = Convert.ToDateTime(rdr[3]).ToString() + "  ";
                        Panel8.Controls.Add(l1);
                        Panel8.Controls.Add(lbl1);
                        Panel8.Controls.Add(lbl2);
                        Panel8.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
        Panel3.Visible = false;
        Panel9.Visible = false;
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand getdetails = new SqlCommand("select firstname,lastname,dob,email,city,aboutself from [dbo].[user] where uid=@uid", con);
            getdetails.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            //getdetails.Parameters.AddWithValue("@uid", "ashm6");
            con.Open();
            SqlDataReader rdr = getdetails.ExecuteReader();
            while (rdr.Read())
            {
                firstname.Text = (string)rdr["firstname"];
                lastname.Text = (string)rdr["lastname"];
                ASPxCalendar1.SelectedDate = (DateTime)rdr["dob"];
                email.Text = (string)rdr["email"];
                city.Text = (string)rdr["city"];
                aboutself.Text = (string)rdr["aboutself"];
            }
            rdr.Close();
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand updateprofile = new SqlCommand("usereditprofile", con);
            updateprofile.CommandType = CommandType.StoredProcedure;
            updateprofile.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            updateprofile.Parameters.AddWithValue("@firstname", firstname.Text);
            updateprofile.Parameters.AddWithValue("@lastname", lastname.Text);
            updateprofile.Parameters.AddWithValue("@dob", ASPxCalendar1.SelectedDate);
            updateprofile.Parameters.AddWithValue("@email", email.Text);
            updateprofile.Parameters.AddWithValue("@city", city.Text);
            updateprofile.Parameters.AddWithValue("@aboutself", aboutself.Text);
            con.Open();
            updateprofile.ExecuteNonQuery();
            Panel1.Visible = false;
            Label1.Text = "profile updated";
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        Panel3.Visible = false;
        Panel9.Visible = false;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getpassword = new SqlCommand("select password from[dbo].[user] where uid=@uid", con);
                getpassword.Parameters.AddWithValue("uid",(string)Session["uid"]);
                con.Open();
                string p = (string)getpassword.ExecuteScalar();
                if (pwd.Text.Equals(p))
                {
                    SqlCommand setpwd = new SqlCommand("userchangepassword", con);
                    setpwd.CommandType = CommandType.StoredProcedure;
                    setpwd.Parameters.AddWithValue("@uid", "ssc496");
                    setpwd.Parameters.AddWithValue("@password", newpwd.Text);
                    setpwd.ExecuteNonQuery();
                    Label2.Text = "password changed succesfully";
                    Panel2.Visible = false;
                }
                else
                {
                    Label2.Text = "old password is incorrect";
                }
            }
        }
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
                SqlCommand changepicture = new SqlCommand("update [dbo].[user] set picture=@picture where uid=@uid", con);
                changepicture.Parameters.AddWithValue("@picture", "~/uploads/" + FileUpload1.FileName);
                changepicture.Parameters.AddWithValue("@uid",(string)Session["uid"]);
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
    protected void Button5_Click(object sender, EventArgs e)
    {
        Panel3.Visible = true;
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel9.Visible = false;
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand logout = new SqlCommand("usrlogout", con);
            logout.CommandType = CommandType.StoredProcedure;
            logout.Parameters.AddWithValue("@uid",(string) Session["uid"]);
            con.Open();
            logout.ExecuteNonQuery();
        }
        Session.Abandon();
        Session.RemoveAll();
        Session.Clear();
        Response.Redirect("~/login.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/searchuser.aspx?search=" + searchuser.Text);
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/searchband.aspx?search=" + searchband.Text);
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/searchconcert.aspx?concert=" + searchconcert.Text);
    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand post = new SqlCommand("usrpost", con);
            post.CommandType = CommandType.StoredProcedure;
            post.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            post.Parameters.AddWithValue("@postdata",userpost.Text);
            con.Open();
            post.ExecuteNonQuery();
            Label13.Text = "Posted successfully";
            userpost.Text = "";
        }
    }
    protected void Button9_Click(object sender, EventArgs e)
    {
        Panel9.Visible = true;
        Panel1.Visible = false;
        Panel2.Visible = false;
        Panel3.Visible = false;
        string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
        using (SqlConnection con = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("select trustscore from [dbo].[trustscore] where uid=@uid ", con);
            cmd.Parameters.AddWithValue("@uid", (string)Session["uid"]);
            con.Open();
            int i = (int)cmd.ExecuteScalar();
            if (i > 10)
            {
                using (SqlConnection con1 = new SqlConnection(cs))
                {
                    SqlCommand cmd1 = new SqlCommand("select musictype,subcategory from [dbo].[genre] ", con1);
                    con1.Open();
                    SqlDataReader rdr = cmd1.ExecuteReader();
                    while (rdr.Read())
                    {
                        DropDownList4.Items.Add(new ListItem((string)rdr[0] + " " + rdr[1], (string)rdr[0] + " " + rdr[1]));
                    }
                }
                using (SqlConnection con2 = new SqlConnection(cs))
                {
                    SqlCommand cmd2 = new SqlCommand("select bid,bname from [dbo].[band] ", con2);
                    con2.Open();
                    SqlDataReader rdr1 = cmd2.ExecuteReader();
                    while (rdr1.Read())
                    {
                        DropDownList5.Items.Add(new ListItem((string)rdr1[1], (string)rdr1[0] ));
                    }
                }
            }
            else
            {
                Label15.Text = "your score is low. use website as much as possible to gain score and gain privelege od adding concert";
                Panel9.Visible = false;
            }
        }
        
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

    }
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.Date < DateTime.Now)
        {
            e.Day.IsSelectable = false;
        }
    }
    protected void Button10_Click(object sender, EventArgs e)
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
                    cmd.Parameters.AddWithValue("@cdate", Calendar1.SelectedDate);
                }
                cmd.Parameters.AddWithValue("@ctime", TimeSpan.Parse(DropDownList1.Text + ":" + DropDownList2.Text + ":00"));
                cmd.Parameters.AddWithValue("@vname", DropDownList3.Text);
                cmd.Parameters.AddWithValue("@bid", DropDownList5.SelectedValue);
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
                    Label14.Text = "only files with .jpg, .jpeg or .png are allowed ";
                    Label7.ForeColor = System.Drawing.Color.Red;
                }
                cmd.ExecuteNonQuery();
            }
            Panel9.Visible = false;
            Label15.Text = "Concert Added";
        }
    }
}