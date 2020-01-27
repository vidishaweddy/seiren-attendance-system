using System;
using System.IO;
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

public partial class AddMK : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox3.Attributes.Add("onkeypress", "javaScript:return numonly(event);");
        TextBox4.Attributes.Add("onkeypress", "javaScript:return numonly(event);");
        if (!IsPostBack)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("select kode_MP 'Kode Mata Pelajaran',nama_MP 'Nama Mata Pelajaran',jumlah_SKS 'Jumlah SKS',semester_MP 'Semester' from MP", con);
            DataTable dtView = new DataTable();
            con.Open();
            da.Fill(dtView);
            con.Close();
            DataGrid.DataSource = dtView;
            DataGrid.DataBind();
        }
        DataGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddMK.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Equals("") || TextBox2.Text.Equals("") || TextBox3.Text.Equals("") || TextBox4.Text.Equals(""))
        {
            String str = "<script> alert('Ada data yang kurang, silakan diperiksa'); </Script>";
            Response.Write(str);
        }
        else
        {
                try
                {
                            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into MP(kode_MP,nama_MP,jumlah_SKS,semester_MP) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                Session["MK"] = TextBox1.Text;
                                Response.Write("<script>if(confirm('Apakah anda ingin menambah kelas untuk matakuliah ini?')) window.location='Tambahkelas.aspx'; else window.location='AddPngjr.aspx'</script>"); ;
                            }
                }
                catch (Exception)
                {
                    String str = "<script> alert('Ada data yang kurang atau tidak sesuai'); </Script>";
                    Response.Write(str);
                }
        }
    }
    ICollection CreateDataSource()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        SqlDataAdapter da = new SqlDataAdapter("select kode_MP 'Kode Mata Pelajaran',nama_MP 'Nama Mata Pelajaran',jumlah_SKS 'Jumlah SKS',semester_MP 'Semester' from MP", con);
        DataTable dtView = new DataTable();
        con.Open();
        da.Fill(dtView);
        con.Close();


        DataView dv = new DataView(dtView);
        return dv;

    }
    public void Grid_Change(Object sender, DataGridPageChangedEventArgs e)
    {

        DataGrid.CurrentPageIndex = e.NewPageIndex;
        DataGrid.DataSource = CreateDataSource();
        DataGrid.DataBind();

    }
}
