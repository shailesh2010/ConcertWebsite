using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class signup : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[user] where uid=@uid", con);
                cmd.Parameters.AddWithValue("@uid", uid.Text);
                con.Open();
                Captcha1.ValidateCaptcha(TextBox5.Text.Trim());
                if (Captcha1.UserValidated)
                {
                    //Label2.ForeColor = System.Drawing.Color.Green;
                    //Label2.Text = "Valid";
                    int i = (int)cmd.ExecuteScalar();
                    if (i > 0)
                    {
                        Label1.Text = "this username already exists.enter another username ";
                    }
                    else
                    {
                        //if (Label2.Text.Equals("valid"))
                        //{
                            SqlCommand submit = new SqlCommand("usersignup", con);
                            //SqlCommand submit = new SqlCommand("Insert into [dbo].[user] values(@uid,@firstname,@lastname,@dob,@email,@city,@aboutself,@signupdate,@password,@picture) ", con);
                            submit.CommandType = CommandType.StoredProcedure;
                            submit.Parameters.AddWithValue("@firstname", firstname.Text);
                            submit.Parameters.AddWithValue("@lastname", lastname.Text);
                            submit.Parameters.AddWithValue("@dob", ASPxCalendar1.SelectedDate);
                            submit.Parameters.AddWithValue("@email", emailid.Text);
                            submit.Parameters.AddWithValue("@city", city.Text);
                            submit.Parameters.AddWithValue("@aboutself", aboutself.Text);
                            if (FileUpload1.FileName != null)
                            {
                                submit.Parameters.AddWithValue("@picture", "~/uploads/" + FileUpload1.FileName);
                            }
                            else
                            {
                                 submit.Parameters.AddWithValue("@picture", "~/uploads/Desert.jpg" );
                            }
                            submit.Parameters.AddWithValue("@uid", uid.Text);
                            submit.Parameters.AddWithValue("@password", password.Text);
                            string fileextension1 = System.IO.Path.GetExtension(FileUpload1.FileName);
                            if (fileextension1.ToLower() == ".jpg" || fileextension1.ToLower() == ".jpeg" || fileextension1.ToLower() == ".png")
                            {
                                FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
                                Label4.Text = "files uploaded";
                            }
                            else
                            {
                                Label4.Text = "only files with .jpg, .jpeg or .png are allowed ";
                                Label4.ForeColor = System.Drawing.Color.Red;
                            }
                            submit.ExecuteNonQuery();
                            Label1.Text = "your account is created";
                            Session["newuid"] = uid.Text;
                            //uid.Text = null;
                            //password.Text = null;
                            //firstname.Text = null;
                            //lastname.Text = null;
                            //city.Text = null;
                            //ASPxCalendar1.SelectedDate = System.DateTime.Today;
                            //emailid.Text = null;
                            //aboutself.Text = null;
                            //rpwd.Text = null;
                            //TextBox5.Text = null;
                            Panel1.Visible = false;
                            LinkButton1.Visible = true;
                        //}
                    }
                }
                else
                {
                    Label2.ForeColor = System.Drawing.Color.Red;
                    Label2.Text = "InValid";
                }
               

            }
        }

    }

    protected void ASPxCalendar1_DayRender(object sender, DevExpress.Web.ASPxEditors.DayRenderEventArgs e)
    {
        if (e.Day.DateTime > DateTime.Now)
        {
            e.Day.Visible = false;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/userlikemusic.aspx");
    }
}