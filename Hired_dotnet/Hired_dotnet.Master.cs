using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Hired_dotnet
{
    public partial class Hired_dotnet : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty((string)Session["role"]))
                {
                    LinkButton4.Visible = true; // view jobs link button
                    LinkButton1.Visible = true; // login link button

                    LinkButton2.Visible = false; // view profile link button
                    LinkButton3.Visible = false; // logout link button
                    LinkButton7.Visible = false; // hello user link button

                }
                else if ((Session["role"].ToString()).Equals("candidate"))
                {
                    LinkButton4.Visible = true; // view jobs link button
                    LinkButton1.Visible = false; // login link button

                    LinkButton2.Visible = true; // view profile link button
                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                }
                else if ((Session["role"].ToString()).Equals("company"))
                {
                    LinkButton4.Visible = true; // view jobs link button
                    LinkButton1.Visible = false; // login link button

                    LinkButton2.Visible = true; // view profile link button
                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello " + Session["username"].ToString();
                }
                else if ((Session["role"].ToString()).Equals("admin"))
                {
                    LinkButton4.Visible = true; // view jobs link button
                    LinkButton1.Visible = false; // login link button

                    LinkButton2.Visible = true; // view profile link button
                    LinkButton3.Visible = true; // logout link button
                    LinkButton7.Visible = true; // hello user link button
                    LinkButton7.Text = "Hello" + Session["username"].ToString();
                }
                
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('There was some error while Loading.');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatelogin.aspx");
            //Response.Write("<script type='text/javascript'>window.open('candidatelogin.aspx');</script>");
            //OnClientClick="window.open('Default2.aspx')"
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["fullname"] = "";
            Session["role"] = "";

            LinkButton4.Visible = true; // view jobs link button
            LinkButton1.Visible = true; // login link button

            LinkButton2.Visible = false; // view profile link button
            LinkButton3.Visible = false; // logout link button
            LinkButton7.Visible = false; // hello user link button

            Response.Redirect("homepage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (Session["role"].Equals("candidate"))
            {
                Response.Redirect("candidateprofile.aspx");
            }

            else if (Session["role"].Equals("company"))
            {
                Response.Redirect("companyprofile.aspx");
            }

            else if (Session["role"].Equals("admin"))
            {
                Response.Redirect("adminmain.aspx");
            }

            else
            {
                Response.Redirect("homepage.aspx");
            }
        }
    }
}