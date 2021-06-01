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
    public partial class dummy : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Response.Write("<script>alert('Hello and welcome back to my youtube channel!');</script>");
            //}

            Response.Write("<script>alert('Hello and welcome back to my youtube channel!');</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                FileInfo fi = new FileInfo(FileUpload1.FileName);
                byte[] document_content = FileUpload1.FileBytes;

                string name = fi.Name;
                string extn = fi.Extension;

                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("save_doc", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                    cmd.Parameters.Add("@content", SqlDbType.VarBinary).Value = document_content;
                    cmd.Parameters.Add("@extn", SqlDbType.VarChar).Value = extn;

                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
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
                DataTable dt = new DataTable();
                using (SqlConnection cn = new SqlConnection(strcon))
                {
                    SqlCommand cmd = new SqlCommand("get_doc", cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 12;
                    cn.Open();

                    SqlDataReader reader = cmd.ExecuteReader();

                    dt.Load(reader);

                    if (dt.Rows.Count > 0)
                    {
                        string name = "custom_name.pdf";
                        byte[] documentBytes = (byte[])dt.Rows[0]["document_content"];

                        Response.ClearContent();
                        Response.ContentType = "application/octetstream";
                        Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}", name));
                        Response.AddHeader("Content-Length", documentBytes.Length.ToString());

                        Response.BinaryWrite(documentBytes);
                        Response.Flush();
                        Response.Close();
                    }

                    else
                    {
                        Response.Write("<script>alert('File not found!');</script>");
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