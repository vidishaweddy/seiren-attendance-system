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

public partial class DelMK : System.Web.UI.Page
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
        Response.Redirect("DelMK.aspx");
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
                                command.CommandText = "delete from MP where kode_MP='" + TextBox1.Text + "'";
                                command.ExecuteReader();
                                cn.Close();
                                Session["MK"] = TextBox1.Text;
                                Response.Redirect("DelMK.aspx");
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT nama_MP,jumlah_SKS,semester_MP from MP where kode_MP='" + TextBox1.Text + "'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();

                TextBox3.Text = rdr[1].ToString();
                TextBox4.Text = rdr[2].ToString();
                TextBox2.Text = rdr[0].ToString();
            }
        }
        catch (Exception)
        {
            String str = "<script> alert('Data dengan nomor induk ini tidak ada'); </Script>";
            Response.Write(str);
            setEnable(false);
        }
    }
    void setEnable(bool flag)
    {
        TextBox2.Enabled = flag;
        TextBox3.Enabled = flag;
        TextBox4.Enabled = flag;
    }
}
