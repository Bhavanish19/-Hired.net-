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
    public partial class candidateprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        string filepath;
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
                    if (!Page.IsPostBack)
                    {
                        candidateDetails();
                    }

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("candidatelogin.aspx");
            }
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM candidate_tbl WHERE candidate_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    TextBox1.Text = dt.Rows[0]["candidate_name"].ToString();
                    TextBox2.Text = Convert.ToDateTime(dt.Rows[0]["dob"]).ToString("dd/MM/yyyy");
                    TextBox3.Text = dt.Rows[0]["candidate_con"].ToString();
                    TextBox4.Text = dt.Rows[0]["candidate_email"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["gender"].ToString().Trim();
                    DropDownList1.SelectedValue = dt.Rows[0]["candidate_state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["candidate_city"].ToString();
                    TextBox7.Text = dt.Rows[0]["candidate_pincode"].ToString();
                    TextBox5.Text = dt.Rows[0]["candidate_address"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["candidate_type"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["highest_qualification"].ToString();
                    TextBox8.Text = dt.Rows[0]["candidate_id"].ToString();
                    TextBox9.Text = dt.Rows[0]["password"].ToString();
                    filepath = dt.Rows[0]["candidate_img_src"].ToString();
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidateprofile.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("candidatejobsapplication.aspx");
        }

        void updateProfileDetails()
        {
            string password = "";
            if (TextBox11.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox11.Text.Trim();
            }
            try
            {
                
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                string new_file;
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                
                if (filename != null && filename.Trim() != "")
                {
                    FileUpload1.SaveAs(Server.MapPath("profile_photos/candidate/" + filename));
                    new_file = "~/profile_photos/candidate/" + filename;

                    SqlCommand cmd = new SqlCommand("UPDATE candidate_tbl SET password=@password, candidate_name=@candidate_name, candidate_con=@candidate_con, candidate_email=@candidate_email, gender=@gender, candidate_state=@candidate_state, candidate_city=@candidate_city, candidate_pincode=@candidate_pincode, candidate_address=@candidate_address, candidate_type=@candidate_type, highest_qualification=@highest_qualification, candidate_img_src=@candidate_img_src WHERE candidate_id='" + Session["username"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@candidate_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_con", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@candidate_state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@candidate_city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_type", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@highest_qualification", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_img_src", new_file);

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
                else
                {
                    new_file = filepath;

                    SqlCommand cmd = new SqlCommand("UPDATE candidate_tbl SET password=@password, candidate_name=@candidate_name, candidate_con=@candidate_con, candidate_email=@candidate_email, gender=@gender, candidate_state=@candidate_state, candidate_city=@candidate_city, candidate_pincode=@candidate_pincode, candidate_address=@candidate_address, candidate_type=@candidate_type, highest_qualification=@highest_qualification WHERE candidate_id='" + Session["username"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@candidate_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_con", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@candidate_state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@candidate_city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_type", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@highest_qualification", TextBox10.Text.Trim());

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
                Response.Redirect("candidatelogin.aspx");
            }
            else
            {
                updateProfileDetails();
            }
        }
    }
}