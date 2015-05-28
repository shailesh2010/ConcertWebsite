using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class searchband : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("select bid,bname,info from [dbo].[band] where bid like @keyword or bname like @keyword ", con);
                getuser.Parameters.AddWithValue("@keyword", "%" + Request.QueryString["search"] + "%");
                con.Open();
                Session["searchband"] = Request.QueryString["search"];
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label1.Text = "No such band found";
                }
                else
                {
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        l1.ID = (string)rdr[0];
                        l1.Text = (string)rdr[0] + " ";
                        l1.NavigateUrl = "~/anotherband.aspx?id=" + (string)rdr[0];
                        Label lbl1 = new Label();
                        lbl1.ID = (string)rdr[1];
                        lbl1.Text = (string)rdr[1] + " ";
                        Label lbl2 = new Label();
                        lbl2.ID = (string)rdr[2];
                        lbl2.Text = (string)rdr[2] + " ";
                        Panel1.Controls.Add(l1);
                        Panel1.Controls.Add(lbl1);
                        Panel1.Controls.Add(lbl2);
                        Panel1.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/login.aspx");
        }
    }
}