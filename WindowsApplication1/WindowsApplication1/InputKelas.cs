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
    public partial class InputKelas : Form
    {
        DataTable dt = new DataTable();
        int sesi;
        int count;
        string MK;
        private BindingSource bindingSource1 = new BindingSource();
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        public InputKelas(string matkul)
        {
            InitializeComponent();
            MK = matkul;
            //MK = "MP113";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            DataRow r=dt.NewRow();
            r["Kelas"] = textBox1.Text;
            r["Hari"] = comboBox1.Text;
            r["Sesi"] = comboBox2.Text;
            r["Ruang"] = textBox3.Text;
            dt.Rows.Add(r);
            dataGridView2.DataSource = dt;
            count++;
        }
        void getsesi()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
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
                MessageBox.Show("Anda belum mengeset parameter jumlah sesi pada satu hari");
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
        private void Form3_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("Kelas", typeof(string));
            dt.Columns.Add("Hari", typeof(string));
            dt.Columns.Add("Sesi", typeof(string));
            dt.Columns.Add("Ruang", typeof(string));
            getsesi();
            int counter = 1;
            while (counter <= sesi)
            {
                comboBox2.Items.Add(counter.ToString());
                counter++;
            }
            labelMP.Text = MK;
            GetData("SELECT kelas,hari,sesi,ruang from DataPerkuliahan where kode_MP='"+MK+"'");
            dataGridView1.DataSource = bindingSource1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            
                try
                {
                    while (i < count)
                    {
                        using (SqlConnection cn = new SqlConnection(conn))
                        {

                            cn.Open();
                            SqlCommand command = new SqlCommand();
                            command.Connection = cn;
                            command.CommandType = CommandType.Text;
                            command.CommandText = "INSERT into DataPerkuliahan(kode_MP,kelas,hari,sesi,ruang) values('" + MK + "','" + dt.Rows[i]["Kelas"].ToString() + "','" + dt.Rows[i]["Hari"].ToString() + "','" + dt.Rows[i]["Sesi"].ToString() + "','" + dt.Rows[i]["Ruang"].ToString() + "')";
                            command.ExecuteReader();
                            cn.Close();
                        }
                        i++;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Maaf, silahkan cek data, apakah kelas yang ada sama? Bila tidak, ada kesalahan pada database");
                }
                MessageBox.Show("Data berhasil dimasukkan");
                Close();
        }
    }
}