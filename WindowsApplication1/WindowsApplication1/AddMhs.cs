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
    
    public partial class AddMhs : Form, DPFP.Capture.EventHandler
    {
        public delegate void OnTemplateEventHandler(DPFP.Template template);
        public event OnTemplateEventHandler OnTemplate;
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        int fakcode, prodicode,set;
        string pathPict="";
        string pathPict2 = "";
        bool fp = false;
        Byte[] bit = new Byte[0];
        public AddMhs()
        {
            InitializeComponent();
        }

        private void AddMhs_Load(object sender, EventArgs e)
        {
            Init();
            Start();
            GetData("select d.no_induk 'Nomor Induk',nama 'Nama Mahasiswa',case when d.kodefingerprint is null then 'Tidak ada' else 'Ada' end 'Data Fingerprint',case when d.kodebarcode is null then 'Tidak ada' else 'Ada' end 'Data Barcode' from DataAbsensiPelajar d join Pelajar p on d.no_induk=p.no_induk");
            dataGridView1.DataSource = bindingSource1;
            dataGridView2.DataSource = bindingSource1;
            dataGridView3.DataSource = bindingSource1;
            fnGetConnectedToDatabase();
            fnGetConnectedToDatabase2();
            fnGetConnectedToDatabase3();
            set = 1;
            setEnable(false);
            setEnable2(false);
            databind2();
            databind3();
            databind();
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
        private void fnGetConnectedToDatabase()
        {
            //Connection string 
            SqlConnection myConn = new SqlConnection(conn);
            string sqlStr = "SELECT Nama_Fakultas from Fakultas;";
            SqlDataAdapter dAdapter = new SqlDataAdapter(sqlStr,conn);
            //Instantiate a DataSet 

            DataSet dset = new DataSet();

            dAdapter.TableMappings.Add("Table", "FacultyTable");
            dAdapter.Fill(dset);
            this.comboBox1.DataSource = dset.DefaultViewManager;
            comboBox1.DisplayMember = "FacultyTable.Nama_Fakultas";
        }
        private void fnGetConnectedToDatabase3()
        {
            //Connection string 
            SqlConnection myConn = new SqlConnection(conn);
            string sqlStr = "SELECT Nama_Fakultas from Fakultas;";
            SqlDataAdapter dAdapter = new SqlDataAdapter(sqlStr, conn);
            //Instantiate a DataSet 

            DataSet dset = new DataSet();

            dAdapter.TableMappings.Add("Table", "FacultyTable");
            dAdapter.Fill(dset);
            this.comboBoxb1.DataSource = dset.DefaultViewManager;
            comboBoxb1.DisplayMember = "FacultyTable.Nama_Fakultas";
        }
        private void fnGetConnectedToDatabase2()
        {
            //Connection string 
            SqlConnection myConn = new SqlConnection(conn);
            string sqlStr = "SELECT Nama_Fakultas from Fakultas;";
            SqlDataAdapter dAdapter = new SqlDataAdapter(sqlStr, conn);
            //Instantiate a DataSet 

            DataSet dset = new DataSet();

            dAdapter.TableMappings.Add("Table", "FacultyTable");
            dAdapter.Fill(dset);
            this.comboBoxa1.DataSource = dset.DefaultViewManager;
            comboBoxa1.DisplayMember = "FacultyTable.Nama_Fakultas";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind();
        }
        private void comboBoxa1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind2();
        }
        private void comboBoxb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind3();
        }
        private void databind()
        {
            //Connection string 
            SqlConnection myConn = new SqlConnection(conn);
            string sqlStr = "SELECT Nama_Prodi from Prodi p join Fakultas f on p.Id_Fakultas=f.Id_Fakultas where f.Nama_Fakultas='" + comboBox1.Text+ "';";
            SqlDataAdapter dAdapter = new SqlDataAdapter(sqlStr, myConn);
            //Instantiate a DataSet 

            DataSet dset = new DataSet();

            dAdapter.TableMappings.Add("Table", "FacultyTable");
            dAdapter.Fill(dset);
            comboBox2.DataSource = dset.DefaultViewManager;
            comboBox2.DisplayMember = "FacultyTable.Nama_Prodi";
            if (set == 1)
            {
                comboBoxa2.DataSource = dset.DefaultViewManager;
                comboBoxa2.DisplayMember = "FacultyTable.Nama_Prodi";
                comboBoxb2.DataSource = dset.DefaultViewManager;
                comboBoxb2.DisplayMember = "FacultyTable.Nama_Prodi";
            }
        }
        private void databind2()
        {
            //Connection string 
            SqlConnection myConn2 = new SqlConnection(conn);
            string sqlStr2 = "SELECT Nama_Prodi from Prodi p join Fakultas f on p.Id_Fakultas=f.Id_Fakultas where f.Nama_Fakultas='" + comboBoxa1.Text + "';";
            SqlDataAdapter dAdapter2 = new SqlDataAdapter(sqlStr2, myConn2);
            //Instantiate a DataSet 

            DataSet dset2 = new DataSet();

            dAdapter2.TableMappings.Add("Table", "FacultyTable2");
            dAdapter2.Fill(dset2);
            comboBoxa2.DataSource = dset2.DefaultViewManager;
            comboBoxa2.DisplayMember = "FacultyTable2.Nama_Prodi";
        }
        private void databind3()
        {
            //Connection string 
            SqlConnection myConn = new SqlConnection(conn);
            string sqlStr = "SELECT Nama_Prodi from Prodi p join Fakultas f on p.Id_Fakultas=f.Id_Fakultas where f.Nama_Fakultas='" + comboBoxb1.Text + "';";
            SqlDataAdapter dAdapter = new SqlDataAdapter(sqlStr, conn);
            //Instantiate a DataSet 

            DataSet dset = new DataSet();

            dAdapter.TableMappings.Add("Table", "FacultyTable");
            dAdapter.Fill(dset);
            this.comboBoxb2.DataSource = dset.DefaultViewManager;
            comboBoxb2.DisplayMember = "FacultyTable.Nama_Prodi";
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^([\d\b]|\s)*$"))
          e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^([\d\b\.]|\s)*$"))
                e.Handled = true;
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^([\w\b\-\._@]|\s)*$"))
                e.Handled = true;        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMhs f1 = new AddMhs();
            f1.Show();
            Hide();
        }
        void getId()
        {
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id_Fakultas from Fakultas where Nama_Fakultas='" + comboBox1.Text + "'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                fakcode = int.Parse(rdr[0].ToString());
                cn.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT Id_Prodi from Prodi where Nama_Prodi='" + comboBox2.Text + "'", cn);
                cn.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                rdr2.Read();
                prodicode = int.Parse(rdr2[0].ToString());
                cn.Close();

            }
        }
        void getId2()
        {
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT Id_Fakultas from Fakultas where Nama_Fakultas='" + comboBoxa1.Text + "'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                fakcode = int.Parse(rdr[0].ToString());
                cn.Close();
                SqlCommand cmd2 = new SqlCommand("SELECT Id_Prodi from Prodi where Nama_Prodi='" + comboBoxa2.Text + "'", cn);
                cn.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                rdr2.Read();
                prodicode = int.Parse(rdr2[0].ToString());
                cn.Close();

            }
        }
        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (textBoxa1.Text.Equals("") || textBoxa2.Text.Equals("") || textBoxa3.Text.Equals("") || textboxa4.Value.Equals("") || textBoxa5.Text.Equals("") || textBoxa6.Text.Equals("") || textBoxa7.Text.Equals("") || textBoxa8.Text.Equals("") || textBoxa9.Text.Equals("") || textBoxa10.Text.Equals("") || textBoxa11.Text.Equals("") || textBoxa12.Text.Equals(""))
            {
                MessageBox.Show("Ada data yang kurang, silakan diperiksa");
            }
            else
            {
                if (textBoxa11.Text.Contains("@") && textBoxa11.Text.Contains("."))
                {
                    try
                    {
                        getId2();
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
                                command.CommandText = "update Pelajar set nama='" + textBoxa2.Text + "',no_telp='" + textBoxa6.Text + "',alamat='" + textBoxa12.Text + "',alamat_ortu='" + textBoxa10.Text + "',agama='" + textBoxa5.Text + "',TTL='" + TTL + "',nama_ortu='" + textBoxa9.Text + "',Id_Fakultas='" + fakcode + "',Id_Prodi='" + prodicode + "',semester='" + textBoxa7.Text + "',IPK='" + textBoxa8.Text + "',email='" + textBoxa11.Text + "' where no_induk='" + textBoxa1.Text + "'";
                                command.ExecuteReader();
                                cn.Close();
                                string qry = "update Pelajar set image=@ImageData where no_induk='" + textBoxa1.Text + "'";
                                SqlCommand SqlCom = new SqlCommand(qry, cn);
                                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imageData));
                                cn.Open();
                                SqlCom.ExecuteNonQuery();
                                cn.Close();
                                if (fp == true)
                                {
                                    string qry2 = "update DataAbsensiPelajar set kodefingerprint=@FPdata, kodebarcode='"+textBox14.Text+"' where no_induk='" + textBoxa1.Text + "'";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    SqlCom2.Parameters.Add(new SqlParameter("@FPdata", bit));
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                else
                                {
                                    string qry2 = "update DataAbsensiPelajar set kodebarcode='" + textBox14.Text + "' where no_induk='" + textBoxa1.Text + "'";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (MessageBox.Show("Apakah anda ingin menambah kelas untuk pelajar ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    getMPforPljr f1 = new getMPforPljr(textBoxa1.Text);
                                    f1.Show();
                                }
                                else
                                {
                                }
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
                                command.CommandText = "update Pelajar set nama='" + textBoxa2.Text + "',no_telp='" + textBoxa6.Text + "',alamat='" + textBoxa12.Text + "',alamat_ortu='" + textBoxa10.Text + "',agama='" + textBoxa5.Text + "',TTL='" + TTL + "',nama_ortu='" + textBoxa9.Text + "',Id_Fakultas='" + fakcode + "',Id_Prodi='" + prodicode + "',semester='" + textBoxa7.Text + "',IPK='" + textBoxa8.Text + "',email='" + textBoxa11.Text + "' where no_induk='" + textBoxa1.Text + "'";
                                command.ExecuteReader();
                                cn.Close();
                                if (fp == true)
                                {
                                    string qry2 = "update DataAbsensiPelajar set kodefingerprint=@FPdata, kodebarcode='" + textBox14.Text + "' where no_induk='" + textBoxa1.Text + "'";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    SqlCom2.Parameters.Add(new SqlParameter("@FPdata", bit));
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                else
                                {
                                    string qry2 = "update DataAbsensiPelajar set kodebarcode='" + textBox14.Text + "' where no_induk='" + textBoxa1.Text + "'";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (MessageBox.Show("Apakah anda ingin menambah kelas untuk pelajar ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    getMPforPljr f1 = new getMPforPljr(textBoxa1.Text);
                                    f1.Show();
                                }
                                else
                                {
                                }
                            }
                        }
                        MessageBox.Show("Ubah Data Sukses");
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

        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textbox4.Value.Equals("") || textBox5.Text.Equals("") || textBox6.Text.Equals("") || textBox7.Text.Equals("") || textBox8.Text.Equals("") || textBox9.Text.Equals("") || textBox10.Text.Equals("") || textBox11.Text.Equals("") || textBox12.Text.Equals(""))
            {
                MessageBox.Show("Ada data yang kurang, silakan diperiksa"); 
            }
            else
            {
                if (textBox11.Text.Contains("@") && textBox11.Text.Contains("."))
                {
                    try
                    {
                        getId();
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
                                command.CommandText = "INSERT into Pelajar(no_induk,nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Id_Fakultas,Id_Prodi,semester,IPK,email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox12.Text + "','" + textBox10.Text + "','" + textBox5.Text + "','" + TTL + "','" + textBox9.Text + "','" + fakcode + "','" + prodicode + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox11.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                string qry = "update Pelajar set image=@ImageData where no_induk='" + textBox1.Text + "'";
                                SqlCommand SqlCom = new SqlCommand(qry, cn);
                                SqlCom.Parameters.Add(new SqlParameter("@ImageData", (object)imageData));
                                cn.Open();
                                SqlCom.ExecuteNonQuery();
                                cn.Close();
                                if (fp==true)
                                {
                                    string qry2 = "insert into DataAbsensiPelajar (no_induk,kodebarcode) values('" + textBox1.Text + "','" + textBox13.Text + "')";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                    qry2 = "update DataAbsensiPelajar set kodefingerprint=@FPdata where no_induk='"+textBox1.Text+"'";
                                    SqlCom2 = new SqlCommand(qry2, cn);
                                    
                                    SqlCom2.Parameters.Add(new SqlParameter("@FPdata", bit));
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                else
                                {
                                    string qry2 = "insert into DataAbsensiPelajar (no_induk,kodefingerprint,kodebarcode) values('" + textBox1.Text + "',NULL,'" + textBox13.Text + "')";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (MessageBox.Show("Pelajar ini tak mengajar satupun kelas, Apakah anda ingin menambah kelas untuk pelajar ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    getMPforPljr f1 = new getMPforPljr(textBox1.Text);
                                    f1.Show();
                                }
                                else
                                {
                                }
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
                                command.CommandText = "INSERT into Pelajar(no_induk,nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Id_Fakultas,Id_Prodi,semester,IPK,image,email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + textBox12.Text + "','" + textBox10.Text + "','" + textBox5.Text + "','" + TTL + "','" + textBox9.Text + "','" + fakcode + "','" + prodicode + "','" + textBox7.Text + "','" + textBox8.Text + "',NULL,'" + textBox11.Text + "')";
                                command.ExecuteReader();
                                cn.Close();
                                if (fp == true)
                                {
                                    string qry2 = "insert into DataAbsensiPelajar (no_induk,kodebarcode) values('" + textBox1.Text + "','" + textBox13.Text + "')";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                    qry2 = "update DataAbsensiPelajar set kodefingerprint=@FPdata where no_induk='" + textBox1.Text + "'";
                                    SqlCom2 = new SqlCommand(qry2, cn);
                                    SqlCom2.Parameters.Add(new SqlParameter("@FPdata", bit));
                                    cn.Open();
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                    
                                }
                                else
                                {
                                    string qry2 = "insert into DataAbsensiPelajar (no_induk,kodefingerprint,kodebarcode) values('" + textBox1.Text + "',NULL,'" + textBox13.Text + "')";
                                    SqlCommand SqlCom2 = new SqlCommand(qry2, cn);
                                    SqlCom2.ExecuteNonQuery();
                                    cn.Close();
                                }
                                if (MessageBox.Show("Pelajar ini tak mengajar satupun kelas, Apakah anda ingin menambah kelas untuk pelajar ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    getMPforPljr f1 = new getMPforPljr(textBox1.Text);
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

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda akan menghapus data ini?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {

                    using (SqlConnection cn = new SqlConnection(conn))
                    {


                        cn.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "delete from DataAbsensiPelajar where no_induk='" + textBoxb1.Text + "'";
                        cmd.ExecuteReader();
                        cn.Close();
                        cn.Open();
                        SqlCommand command = new SqlCommand();
                        command.Connection = cn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "delete from Pelajar where no_induk='" + textBoxb1.Text + "'";
                        command.ExecuteReader();
                        cn.Close();
                        AddMhs f1 = new AddMhs();
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

        private void button1_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource2 = new BindingSource();
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Nama_Fakultas,Nama_Prodi,semester,IPK,email from Pelajar p join Fakultas f on p.Id_Fakultas=f.Id_Fakultas join Prodi i on p.Id_Prodi=i.Id_Prodi  where no_induk='" + textBoxa1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();

                    textBoxa3.Text = rdr[5].ToString().Substring(0, rdr[5].ToString().IndexOf(","));
                    textboxa4.Value = DateTime.Parse(rdr[5].ToString().Substring(rdr[5].ToString().IndexOf(",") + 2));

                    textBoxa2.Text = rdr[0].ToString();
                    textBoxa6.Text = rdr[1].ToString();
                    textBoxa12.Text = rdr[2].ToString();
                    textBoxa10.Text = rdr[3].ToString();
                    textBoxa5.Text = rdr[4].ToString();
                    textBoxa9.Text = rdr[6].ToString();
                    comboBoxa1.Text = rdr[7].ToString();
                    databind2();
                    comboBoxa2.SelectedItem = (object)rdr[8].ToString();
                    textBoxa7.Text = rdr[9].ToString();
                    textBoxa8.Text = rdr[10].ToString();
                    textBoxa11.Text = rdr[11].ToString();
                    cn.Close();
                    SqlCommand cmd2 = new SqlCommand("SELECT d.kodebarcode, case when d.kodefingerprint is null then 'Tidak ada' else 'Ada Data' end 'Data Fingerprint' from DataAbsensiPelajar d where d.no_induk='" + textBoxa1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr2 = cmd2.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr2.Read();
                    textBox14.Text = rdr2[0].ToString();
                    label45.Visible = true;
                    label45.Text = rdr2[1].ToString();
                    cn.Close();
                    try
                    {
                        dataAdapter = new SqlDataAdapter("select image from Pelajar where no_induk='" + textBoxa1.Text + "'", conn);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "imagepljr");
                        DataRow myRow;
                        byte[] MyData = new byte[0];
                        myRow = ds.Tables["imagepljr"].Rows[0];

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
        void setEnable(bool flag)
        {
            textBoxa2.Enabled = flag;
            textBoxa3.Enabled = flag;
            textboxa4.Enabled = flag;
            textBoxa5.Enabled = flag;
            textBoxa6.Enabled = flag;
            textBoxa7.Enabled = flag;
            textBoxa8.Enabled = flag;
            textBoxa9.Enabled = flag;
            textBoxa10.Enabled = flag;
            textBoxa11.Enabled = flag;
            textBoxa12.Enabled = flag;
            comboBoxa1.Enabled = flag;
            comboBoxa2.Enabled = flag;
            buttonshow2.Enabled = flag;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindingSource bindingSource2 = new BindingSource();
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama,no_telp,alamat,alamat_ortu,agama,TTL,nama_ortu,Nama_Fakultas,Nama_Prodi,semester,IPK,email from Pelajar p join Fakultas f on p.Id_Fakultas=f.Id_Fakultas join Prodi i on p.Id_Prodi=i.Id_Prodi  where no_induk='" + textBoxb1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();

                    textBoxb3.Text = rdr[5].ToString().Substring(0, rdr[5].ToString().IndexOf(","));
                    textboxb4.Value = DateTime.Parse(rdr[5].ToString().Substring(rdr[5].ToString().IndexOf(",") + 2));

                    textBoxb2.Text = rdr[0].ToString();
                    textBoxb6.Text = rdr[1].ToString();
                    textBoxb12.Text = rdr[2].ToString();
                    textBoxb10.Text = rdr[3].ToString();
                    textBoxb5.Text = rdr[4].ToString();
                    textBoxb9.Text = rdr[6].ToString();
                    comboBoxb1.Text = rdr[7].ToString();
                    databind2();
                    comboBoxb2.SelectedItem = (object)rdr[8].ToString();
                    textBoxb7.Text = rdr[9].ToString();
                    textBoxb8.Text = rdr[10].ToString();
                    textBoxb11.Text = rdr[11].ToString();
                    cn.Close();
                    try
                    {
                        dataAdapter = new SqlDataAdapter("select image from Pelajar where no_induk='" + textBoxb1.Text + "'", conn);
                        DataSet ds = new DataSet();
                        dataAdapter.Fill(ds, "imagepljr");
                        DataRow myRow;
                        byte[] MyData = new byte[0];
                        myRow = ds.Tables["imagepljr"].Rows[0];

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
        void setEnable2(bool flag)
        {
            textBoxb2.Enabled = flag;
            textBoxb3.Enabled = flag;
            textboxb4.Enabled = flag;
            textBoxb5.Enabled = flag;
            textBoxb6.Enabled = flag;
            textBoxb7.Enabled = flag;
            textBoxb8.Enabled = flag;
            textBoxb9.Enabled = flag;
            textBoxb10.Enabled = flag;
            textBoxb11.Enabled = flag;
            textBoxb12.Enabled = flag;
            comboBoxb1.Enabled = flag;
            comboBoxb2.Enabled = flag;
        }

        void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;					// Subscribe for capturing events.
                else
                    MessageBox.Show("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Enroller = new DPFP.Processing.Enrollment();			// Create an enrollment.
            UpdateStatus();
        }

        void Process(DPFP.Sample Sample)
        {
            int a=1;
            this.Invoke((MethodInvoker)delegate
            {
                a = tabControl1.SelectedIndex;
            });
            this.Invoke((MethodInvoker)delegate
            { label45.Visible = false; });
            // Draw fingerprint sample image.
            DrawPicture(ConvertSampleToBitmap(Sample),a);
        }

        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    //MessageBox.Show("Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    //MessageBox.Show("Can't initiate capture!");
                }
            }
        }


        protected void Stop()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StopCapture();
                }
                catch
                {
                    //MessageBox.Show("Can't terminate capture!");
                }
            }
        }

        private void CaptureForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }

        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            Process(Sample);
            // Process the sample and create a feature set for the enrollment purpose.
            DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Enrollment);
            // Check quality of the sample and add to enroller if it's good
            if (features != null) try
                {
                    //MakeReport("The fingerprint feature set was created.");
                    Enroller.AddFeatures(features);		// Add feature set to template.
                    
                }
                finally
                {
                    UpdateStatus();

                    // Check if template has been created.
                    switch (Enroller.TemplateStatus)
                    {
                        case DPFP.Processing.Enrollment.Status.Ready:	// report success and stop capturing
                            //OnTemplate(Enroller.Template);
                            fp = true;
                            bit = new Byte[Enroller.Template.Size];
                            Enroller.Template.Serialize(ref bit);
                            MessageBox.Show("Input data fingerprint sukses.");
                            Stop();
                            break;

                        case DPFP.Processing.Enrollment.Status.Failed:	// report failure and restart capturing
                            Enroller.Clear();
                            fp = false;
                            Stop();
                            UpdateStatus();
                            //OnTemplate(null);
                            Start();
                            break;
                    }
                }
        }


        public Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }

        protected DPFP.FeatureSet ExtractFeatures(DPFP.Sample Sample, DPFP.Processing.DataPurpose Purpose)
        {
            DPFP.Processing.FeatureExtraction Extractor = new DPFP.Processing.FeatureExtraction();	// Create a feature extractor
            DPFP.Capture.CaptureFeedback feedback = DPFP.Capture.CaptureFeedback.None;
            DPFP.FeatureSet features = new DPFP.FeatureSet();
            Extractor.CreateFeatureSet(Sample, Purpose, ref feedback, ref features);			// TODO: return features as a result?
            if (feedback == DPFP.Capture.CaptureFeedback.Good)
                return features;
            else
                return null;
        }

        public void SetStatus(string status,int indextab)
        {
            if(indextab==0)
                this.Invoke((MethodInvoker)delegate { StatusLine.Text = status;});
            else
                this.Invoke((MethodInvoker)delegate { StatusLine2.Text = status; });
        }

        public void DrawPicture(Bitmap bitmap,int indextab)
        {
            if (indextab == 0)
                Picture.Image = new Bitmap(bitmap, Picture.Size);
            else
                Picture2.Image = new Bitmap(bitmap, Picture.Size);
            // fit the image into the picture box
        }
        private void UpdateStatus()
        {
            int a = 1;
            this.Invoke((MethodInvoker)delegate
            {
                a = tabControl1.SelectedIndex;
            });
            // Show number of samples needed.
            SetStatus(String.Format("Fingerprint samples needed: {0}", Enroller.FeaturesNeeded),a);
        }

        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was touched.");
        }

        public void OnReaderConnect(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was connected.");
        }

        public void OnReaderDisconnect(object Capture, string ReaderSerialNumber)
        {
            //MakeReport("The fingerprint reader was disconnected.");
        }

        public void OnSampleQuality(object Capture, string ReaderSerialNumber, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            /*if (CaptureFeedback == DPFP.Capture.CaptureFeedback.Good)
                MakeReport("The quality of the fingerprint sample is good.");
                
            else
                MakeReport("The quality of the fingerprint sample is poor.");*/
                
        }

        private DPFP.Processing.Enrollment Enroller;
        private DPFP.Capture.Capture Capturer;

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Stop();
            Init();
            Start();
        }

        
    }
}