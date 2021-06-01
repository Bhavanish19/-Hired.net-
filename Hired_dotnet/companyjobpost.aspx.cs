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
    public partial class companyjobpost : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string company_id, company_name, company_image;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Write("<script>alert('Session Expired Login Again');</script>");
                    Response.Redirect("companylogin.aspx");
                }
                else
                {
                    GridView1.DataBind();
                    GridView2.DataBind();
                    companyDetails();
                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("companylogin.aspx");
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyprofile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyappliedcands.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("companyjobpost.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkIfJobExists())
            {
                Response.Write("<script>alert('Job Already Exist with this Job ID. You can update its details OR delete the job!');</script>");
                getJobByID();

            }

            else
            {
                Response.Write("<script>alert('Job does Not Exist with this Job ID. You can add a new job!');</script>");
                companyDetails();
            }
        }

        bool checkIfJobExists()
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

        void getJobByID()
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
                    TextBox1.Text = dt.Rows[0]["job_id"].ToString();
                    TextBox7.Text = dt.Rows[0]["job_title"].ToString();
                    TextBox3.Text = dt.Rows[0]["company_id"].ToString();
                    TextBox4.Text = dt.Rows[0]["company_name"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["job_type"].ToString().Trim();
                    TextBox13.Text = dt.Rows[0]["experience_req"].ToString();
                    TextBox14.Text = dt.Rows[0]["age_criteria"].ToString();
                    TextBox15.Text = dt.Rows[0]["skills_req"].ToString();
                    TextBox16.Text = dt.Rows[0]["description"].ToString();
                    TextBox17.Text = dt.Rows[0]["job_post"].ToString();
                    TextBox18.Text = dt.Rows[0]["salary"].ToString();
                    TextBox19.Text = dt.Rows[0]["duration"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Job ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string cmdText = "INSERT INTO job_tbl(job_id,company_id,company_name,job_title,job_type,experience_req,age_criteria,skills_req,description,salary,duration,job_post,company_img) values (@job_id,@company_id,@company_name,@job_title,@job_type,@experience_req,@age_criteria,@skills_req,@description,@salary,@duration,@job_post,@company_img)";
                SqlCommand cmd = new SqlCommand(cmdText, con);

                companyDetails();
                companyImage();

                cmd.Parameters.AddWithValue("@job_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@company_id", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@company_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@job_title", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@job_type", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@experience_req", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@age_criteria", TextBox14.Text.Trim());
                cmd.Parameters.AddWithValue("@skills_req", TextBox15.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox16.Text.Trim());
                cmd.Parameters.AddWithValue("@salary", TextBox18.Text.Trim());
                cmd.Parameters.AddWithValue("@duration", TextBox19.Text.Trim());
                cmd.Parameters.AddWithValue("@job_post", TextBox17.Text.Trim());
                cmd.Parameters.AddWithValue("@company_img", company_image);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Job Posted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                companyImage();

                SqlCommand cmd = new SqlCommand("UPDATE job_tbl SET job_title=@job_title, job_type=@job_type, experience_req=@experience_req, age_criteria=@age_criteria, skills_req=@skills_req, description=@description, salary=@salary, duration=@duration, job_post=@job_post, company_img=@company_img WHERE job_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@job_title", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@job_type", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@experience_req", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@age_criteria", TextBox14.Text.Trim());
                cmd.Parameters.AddWithValue("@skills_req", TextBox15.Text.Trim());
                cmd.Parameters.AddWithValue("@description", TextBox16.Text.Trim());
                cmd.Parameters.AddWithValue("@salary", TextBox18.Text.Trim());
                cmd.Parameters.AddWithValue("@duration", TextBox19.Text.Trim());
                cmd.Parameters.AddWithValue("@job_post", TextBox17.Text.Trim());
                cmd.Parameters.AddWithValue("@company_img", company_image);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Job Updated Successfully');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox7.Text = "";
            TextBox13.Text = "";
            TextBox14.Text = "";
            TextBox15.Text = "";
            TextBox16.Text = "";
            TextBox17.Text = "";
            TextBox18.Text = "";
            TextBox19.Text = "";
            DropDownList2.SelectedValue = "Select";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkIfJobExists())
            {
                getJobByID();

            }

            deleteJob();
        }

        void deleteJob()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from job_tbl WHERE job_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                
                Response.Write("<script>alert('Job Deleted Successfully');</script>");
                clearForm();
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void companyDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT company_id, company_name from company_tbl where company_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    company_name = dt.Rows[0]["company_name"].ToString();
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

        void companyImage()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT company_img_src from company_tbl where company_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    company_image = dt.Rows[0]["company_img_src"].ToString();
                    GridView2.DataBind();

                }
                else
                {
                    Response.Write("<script>alert('Invalid Complete ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}