using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class bandsignup : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select count(*) from [dbo].[band] where bid=@bid", con);
                cmd.Parameters.AddWithValue("@bid", bandid.Text);
                con.Open();

                int i = (int)cmd.ExecuteScalar();
                if (i > 0)
                {
                    Label1.Text = "this bandid already exists.enter another bandid ";
                }
                else
                {
                    SqlCommand submit = new SqlCommand("bandsignup", con);
                    submit.CommandType = CommandType.StoredProcedure;
                    submit.Parameters.AddWithValue("@bid", bandid.Text);
                    submit.Parameters.AddWithValue("@bname", bandname.Text);
                    submit.Parameters.AddWithValue("@info", bandinfo.Text);
                    if (FileUpload1.FileName != null)
                    {
                        submit.Parameters.AddWithValue("@picture", "~/uploads/" + FileUpload1.FileName);
                    }
                    else
                    {
                        submit.Parameters.AddWithValue("@picture", "~/uploads/Desert.jpg");
                    }

                    submit.Parameters.AddWithValue("@password", password.Text);
                    string fileextension1 = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (fileextension1.ToLower() == ".jpg" || fileextension1.ToLower() == ".jpeg" || fileextension1.ToLower() == ".png")
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/uploads/" + FileUpload1.FileName));
                    }
                    else
                    {
                        Label2.Text = "only files with .jpg, .jpeg or .png are allowed ";
                        Label2.ForeColor = System.Drawing.Color.Red;
                    }
                    submit.ExecuteNonQuery();
                    Label1.Text = "your account is created";
                    Session["newbandid"] = bandid.Text;
                    Panel1.Visible = false;
                    LinkButton1.Visible = true;
                }
            }
        }
        else
        {
            Label1.ForeColor = System.Drawing.Color.Red;
            Label1.Text = "InValid";
        }


    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/userlikemusic.aspx");
    }
}
