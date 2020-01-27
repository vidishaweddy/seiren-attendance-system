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

public partial class GetMKforPngjr : System.Web.UI.Page
{
    int counter = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label19.Text = Session["kodepngjr"].ToString();
            BindData();
            setGridViewCheckList();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("MenuAbsensi.aspx");
    }
    private void BindData()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        string query = "SELECT m.kode_MP 'Kode Mata Pelajaran',m.nama_MP 'Nama Mata Pelajaran',a.kelas 'Kelas' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP where a.kode_pengajar is null or a.kode_pengajar='"+Session["kodepngjr"].ToString()+"'";
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
        string query1 = "update DataPerkuliahan set kode_pengajar=null where kode_pengajar='" + Session["kodepngjr"] + "'";
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
        InsertProducts(productsToInsert, productsToInsert2);
        BindData();
        String str = "<script> alert('Data sudah diperbaharui'); </Script>";
        Response.Write(str);
        Response.Redirect("EditPngjr.aspx");
    }
    private void InsertProducts(ArrayList a, ArrayList b)
    {
        int i = 0;
        counter = a.Count;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        while (i < counter)
        {
            SqlCommand cmd = new SqlCommand("update DataPerkuliahan set kode_pengajar='" + Session["kodepngjr"].ToString() + "' where kode_MP='"+a[i].ToString()+"' and kelas='"+b[i].ToString()+"'", con);
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
        string query = "SELECT kode_MP FROM DataPerkuliahan a where kode_pengajar='" + Session["kodepngjr"] + "'";
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
