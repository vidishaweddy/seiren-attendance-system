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

public partial class _Default : System.Web.UI.Page
{
    int prodicode, fakcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["barcode"] = "";
        Session["fingerprint"] = "";
        TextBox6.Attributes.Add("onkeypress", "javaScript:return numonly(event);");
        TextBox7.Attributes.Add("onkeypress", "javaScript:return numonly(event);");
        TextBox8.Attributes.Add("onkeypress", "javaScript:return deconly(event);");
        if (!IsPostBack)
        {
            setData();
            dropdownlistdatabind();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
            SqlDataAdapter da = new SqlDataAdapter("select d.no_induk 'Nomor Induk',nama 'Nama Mahasiswa',case when d.kodefingerprint is null then 'Tidak ada' else 'Ada' end 'Data Fingerprint',case when d.kodebarcode is null then 'Tidak ada' else 'Ada' end 'Data Barcode' from DataAbsensiPelajar d join Pelajar p on d.no_induk=p.no_induk", con);
            DataTable dtView = new DataTable();
            con.Open();
            da.Fill(dtView);
            con.Close();
            DataGrid.DataSource = dtView;
            DataGrid.DataBind();
        }
            DataGrid.PageIndexChanged += new DataGridPageChangedEventHandler(this.Grid_Change);
    }
    void dropdownlistdatabind()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("SELECT Nama_Prodi from Prodi p join Fakultas f on p.Id_Fakultas=f.Id_Fakultas where f.Nama_Fakultas='" + DropDownList1.Text + "'", cn);
            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            DropDownList2.DataSource = rdr;
            DropDownList2.DataBind();
            cn.Close();
        }
        
    }
    void setData()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("SELECT Nama_Fakultas from Fakultas", cn);
            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
                DropDownList1.DataSource = rdr;
                DropDownList1.DataBind();
            cn.Close();
        }
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
        Response.Redirect("AddMhs.aspx");
    }
    void getId()
    {
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("SELECT Id_Fakultas from Fakultas where Nama_Fakultas='"+DropDownList1.Text+"'", cn);
            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            rdr.Read();
            fakcode = int.Parse(rdr[0].ToString());
            cn.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT Id_Prodi from Prodi where Nama_Prodi='" + DropDownList2.Text + "'", cn);
            cn.Open();
            SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
            rdr2.Read();
            prodicode = int.Parse(rdr2[0].ToString());
            cn.Close();

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Equals("") || TextBox2.Text.Equals("") || TextBox3.Text.Equals("") || TextBox4.Value.Equals("") || TextBox5.Text.Equals("") || TextBox6.Text.Equals("") || TextBox7.Text.Equals("") || TextBox8.Text.Equals("") || TextBox9.Text.Equals("") || TextBox10.Text.Equals("") || TextBox11.Text.Equals("") || TextBox12.Text.Equals(""))
        {
            String str = "<script> alert('Ada data yang kurang, silakan diperiksa'); </Script>";
            Response.Write(str);
        }
        else
        {
            if (TextBox11.Text.Contains("@") && TextBox11.Text.Contains("."))
            {
                try
                {
                    string destPath = @"C:\Users\VidiValianto\Documents\skripsi\Seiren\images\";
                    string dest=@"~\images\";
                    string TTL = TextBox3.Text + ", " + TextBox4.Value.ToString();
                    getId();
                    if (Session["image"].ToString().Equals(""))
                    {
                        if (FileUpload1.HasFile)
                        {
                            string fileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).Replace(".", string.Empty).ToLower();
                            destPath += TextBox1.Text + "." + fileExt;
                            dest +=TextBox1.Text + "." + fileExt;
                            FileUpload1.SaveAs(destPath);
                            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Pelajar(no_induk,nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Id_Fakultas,Id_Prodi,semester,IPK,foto_dir,email) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox6.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "','" + TextBox5.Text + "','" + TTL + "','" + TextBox9.Text + "','" + fakcode + "','" + prodicode + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + dest + "','" + TextBox11.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                cn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = cn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "insert into DataAbsensiPelajar(no_induk,kodefingerprint,kodebarcode) values('" + TextBox1.Text + "',NULL,NULL)";
                                cmd.ExecuteReader();
                                cn.Close();
                                Response.Redirect("AddMhs.aspx");
                            }
                        }
                        else
                        {
                            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Pelajar(no_induk,nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Id_Fakultas,Id_Prodi,semester,IPK,foto_dir,email) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox6.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "','" + TextBox5.Text + "','" + TTL + "','" + TextBox9.Text + "','" + fakcode + "','" + prodicode + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + Session["image"].ToString() + "','" + TextBox11.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                cn.Open();
                                SqlCommand cmd=new SqlCommand();
                                cmd.Connection=cn;
                                cmd.CommandType=CommandType.Text;
                                cmd.CommandText = "insert into DataAbsensiPelajar(no_induk,kodefingerprint,kodebarcode) values('"+TextBox1.Text+"',NULL,NULL)";
                                cmd.ExecuteReader();
                                cn.Close();
                                Response.Redirect("AddMhs.aspx");
                            }
                        }
                    }
                    else
                    {

                        if (FileUpload1.HasFile)
                        {
                            string fileExt = System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName).Replace(".", string.Empty).ToLower();
                            destPath += TextBox1.Text + "." + fileExt;
                            dest += TextBox1.Text + "." + fileExt;
                            FileUpload1.SaveAs(destPath);
                            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Pelajar(no_induk,nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Id_Fakultas,Id_Prodi,semester,IPK,foto_dir,email) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox6.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "','" + TextBox5.Text + "','" + TTL + "','" + TextBox9.Text + "','" + fakcode + "','" + prodicode + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + dest + "','" + TextBox11.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                cn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = cn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "insert into DataAbsensiPelajar(no_induk,kodefingerprint,kodebarcode) values('" + TextBox1.Text + "',NULL,NULL)";
                                cmd.ExecuteReader();
                                cn.Close();
                                Response.Redirect("AddMhs.aspx");
                            }
                        }
                        else
                        {
                            destPath += TextBox1.Text + "." + Session["ext"];
                            dest += TextBox1.Text + "." + Session["ext"];
                            File.Copy(Session["image"].ToString(), destPath);
                            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Pelajar(no_induk,nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Id_Fakultas,Id_Prodi,semester,IPK,foto_dir,email) values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox6.Text + "','" + TextBox12.Text + "','" + TextBox10.Text + "','" + TextBox5.Text + "','" + TTL + "','" + TextBox9.Text + "','" + fakcode + "','" + prodicode + "','" + TextBox7.Text + "','" + TextBox8.Text + "','" + dest + "','" + TextBox11.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                cn.Open();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = cn;
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = "insert into DataAbsensiPelajar(no_induk,kodefingerprint,kodebarcode) values('" + TextBox1.Text + "',NULL,NULL)";
                                cmd.ExecuteReader();
                                cn.Close();
                                Response.Redirect("AddMhs.aspx");
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    String str = "<script> alert('Ada data yang kurang atau tidak sesuai'); </Script>";
                    Response.Write(str);
                }
            }
            else
            {
                String str = "<script> alert('Cek Email anda, data tidak valid'); </Script>";
                Response.Write(str);
            }
        }
    }
    ICollection CreateDataSource()
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString());
        SqlDataAdapter da = new SqlDataAdapter("select d.no_induk 'Nomor Induk',nama 'Nama Mahasiswa',case when d.kodefingerprint is null then 'Tidak ada' else 'Ada' end 'Data Fingerprint',case when d.kodebarcode is null then 'Tidak ada' else 'Ada' end 'Data Barcode' from DataAbsensiPelajar d join Pelajar p on d.no_induk=p.no_induk", con);
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
