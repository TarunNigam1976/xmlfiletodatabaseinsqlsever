using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Data.SqlTypes;

namespace XMLTODataBase
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
            string filePath = Server.MapPath("~/Uploads/") + fileName;
            FileUpload1.SaveAs(filePath);
            string xml = File.ReadAllText(filePath);
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);

            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand("InsertXML");
            command.Connection = con;
            command.CommandType = CommandType.StoredProcedure;
            using (MemoryStream stream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(stream, Encoding.UTF8))
                {
                    writer.Write(xml);
                    writer.Flush();
                    stream.Position = 0;

                    SqlParameter parameter = new SqlParameter("@xml", SqlDbType.Text);
                    parameter.Value = new SqlXml(stream);
                    //command.Parameters.Add("@name", SqlDbType.VarChar).Value = "Products.xml";
                    command.Parameters.Add(parameter);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
