using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class searchconcert : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["uid"] != null)
        {
            string cs = ConfigurationManager.ConnectionStrings["abcd"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("searchpageconcert", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@keyword", "%" + Request.QueryString["concert"] + "%");
                con.Open();
                Session["concert"] = Request.QueryString["concert"];
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label1.Text = "No such concert found";
                }
                else
                {
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        //l1.ID = (string)rdr[1];
                        l1.Text = (string)rdr[1] + " ";
                        l1.NavigateUrl = "~/concert.aspx?id=" + (int)rdr[0];
                        Label lbl1 = new Label();                        
                        lbl1.ID =Convert.ToDateTime(rdr[2]).ToString().Substring(0,10);
                        lbl1.Text = Convert.ToDateTime(rdr[2]).ToString().Substring(0, 10) + "  ";
                        Label lbl2 = new Label();
                        lbl2.ID = rdr[3].ToString();
                        lbl2.Text = rdr[3].ToString() + "  ";
                        Label lbl3 = new Label();
                        lbl3.ID = (string)rdr[4];
                        lbl3.Text = (string)rdr[4] + " ";
                        Label lbl4 = new Label();
                        lbl4.ID = (string)rdr[5];
                        lbl4.Text = (string)rdr[5] + "  ";
                        Label lbl5 = new Label();
                        lbl5.ID = (string)rdr[6];
                        lbl5.Text = (string)rdr[6] + "  ";
                        Label lbl6 = new Label();
                        lbl6.ID = (string)rdr[7];
                        lbl6.Text = (string)rdr[7] + "  ";
                        Panel1.Controls.Add(l1);
                        Panel1.Controls.Add(lbl1);
                        Panel1.Controls.Add(lbl2);
                        Panel1.Controls.Add(lbl3);
                        Panel1.Controls.Add(lbl4);
                        Panel1.Controls.Add(lbl5);
                        Panel1.Controls.Add(lbl6);
                        Panel1.Controls.Add(new LiteralControl("<br>"));
                    }
                }
            }
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand getuser = new SqlCommand("searchpastpageconcert", con);
                getuser.CommandType = CommandType.StoredProcedure;
                getuser.Parameters.AddWithValue("@keyword", "%" + Request.QueryString["concert"] + "%");
                con.Open();
                Session["concert"] = Request.QueryString["concert"];
                SqlDataReader rdr = getuser.ExecuteReader();
                if (!(rdr.HasRows))
                {
                    Label4.Text = "No such concert found";
                }
                else
                {
                    while (rdr.Read())
                    {
                        HyperLink l1 = new HyperLink();
                        //l1.ID = (string)rdr[1];
                        l1.Text = (string)rdr[1] + " ";
                        l1.NavigateUrl = "~/concert.aspx?id=" + (int)rdr[0];
                        Label lbl1 = new Label();
                        lbl1.ID = Convert.ToDateTime(rdr[2]).ToString().Substring(0, 10);
                        lbl1.Text = Convert.ToDateTime(rdr[2]).ToString().Substring(0, 10) + "  ";
                        Label lbl2 = new Label();
                        lbl2.ID = rdr[3].ToString();
                        lbl2.Text = rdr[3].ToString() + "  ";
                        Label lbl3 = new Label();
                        lbl3.ID = (string)rdr[4];
                        lbl3.Text = (string)rdr[4] + " ";
                        Label lbl4 = new Label();
                        lbl4.ID = (string)rdr[5];
                        lbl4.Text = (string)rdr[5] + "  ";
                        Label lbl5 = new Label();
                        lbl5.ID = (string)rdr[6];
                        lbl5.Text = (string)rdr[6] + "  ";
                        Label lbl6 = new Label();
                        lbl6.ID = (string)rdr[7];
                        lbl6.Text = (string)rdr[7] + "  ";
                        Panel2.Controls.Add(l1);
                        Panel2.Controls.Add(lbl1);
                        Panel2.Controls.Add(lbl2);
                        Panel2.Controls.Add(lbl3);
                        Panel2.Controls.Add(lbl4);
                        Panel2.Controls.Add(lbl5);
                        Panel2.Controls.Add(lbl6);
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
}