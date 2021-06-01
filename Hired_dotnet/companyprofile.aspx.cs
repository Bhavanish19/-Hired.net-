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
    public partial class company : System.Web.UI.Page
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
                    Response.Redirect("companylogin.aspx");
                }
                else
                {
                    if (!Page.IsPostBack)
                    {
                        companyDetails();
                    }
                    

                }
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("companylogin.aspx");
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

                SqlCommand cmd = new SqlCommand("SELECT * from company_tbl where company_id='" + Session["username"].ToString().Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    TextBox1.Text = dt.Rows[0]["company_name"].ToString();
                    TextBox2.Text = dt.Rows[0]["company_website"].ToString();
                    TextBox3.Text = dt.Rows[0]["company_con"].ToString();
                    TextBox4.Text = dt.Rows[0]["company_email"].ToString();
                    DropDownList1.SelectedValue = dt.Rows[0]["company_state"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["company_city"].ToString();
                    TextBox7.Text = dt.Rows[0]["company_pincode"].ToString();
                    TextBox5.Text = dt.Rows[0]["company_address"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["company_status"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["company_sector"].ToString();
                    TextBox11.Text = dt.Rows[0]["company_ncap"].ToString();
                    TextBox8.Text = dt.Rows[0]["company_id"].ToString();
                    TextBox9.Text = dt.Rows[0]["password"].ToString();
                    filepath = dt.Rows[0]["company_img_src"].ToString();

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
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("companylogin.aspx");
            }
            else
            {
               
                updateProfileDetails();

            }
        }

        void updateProfileDetails()
        {
            string password = "";
            if (TextBox12.Text.Trim() == "")
            {
                password = TextBox9.Text.Trim();
            }
            else
            {
                password = TextBox12.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //

                string new_file;
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                
                if (filename != "")
                {
                    FileUpload1.SaveAs(Server.MapPath("profile_photos/company/" + filename));
                    new_file = "~/profile_photos/company/" + filename;

                    SqlCommand cmd = new SqlCommand("UPDATE company_tbl SET password=@password, company_name=@company_name, company_website=@company_website, company_con=@company_con, company_email=@company_email, company_state=@company_state, company_city=@company_city, company_pincode=@company_pincode, company_address=@company_address, company_status=@company_status, company_sector=@company_sector, company_ncap=@company_ncap, company_img_src=@company_img_src WHERE company_id='" + Session["username"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@company_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_website", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_con", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@company_city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_status", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@company_sector", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_ncap", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_img_src", new_file);

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

                    SqlCommand cmd = new SqlCommand("UPDATE company_tbl SET password=@password, company_name=@company_name, company_website=@company_website, company_con=@company_con, company_email=@company_email, company_state=@company_state, company_city=@company_city, company_pincode=@company_pincode, company_address=@company_address, company_status=@company_status, company_sector=@company_sector, company_ncap=@company_ncap WHERE company_id='" + Session["username"].ToString().Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@company_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_website", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_con", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@company_city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_status", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@company_sector", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@company_ncap", TextBox11.Text.Trim());

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
    }
}