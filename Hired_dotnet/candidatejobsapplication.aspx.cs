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


namespace Hired_dotnet
{
    public partial class candidatejobsapplication : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string cand_id, cand_name, cand_photo;
        string job_id, company_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("candidatelogin.aspx");
                }
                else
                {
                    candidateDetails();
                    GridView1.DataBind();
                    GridView2.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("candidatelogin.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidateprofile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatejobsapplication.aspx");
        }

        void candidateDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from candidate_tbl where candidate_id='" + Session["username"].ToString().Trim() + "';", con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    cand_name = dt.Rows[0]["candidate_name"].ToString();
                    cand_id = dt.Rows[0]["candidate_id"].ToString();
                    cand_photo = dt.Rows[0]["candidate_img_src"].ToString();

                    TextBox2.Text = dt.Rows[0]["candidate_id"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Candidate ID');</script>");
                }
            }

            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }

        }

        void job_companyDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from job_tbl where job_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    job_id = dt.Rows[0]["job_id"].ToString();
                    company_id = dt.Rows[0]["company_id"].ToString();

                    TextBox3.Text = dt.Rows[0]["company_name"].ToString();
                    TextBox4.Text = dt.Rows[0]["company_id"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Company ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool checkIfJobApplied()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from jobapp_tbl where job_id='" + TextBox1.Text.Trim() + "' AND candidate_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

    }

}