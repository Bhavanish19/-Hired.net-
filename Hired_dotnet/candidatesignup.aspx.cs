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
    public partial class candidatesignup : System.Web.UI.Page
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
                    SqlCommand cmd = new SqlCommand("SELECT * from candidate_tbl where candidate_id='" + TextBox8.Text.Trim() + "';", con);
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
                    FileUpload1.SaveAs(Server.MapPath("profile_photos/candidate/" + filename));
                    filepath = "~/profile_photos/candidate/" + filename;

                    string cmdText = "INSERT INTO candidate_tbl(candidate_id,password,candidate_name,dob,candidate_con,candidate_email,gender,candidate_state,candidate_city,candidate_pincode,candidate_address,candidate_type,highest_qualification,candidate_img_src,candidate_account_stat) values(@candidate_id,@password,@candidate_name,@dob,@candidate_con,@candidate_email,@gender,@candidate_state,@candidate_city,@candidate_pincode,@candidate_address,@candidate_type,@highest_qualification,@candidate_img_src,NULL)";
                    SqlCommand cmd = new SqlCommand(cmdText, con);

                    cmd.Parameters.AddWithValue("@candidate_id", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_name", TextBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_con", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_email", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@candidate_state", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@candidate_city", TextBox6.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_pincode", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_address", TextBox5.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_type", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@highest_qualification", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@candidate_img_src", filepath);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Sign Up Successful.');</script>");
                    Response.Redirect("candidatelogin.aspx");

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
        }
    }
}