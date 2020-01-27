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
    public partial class GetMPforPngjr : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        string kodepngjr;
        public GetMPforPngjr(string kode)
        {
            InitializeComponent();
            kodepngjr = kode;
        }
        void setdata()
        {
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT m.kode_MP 'Kode Mata Pelajaran',a.kelas 'Kelas' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP where a.kode_pengajar='"+kodepngjr+"'", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    checkedListBox1.Items.Add(rdr[0].ToString() + "-" + rdr[1].ToString(), true);
                }
                cn.Close();
                cmd.CommandText="SELECT m.kode_MP 'Kode Mata Pelajaran',a.kelas 'Kelas' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP where a.kode_pengajar is null";
                cn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    checkedListBox1.Items.Add(rdr[0].ToString() + "-" + rdr[1].ToString(), false);
                }
                cn.Close();
                cmd.CommandText = "update DataPerkuliahan set kode_pengajar=null where kode_pengajar='" + kodepngjr + "'";
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

        private void Form2_Load(object sender, EventArgs e)
        {
            GetData("SELECT m.kode_MP 'Kode Mata Pelajaran',m.nama_MP 'Nama Mata Pelajaran',a.kelas 'Kelas',a.hari 'Hari',a.sesi 'Sesi' FROM MP m join DataPerkuliahan a on m.kode_MP=a.kode_MP where a.kode_pengajar is null");
            dataGridView1.DataSource = bindingSource1;
            setdata();
            label1.Text = kodepngjr;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count=checkedListBox1.CheckedItems.Count;
            int i = 0;
            string data;
            string mp;
            string kelas;
            try
                {
                    using (SqlConnection cn = new SqlConnection(conn))
                    {
                        SqlCommand command = new SqlCommand();
                        command.Connection = cn;
                        while (i < count)
                        {
                            data=checkedListBox1.CheckedItems[i].ToString();
                            mp = data.Substring(0, data.IndexOf("-"));
                            kelas = data.Substring(data.IndexOf("-")+1);
                            cn.Open();
                            command.CommandType = CommandType.Text;
                            command.CommandText = "update DataPerkuliahan set kode_pengajar='" + kodepngjr + "' where kode_MP='" + mp + "' and kelas='" + kelas + "'";
                            command.ExecuteReader();
                            cn.Close();
                            i++;
                        }
                    }
                    MessageBox.Show("Data berhasil dimasukkan");
                    Close();
                }
                catch (Exception) { MessageBox.Show("Mohon Maaf, data tak dapat dimasukkan"); }
        }

    }
}