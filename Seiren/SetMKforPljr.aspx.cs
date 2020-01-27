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

public partial class SetMKforPljr : System.Web.UI.Page
{
    int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
            setGridViewCheckList();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditMhs.aspx");
    }
    private void BindData()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        string query = "SELECT m.kode_MP 'Kode Mata Pelajaran',m.nama_MP 'Nama Mata Pelajaran',a.kelas 'Kelas' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP";
        SqlDataAdapter da = new SqlDataAdapter(query, con);
        DataTable dtView = new DataTable();
        con.Open();
        da.Fill(dtView);
        con.Close();
        DataView dv = new DataView(dtView);
        GridView1.DataSource = dv;
        GridView1.DataBind();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ArrayList productsToInsert = new ArrayList();
        ArrayList productsToInsert2 = new ArrayList();
        SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        string query1 = "DELETE FROM Absensi where no_induk='" + Session["kodepljr"] + "' and no_pertemuan='0'";
        SqlCommand da1 = new SqlCommand(query1, con2);
        con2.Open();
        SqlDataReader rdr2 = da1.ExecuteReader(CommandBehavior.CloseConnection);
        con2.Close();
        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkInsert = (CheckBox)row.Cells[3].FindControl("chkInsert");

                if (chkInsert != null)
                {
                    if (chkInsert.Checked)
                    {
                        string productId = row.Cells[0].Text;
                        productsToInsert.Add(productId);
                        string kelasId = row.Cells[2].Text;
                        productsToInsert2.Add(kelasId);
                    }
                }
            }
        }
        InsertProducts(productsToInsert,productsToInsert2);
        BindData();
        Response.Redirect("EditMhs.aspx");
    }
    private void InsertProducts(ArrayList a,ArrayList b)
    {
        int i = 0;
        counter = a.Count;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        while (i < counter)
        {
            SqlCommand cmd = new SqlCommand("INSERT into Absensi(no_induk,kode_MP,no_pertemuan,kelas) values('" + Session["kodepljr"].ToString() + "','" + a[i].ToString() + "','0','" + b[i].ToString() + "')", con);
            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            con.Close();
            i++;
        }
    }
    private void setGridViewCheckList()
    {
        ArrayList Link = new ArrayList();
        int temp = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        string query = "SELECT kode_MP FROM Absensi a where no_induk='" + Session["kodepljr"] + "' and no_pertemuan='0'";
        SqlCommand da = new SqlCommand(query, con);
        con.Open();
        SqlDataReader rdr = da.ExecuteReader(CommandBehavior.CloseConnection);
        while (rdr.Read())
        {
            Link.Add(rdr[0].ToString());
        }
        con.Close();

        foreach (GridViewRow row in GridView1.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                if (temp < Link.Count)
                {
                    if (row.Cells[0].Text.Equals(Link[temp]))
                    {
                        CheckBox chkInsert = (CheckBox)row.Cells[3].FindControl("chkInsert");
                        if (!chkInsert.Checked)
                        {
                            chkInsert.Checked = true;
                            temp++;
                        }
                    }
                }
            }

        }
    }
}
