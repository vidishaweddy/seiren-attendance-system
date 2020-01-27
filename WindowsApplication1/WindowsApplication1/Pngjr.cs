using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using System.Collections;

namespace WindowsApplication1
{
    public partial class Pngjr : Form
    {
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        string pathPict = "";
        string pathPict2 = "";
        public Pngjr()
        {
            InitializeComponent();
        }
        private void Pngjr_Load(object sender, EventArgs e)
        {

            GetData("select kode_pengajar 'Nomor Induk',nama 'Nama Pengajar',no_telp 'No Telepon',alamat 'Alamat' from Pengajar");
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource1;
            dataGridView3.DataSource = bindingSource1;
            setEnable(false);
            setEnable2(false);
        }
        
        private void GetData(string selectCommand)
        {
            try
            {
                // Specify a connection string. Replace the given value with a 
                // valid connection string for a Northwind SQL Server sample
                // database accessible to your system.
                String connectionString =
                    conn;

                // Create a new data adapter based on the specified query.
                dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

                // Create a command builder to generate SQL update, insert, and
                // delete commands based on selectCommand. These are used to
                // update the database.
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);

                // Populate a new data table and bind it to the BindingSource.
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
                bindingSource1.DataSource = table;

                // Resize the DataGridView columns to fit the newly loaded content.
                dataGridView1.AutoResizeColumns(
                    DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            }
            catch (SqlException)
            {
                MessageBox.Show("To run this example, replace the value of the " +
                    "connectionString variable with a connection string that is " +
                    "valid for your system.");
            }
        }

        private void buttonshow_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = dlg.FileName;
                pathPict = dlg.FileName.ToString();
            }
        }
        private void buttonshow2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            DialogResult dlgRes = dlg.ShowDialog();
            if (dlgRes != DialogResult.Cancel)
            {
                //Set image in picture box
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = dlg.FileName;
                pathPict2 = dlg.FileName.ToString();
            }
        }
        void setEnable(bool flag)
        {
            textBoxa2.Enabled = flag;
            textBoxa3.Enabled = flag;
            textboxa4.Enabled = flag;
            textBoxa5.Enabled = flag;
            textBoxa6.Enabled = flag;
            textBoxa7.Enabled = flag;
            textBoxa8.Enabled = flag;
            buttonshow2.Enabled = flag;
        }
        void setEnable2(bool flag)
        {
            textBoxb2.Enabled = flag;
            textBoxb3.Enabled = flag;
            textboxb4.Enabled = flag;
            textBoxb5.Enabled = flag;
            textBoxb6.Enabled = flag;
            textBoxb7.Enabled = flag;
            textBoxb8.Enabled = flag;
        }
        byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textbox4.Value.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals("") || textBox8.Text.Equals("") )
            {
                MessageBox.Show("Ada data yang kurang, silakan diperiksa");
            }
            else
            {
                if (textBox8.Text.Contains("@") && textBox8.Text.Contains("."))
                {
                    try
                    {
                        string TTL = textBox3.Text + ", " + textbox4.Value.Date.ToString();
                        if (!pathPict.Equals(""))
                        {
                            byte[] imageData = ReadFile(pathPict);
                            using (SqlConnection cn = new SqlConnection(conn))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Pengajar(kode_pengajar,nama,no_telp,alamat,agama,TTL,email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox5.Text + "','" + TTL + "','" + textBox8.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                string qry = "update Pengajar set image=@ImageData where kode_pengajar='" + textBox1.Text + "'";
                                SqlCommand SqlCom = new SqlCommand(qry, cn);
                                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imageData));
                                cn.Open();
                                SqlCom.ExecuteNonQuery();
                                cn.Close();
                                Pngjr f1 = new Pngjr();
                                f1.Show();
                                Hide();
                            }
                        }
                        else
                        {
                            using (SqlConnection cn = new SqlConnection(conn))
                            {
                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "INSERT into Pengajar(kode_pengajar,nama,no_telp,alamat,agama,TTL,email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox5.Text + "','" + TTL + "','" + textBox8.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                if (MessageBox.Show("Pengajar ini tak mengajar satupun kelas, Apakah anda ingin menambah kelas untuk pengajar ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    GetMPforPngjr f1 = new GetMPforPngjr(textBox1.Text);
                                    f1.Show();
                                }
                                else
                                {
                                }
                            }
                        }
                        MessageBox.Show("Tambah Data Sukses");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ada data yang kurang atau tidak sesuai");
                    }
                }
                else
                {
                    MessageBox.Show("Cek Email anda, data tidak valid");
                }
            }
        }
        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (textBoxa1.Text.Equals("") || textBoxa2.Text.Equals("") || textBoxa3.Text.Equals("") || textboxa4.Value.Equals("") || textBoxa5.Text.Equals("") || textBoxa6.Text.Equals("") || textBoxa7.Text.Equals("") || textBoxa8.Text.Equals(""))
            {
                MessageBox.Show("Ada data yang kurang, silakan diperiksa");
            }
            else
            {
                if (textBoxa8.Text.Contains("@") && textBoxa8.Text.Contains("."))
                {
                    try
                    {
                        string TTL = textBoxa3.Text + ", " + textboxa4.Value.Date.ToString();
                        if (!pathPict2.Equals(""))
                        {
                            byte[] imageData = ReadFile(pathPict2);
                            using (SqlConnection cn = new SqlConnection(conn))
                            {

                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "update Pengajar set nama='" + textBoxa2.Text + "',no_telp='" + textBoxa6.Text + "',alamat='" + textBoxa7.Text + "',agama='" + textBoxa5.Text + "',TTL='" + TTL + "',email='" + textBoxa8.Text + "' where kode_pengajar='" + textBoxa1.Text + "'";
                                command.ExecuteReader();
                                cn.Close();
                                string qry = "update Pengajar set image=@ImageData where kode_pengajar='" + textBoxa1.Text + "'";
                                SqlCommand SqlCom = new SqlCommand(qry, cn);
                                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imageData));
                                cn.Open();
                                SqlCom.ExecuteNonQuery();
                                cn.Close();
                                Pngjr f1 = new Pngjr();
                                f1.Show();
                                Hide();
                            }
                        }
                        else
                        {
                            using (SqlConnection cn = new SqlConnection(conn))
                            {
                                cn.Open();
                                SqlCommand command = new SqlCommand();
                                command.Connection = cn;
                                command.CommandType = CommandType.Text;
                                command.CommandText = "update Pengajar set nama='" + textBoxa2.Text + "',no_telp='" + textBoxa6.Text + "',alamat='" + textBoxa7.Text + "',agama='" + textBoxa5.Text + "',TTL='" + TTL + "',email='" + textBoxa8.Text + "' where kode_pengajar='" + textBoxa1.Text + "'";
                                command.ExecuteReader();
                                cn.Close();
                                if (MessageBox.Show("Apakah anda ingin menambah kelas untuk Pengajar ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    GetMPforPngjr f1 = new GetMPforPngjr(textBoxa1.Text);
                                    f1.Show();
                                }
                                else { }
                            }
                        }
                        MessageBox.Show("Tambah Data Sukses");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ada data yang kurang atau tidak sesuai");
                    }
                }
                else
                {
                    MessageBox.Show("Cek Email anda, data tidak valid");
                }
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^([\d\b]|\s)*$"))
                e.Handled = true;
        }
        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^([\w\b\-\._@]|\s)*$"))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pngjr f1 = new Pngjr();
            f1.Show();
            Hide();
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda akan menghapus data ini?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {

                    using (SqlConnection cn = new SqlConnection(conn))
                    {
                        cn.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = cn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "delete from Pengajar where kode_pengajar='" + textBoxb1.Text + "'";
                        command.ExecuteReader();
                        cn.Close();
                        Pngjr f1 = new Pngjr();
                        f1.Show();
                        Hide();
                    }
                    MessageBox.Show("Hapus Data Sukses");

                }
                catch (Exception)
                {
                    MessageBox.Show("Data tidak dapat dihapus");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource2 = new BindingSource();
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama,no_telp,alamat,agama,TTL,email from Pengajar where kode_pengajar='" + textBoxa1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();

                    textBoxa3.Text = rdr[4].ToString().Substring(0, rdr[4].ToString().IndexOf(","));
                    textboxa4.Value = DateTime.Parse(rdr[4].ToString().Substring(rdr[4].ToString().IndexOf(",") + 2));

                    textBoxa2.Text = rdr[0].ToString();
                    textBoxa6.Text = rdr[1].ToString();
                    textBoxa7.Text = rdr[2].ToString();
                    textBoxa5.Text = rdr[3].ToString();
                    textBoxa8.Text = rdr[5].ToString();
                    cn.Close();
                    try
                    {
                        dataAdapter = new SqlDataAdapter("select image from Pengajar where kode_pengajar='" + textBoxa1.Text + "'", conn);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "imagepngjr");
                        DataRow myRow;
                        byte[] MyData = new byte[0];
                        myRow = ds.Tables["imagepngjr"].Rows[0];

                        MyData = (byte[])myRow["image"];
                        MemoryStream stream = new MemoryStream(MyData, 0, MyData.Length);
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox2.Image = Image.FromStream(stream, true, true);
                    }
                    catch (Exception)
                    {
                    }
                    setEnable(true);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Data dengan nomor induk ini tidak ada");
                setEnable(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource2 = new BindingSource();
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama,no_telp,alamat,agama,TTL,email from Pengajar where kode_pengajar='" + textBoxb1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();

                    textBoxb3.Text = rdr[4].ToString().Substring(0, rdr[4].ToString().IndexOf(","));
                    textboxb4.Value = DateTime.Parse(rdr[4].ToString().Substring(rdr[4].ToString().IndexOf(",") + 2));

                    textBoxb2.Text = rdr[0].ToString();
                    textBoxb6.Text = rdr[1].ToString();
                    textBoxb7.Text = rdr[2].ToString();
                    textBoxb5.Text = rdr[3].ToString();
                    textBoxb8.Text = rdr[5].ToString();
                    cn.Close();
                    try
                    {
                        dataAdapter = new SqlDataAdapter("select image from Pengajar where kode_pengajar='" + textBoxb1.Text + "'", conn);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "imagepngjr");
                        DataRow myRow;
                        byte[] MyData = new byte[0];
                        myRow = ds.Tables["imagepngjr"].Rows[0];

                        MyData = (byte[])myRow["image"];
                        MemoryStream stream = new MemoryStream(MyData, 0, MyData.Length);
                        pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox3.Image = Image.FromStream(stream, true, true);
                    }
                    catch (Exception)
                    {
                    }
                    setEnable2(true);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Data dengan nomor induk ini tidak ada");
                setEnable2(false);
            }
        }
    }
}