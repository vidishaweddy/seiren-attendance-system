using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class getMPforPljr : Form
    {
        string nomorinduk;
        private BindingSource bindingSource1 = new BindingSource();
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        public getMPforPljr(string no_induk)
        {
            InitializeComponent();
            nomorinduk = no_induk;
        }
        void setdata()
        {
            using (SqlConnection cn = new SqlConnection(conn))
            {

                SqlCommand cmd = new SqlCommand("SELECT kode_MP 'Kode Mata Pelajaran',kelas 'Kelas' FROM Absensi where no_induk='"+nomorinduk+"'",cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    checkedListBox1.Items.Add(rdr[0].ToString() + "-" + rdr[1].ToString(), true);
                }
                cn.Close();
                cmd.CommandText = "SELECT distinct kode_MP 'Kode Mata Pelajaran',kelas 'Kelas' FROM DataPerkuliahan where kode_MP not in(select kode_MP from Absensi where no_induk='"+nomorinduk+"')";
                cn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    checkedListBox1.Items.Add(rdr[0].ToString() + "-" + rdr[1].ToString(), false);
                }
                cn.Close();
                cmd.CommandText = "update Absensi set isactive='0' where no_induk='" + nomorinduk + "'";
                cn.Open();
                rdr = cmd.ExecuteReader();
                cn.Close();
            }
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
                SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCommand, connectionString);

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

        private void getMPforPljr_Load(object sender, EventArgs e)
        {
            GetData("SELECT m.kode_MP 'Kode Mata Pelajaran',m.nama_MP 'Nama Mata Pelajaran',a.kelas 'Kelas',a.hari 'Hari',a.sesi 'Sesi' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP");
            dataGridView1.DataSource = bindingSource1;
            setdata();
            label1.Text = nomorinduk;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = checkedListBox1.CheckedItems.Count;
            int i = 0;
            int k = 0;
            string data;
            string mp;
            string kelas;
            /*try
            {*/
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = cn;

                    while (i < count)
                    {
                        data = checkedListBox1.CheckedItems[i].ToString();
                        mp = data.Substring(0, data.IndexOf("-"));
                        kelas = data.Substring(data.IndexOf("-") + 1);
                        cn.Open();
                        command.CommandType = CommandType.Text;
                        command.CommandText = "update Absensi set isactive='1' where kode_MP='" + mp + "' and kelas='" + kelas + "' and no_induk='"+nomorinduk+"'";
                        command.ExecuteReader();
                        cn.Close();
                        i++;
                    }
                    cn.Open();
                    command.CommandType = CommandType.Text;
                    command.CommandText = "delete from Absensi where isactive='0'";
                    command.ExecuteReader();
                    cn.Close();
                    while (k < count)
                    {
                        data = checkedListBox1.CheckedItems[k].ToString();
                        mp = data.Substring(0, data.IndexOf("-"));
                        kelas = data.Substring(data.IndexOf("-") + 1);
                        command.CommandText = "SELECT m.kode_MP 'Kode Mata Pelajaran' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP ,Absensi i where i.no_induk='" + nomorinduk + "' and i.kode_MP='"+mp+"' ";
                        cn.Open();
                        SqlDataReader rdr = command.ExecuteReader();
                        if (!rdr.Read())
                        {
                            cn.Close();
                            cn.Open();
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT into Absensi(no_induk,kode_MP,no_pertemuan,kelas,flag_masuk,flag_ijin,flag_sakit,isactive) values('" + nomorinduk + "','" + mp + "','0','" + kelas + "','0','0','0','1') ";
                            command.ExecuteReader();
                            cn.Close();
                            k++;
                        }
                        else
                        {
                            cn.Close();
                            k++;
                        }
                    }
                }
                MessageBox.Show("Data berhasil dimasukkan");
                Close();
            //}
            //catch (Exception) { MessageBox.Show("Mohon Maaf, data tak dapat dimasukkan"); }
        }

    }
}