using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

namespace Hired_dotnet
{
    public partial class adminmain : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("adminlogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        adminDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("adminlogin.aspx");
            }
        }
        
        void adminDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_tbl WHERE admin_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    TextBox1.Text = dt.Rows[0]["admin_id"].ToString();
                    TextBox2.Text = dt.Rows[0]["admin_name"].ToString();
                    TextBox3.Text = Convert.ToDateTime(dt.Rows[0]["admin_dob"]).ToString("dd/MM/yyyy");
                    TextBox4.Text = dt.Rows[0]["admin_email"].ToString();
                    TextBox5.Text = dt.Rows[0]["password"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Admin ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("adminlogin.aspx");
            }
            else
            {
                updateDetails();
            }
        }

        void updateDetails()
        {
            string password = "";
            if (TextBox6.Text.Trim() == "")
            {
                password = TextBox5.Text.Trim();
            }
            else
            {
                password = TextBox6.Text.Trim();
            }
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                
                SqlCommand cmd = new SqlCommand("UPDATE admin_tbl SET password=@password, admin_email=@admin_email WHERE admin_id='" + Session["username"].ToString().Trim() + "'", con);

                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@admin_email", TextBox4.Text.Trim());

                int result = cmd.ExecuteNonQuery();
                con.Close();


                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Invaid entry');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminmain.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminremovemember.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("admindeletejobpost.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("admindeletejobsapp.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminjobinfo.aspx");
        }
    }
}