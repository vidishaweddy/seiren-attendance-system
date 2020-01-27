using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox1.Attributes.Add("onkeypress", "javaScript:return textnumonly(event);");
        TextBox2.Attributes.Add("onkeypress", "javaScript:return textnumonly(event);");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string code;
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("SELECT role from Login where Username='"+TextBox1.Text +"' and Password='"+TextBox2.Text +"' ", cn);
            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            if (rdr.HasRows == true)
            {
                code = rdr[0].ToString();
                cn.Close();
                if (code.Equals("1"))
                    Response.Redirect("MenuDataMahasiswa.aspx");
                else if (code.Equals("2"))
                    Response.Redirect("MenuAbsensi.aspx");
                else
                    Response.Redirect("Browse.aspx");
            }
            else
                Response.Redirect("Index.aspx");
            
        }
    }
}
