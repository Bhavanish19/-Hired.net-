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
    public partial class companysignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkMemberExists())
            {

                Response.Write("<script>alert('Member Already Exist with this Member ID, try other ID');</script>");
            }
            else
            {
                signUpNewMember();
            }

            bool checkMemberExists()
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("SELECT * from company_tbl where company_id='" + TextBox8.Text.Trim() + "';", con);
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

            void signUpNewMember()
            {
                //Response.Write("<script>alert('Testing');</script>");
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    string filepath = "~/book_inventory/books1.png";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    FileUpload1.SaveAs(Server.MapPath("profile_photos/company/" + filename));
                    filepath = "~/profile_photos/company/" + filename;

                    string cmdText = "INSERT INTO company_tbl(company_id,password,company_name,company_website,company_con,company_email,company_state,company_city,company_pincode,company_address,company_status,company_sector,company_ncap,company_img_src,company_account_stat) values(@company_id,@password,@company_name,@company_website,@company_con,@company_email,@company_state,@company_city,@company_pincode,@company_address,@company_status,@company_sector,@company_ncap,@company_img_src,NULL)";
                    SqlCommand cmd = new SqlCommand(cmdText, con);

                    cmd.Parameters.AddWithValue("@company_id", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
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
                    cmd.Parameters.AddWithValue("@company_img_src", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful.');</script>");
                    Response.Redirect("companylogin.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}