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

public partial class DelPngjr : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBox6.Attributes.Add("onkeypress", "javaScript:return numonly(event);");
        if (!IsPostBack)
        {
            setEnable(false);
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("select kode_pengajar 'Nomor Induk',nama 'Nama Pengajar',no_telp 'No Telepon',alamat 'Alamat' from Pengajar", con);
            DataTable dtView = new DataTable();
            con.Open();
            da.Fill(dtView);
            con.Close();
            DataGrid.DataSource = dtView;
            DataGrid.DataBind();
        }
        DataGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        dropdownlistdatabind();
    }

    protected void ButtonShow_Click(object sender, EventArgs e)
    {
        String savePath = @"C:\Users\VidiValianto\Documents\skripsi\Seiren\temporary\";

        if (FileUpload1.HasFile)
        {
            string fileExtension = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).Replace(".", string.Empty).ToLower();
            if (fileExtension.Equals("jpg") || fileExtension.Equals("jpeg") || fileExtension.Equals("png"))
            {
                String fileName = FileUpload1.FileName;
                savePath += fileName;
                FileUpload1.SaveAs(savePath);
                Image1.ImageUrl = @"~\temporary\" + FileUpload1.FileName;
                Session["image"] = savePath;
                Session["ext"] = fileExtension;
            }
            else
            {
                Session["image"] = "";
                String str = "<script> alert('Tipe file gambar tidak valid atau tidak disupport'); </Script>";
                Response.Write(str);
            }
        }
        else
        {
            Session["image"] = "";
            String str = "<script> alert('Tidak ada gambar yang ditampilkan'); </Script>";
            Response.Write(str);
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("DelPngjr.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {

            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            {

                cn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = cn;
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from Pengajar where kode_pengajar='" + TextBox1.Text + "'";
                command.ExecuteReader();
                cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update DataPerkuliahan set kode_pengajar=NULL where kode_pengajar='" + TextBox1.Text + "'";
                cmd.ExecuteReader();
                cn.Close();
                Response.Redirect("DelPngjr.aspx");
            }

        }
        catch (Exception)
        {
            String str = "<script> alert('Data tak dapat dihapus'); </Script>";
            Response.Write(str);
        }  
    }
    ICollection CreateDataSource()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        SqlDataAdapter da = new SqlDataAdapter("select kode_pengajar 'Nomor Induk',nama 'Nama Pengajar',no_telp 'No Telepon',alamat 'Alamat' from Pengajar", con);
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
                SqlCommand cmd = new SqlCommand("SELECT nama,no_telp,alamat,agama,TTL,foto_dir,email from Pengajar where kode_pengajar='" + TextBox1.Text + "'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();

                TextBox3.Text = rdr[4].ToString().Substring(0, rdr[4].ToString().IndexOf(","));
                TextBox4.Value = rdr[4].ToString().Substring(rdr[4].ToString().IndexOf(",") + 2);
                TextBox2.Text = rdr[0].ToString();
                TextBox6.Text = rdr[1].ToString();
                TextBox7.Text = rdr[2].ToString();
                TextBox5.Text = rdr[3].ToString();
                TextBox8.Text = rdr[6].ToString();
                if (!rdr[5].ToString().Equals(""))
                {
                    Image1.ImageUrl = rdr[5].ToString();
                    string destPath = @"C:\Users\VidiValianto\Documents\skripsi\Seiren";
                    Session["ext"] = rdr[5].ToString().Substring(rdr[5].ToString().IndexOf(".") + 1);
                    Session["image"] = destPath + rdr[5].ToString().Substring(rdr[5].ToString().IndexOf("~") + 1);
                    Session["kodepljr"] = TextBox1.Text;

                }
                else
                {
                    Session["ext"] = "";
                    Session["image"] = "";
                }

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
        if (flag == true)
            TextBox4.Disabled = false;
        else
            TextBox4.Disabled = true;
        TextBox5.Enabled = flag;
        TextBox6.Enabled = flag;
        TextBox7.Enabled = flag;
        TextBox8.Enabled = flag;
        FileUpload1.Enabled = flag;
        mk.Visible = flag;
    }
}
