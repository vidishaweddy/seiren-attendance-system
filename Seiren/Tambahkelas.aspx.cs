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

public partial class Tambahkelas : System.Web.UI.Page
{
    int sesi;
    int count = 0;
    int getcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBoxjumlah.Attributes.Add("onkeypress", "javaScript:return numonly(event);");

        Session["MK"] = "MP113";
        getsesi();
        setData();
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (cekdata() == false)
        {
            String str = "<script> alert('Anda harus mengisi semua data yang ada'); </Script>";
            Response.Write(str);
        }
        else
        {
            int counter = 1;
            int counting = 0;
            int i = 0;
            int tambah = 30;
            string a, b, c, d;
            a = "TextBox";
            b = "DropDownList";
            d = "TextBox";
            c = "DropDownList";
            TextBox aa = new TextBox();
            DropDownList bb = new DropDownList();
            DropDownList cc = new DropDownList();
            TextBox dd = new TextBox();
            i = int.Parse(TextBoxjumlah.Text);
            while (counting < i)
            {
                counting++;
                tambah = 30 + counting;
                aa = (TextBox)this.FindControl(a + counting.ToString());
                bb = (DropDownList)this.FindControl(b + counting.ToString());
                cc = (DropDownList)this.FindControl(c + tambah.ToString());
                dd = (TextBox)this.FindControl(d + tambah.ToString());
                if (counting > getcount)
                {
                    try
                    {
                        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
                        {

                            cn.Open();
                            SqlCommand command = new SqlCommand();
                            command.Connection = cn;
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT into DataPerkuliahan(kode_MP,kelas,hari,sesi,ruang) values('" + Session["MK"].ToString() + "','" + aa.Text + "','" + bb.SelectedValue.ToString() + "','" + cc.SelectedValue.ToString() + "','" + dd.Text + "')";
                            command.ExecuteReader();
                            cn.Close();
                        }
                    }
                    catch (Exception)
                    {
                        String str = "<script> alert('Maaf, silahkan cek data, apakah kelas yang ada sama? Bila tidak, ada kesalahan pada database'); </Script>";
                        Response.Write(str);
                    }
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
                            command.CommandText = "update DataPerkuliahan set hari='" + bb.SelectedValue.ToString() + "',sesi='" + cc.SelectedValue.ToString() + "',ruang='" + dd.Text + "' where kode_MP='" + Session["MK"].ToString() + "' and kelas='" + aa.Text + "'";
                            command.ExecuteReader();
                            cn.Close();
                        }
                    }
                    catch (Exception)
                    {
                        String str = "<script> alert('Maaf, silahkan cek data, apakah data yang kurang lengkap? Bila tidak, ada kesalahan pada database'); </Script>";
                        Response.Write(str);
                    }
                }
            }
            Response.Redirect("MenuDataMahasiswa");
        }
    }
    bool cekdata()
    {
        int counting = 0;
        int i = 0;
        int tambah;
        string a, d;
        a = "TextBox";
        d = "TextBox";
        TextBox aa = new TextBox();
        TextBox dd = new TextBox();
        i = int.Parse(TextBoxjumlah.Text);
        while (counting < i)
        {
            counting++;
            tambah = 30 + counting;
            aa = (TextBox)this.FindControl(a + counting.ToString());
            dd = (TextBox)this.FindControl(d + tambah.ToString());
            if (aa.Text.Equals("") || dd.Text.Equals(""))
            {
                return false;
            }
        }
        return true;
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        TextBox2.Text = "google";
        string a = "TextBoxjumlah";
        TextBox are = new TextBox();
        are = (TextBox)this.FindControl(a);
        are.Text = "1354";
    }
    void setData()
    {
        int counter=1;
        int tambah=30;
        string a, b, c, d;
        a = "TextBox";
        b = "DropDownList";
        d = "TextBox";
        c = "DropDownList";
        TextBox aa = new TextBox();
        DropDownList bb = new DropDownList();
        DropDownList cc = new DropDownList();
        TextBox dd = new TextBox();
        using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
        {
            SqlCommand cmd = new SqlCommand("SELECT kelas,hari,sesi,ruang from DataPerkuliahan where kode_MP='"+Session["MK"].ToString()+"'", cn);
            cn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                count++;
                tambah = 30 + count;
                aa= (TextBox)this.FindControl(a+count.ToString());
                aa.Text = rdr[0].ToString();
                bb = (DropDownList)this.FindControl(b + count.ToString());
                bb.SelectedValue = rdr[1].ToString();
                cc = (DropDownList)this.FindControl(c + tambah.ToString());
                while (counter <= sesi)
                {
                    cc.Items.Add(counter.ToString());
                    counter++;
                }
                counter = 1;
                cc.SelectedValue = rdr[2].ToString();
                dd = (TextBox)this.FindControl(d + tambah.ToString());
                dd.Text = rdr[3].ToString();
                
                aa.Visible = true;
                bb.Visible = true;
                cc.Visible = true;
                dd.Visible = true;
                aa.Enabled = false;
            }
            getcount = count;
            cn.Close();
            
        }
    }
    void getsesi()
    {
        try
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDbConn"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT jumlah_sesi from Parameter", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                sesi = int.Parse(rdr[0].ToString());
                cn.Close();
            }
        }
        catch (Exception)
        {
            String str = "<script> alert('Anda belum mengeset parameter jumlah sesi pada satu hari'); </Script>";
            Response.Write(str);
        }
    }
    void setnew()
    {
        int counting=0;
        int i = 0;
        int tambah;
        string a, b, c, d;
        a = "TextBox";
        b = "DropDownList";
        d = "TextBox";
        c = "DropDownList";
        TextBox aa = new TextBox();
        DropDownList bb = new DropDownList();
        DropDownList cc = new DropDownList();
        TextBox dd = new TextBox();
                while (counting < 30)
                {
                    counting++;
                    tambah = 30 + counting;
                    aa = (TextBox)this.FindControl(a + counting.ToString());
                    bb = (DropDownList)this.FindControl(b + counting.ToString());
                    cc = (DropDownList)this.FindControl(c + tambah.ToString());
                    if(counting>getcount)
                        cc.Items.Clear();
                    dd = (TextBox)this.FindControl(d + tambah.ToString());
                    aa.Visible = false;
                    bb.Visible = false;
                    cc.Visible = false;
                    dd.Visible = false;
                }
                Button2.Visible = true;
                Button3.Visible = true;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int counter=1;
        int counting = 0;
        int i = 0;
        int tambah = 30;
        string a, b, c, d;
        a = "TextBox";
        b = "DropDownList";
        d = "TextBox";
        c = "DropDownList";
        TextBox aa = new TextBox();
        DropDownList bb = new DropDownList();
        DropDownList cc = new DropDownList();
        TextBox dd = new TextBox();
        setnew();
        if (TextBoxjumlah.Text.Equals(""))
        {
            String str = "<script> alert('Isi jumlah kelas yang akan dimasukkan'); </Script>";
            Response.Write(str);
        }
        else
        {
            i = int.Parse(TextBoxjumlah.Text);
            if ((i) > 30)
            {
                setData();
                String str = "<script> alert('Maaf jumlah kelas maksimal hanya 30'); </Script>";
                Response.Write(str);
            }
            else if (i < getcount)
            {
                setData();
                String str = "<script> alert('Maaf jumlah kelas yang anda masukkan kurang dari kelas yang sudah didaftarkan'); </Script>";
                Response.Write(str);
            }
            else
            {
                while (counting < i)
                {
                    counting++;
                    tambah = 30 + counting;
                    aa = (TextBox)this.FindControl(a + counting.ToString());
                    bb = (DropDownList)this.FindControl(b + counting.ToString());
                    cc = (DropDownList)this.FindControl(c + tambah.ToString());
                    if (counting > getcount)
                    {
                        while (counter <= sesi)
                        {
                            cc.Items.Add(counter.ToString());
                            counter++;
                        }
                    }
                    counter = 1;
                    dd = (TextBox)this.FindControl(d + tambah.ToString());
                    aa.Visible = true;
                    bb.Visible = true;
                    cc.Visible = true;
                    dd.Visible = true;
                }
                Button2.Visible = true;
                Button3.Visible = true;
            }
        }
    }
}
