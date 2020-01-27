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
    public partial class MP : Form
    {
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public MP()
        {
            InitializeComponent();
        }

        private void buttonadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                MessageBox.Show("Ada data yang kurang, silakan diperiksa");
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {

                    cn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = cn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "INSERT into MP(kode_MP,nama_MP,jumlah_SKS,semester_MP) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                    command.ExecuteReader();
                    cn.Close();
                }
                if (MessageBox.Show("Mata pelajaran ini tak memiliki kelas, Apakah anda ingin menambah kelas untuk mata pelajaran ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    InputKelas f1 = new InputKelas(textBox1.Text);
                    f1.Show();
                }
                else
                {
                }
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"^([\d\b]|\s)*$"))
                e.Handled = true;
        }

        private void MP_Load(object sender, EventArgs e)
        {
            GetData("select kode_MP 'Kode Mata Pelajaran',nama_MP 'Nama Mata Pelajaran',jumlah_SKS 'Jumlah SKS',semester_MP 'Semester' from MP");
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
        void setEnable(bool flag)
        {
            textBoxa2.Enabled = flag;
            textBoxa3.Enabled = flag;
            textBoxa4.Enabled = flag;
        }
        void setEnable2(bool flag)
        {
            textBoxb2.Enabled = flag;
            textBoxb3.Enabled = flag;
            textBoxb4.Enabled = flag;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MP f1 = new MP();
            f1.Show();
            Hide();
        }

        private void buttonedit_Click(object sender, EventArgs e)
        {
            if (textBoxa1.Text.Equals("") || textBoxa2.Text.Equals("") || textBoxa3.Text.Equals("") || textBoxa4.Text.Equals(""))
            {
                MessageBox.Show("Ada data yang kurang, silakan diperiksa");
            }
            else
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {

                    cn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = cn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "update MP set nama_MP='" + textBoxa2.Text + "',jumlah_SKS='" + textBoxa3.Text + "',semester_MP='" + textBoxa4.Text + "' where kode_MP='" + textBoxa1.Text + "'";
                    command.ExecuteReader();
                    cn.Close();
                }
                if (MessageBox.Show("Apakah anda ingin menambah kelas untuk mata pelajaran ini?", "Tambah Kelas", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    InputKelas f1 = new InputKelas(textBoxa1.Text);
                    f1.Show();
                }
                else
                {

                }
            }
        }

        private void buttondelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda akan menghapus data ini?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    cn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = cn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "delete from MP where kode_MP='" + textBoxb1.Text + "'";
                    command.ExecuteReader();
                    cn.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama_MP,jumlah_SKS,semester_MP from MP where kode_MP='" + textBoxa1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();

                    textBoxa3.Text = rdr[1].ToString();
                    textBoxa4.Text = rdr[2].ToString();
                    textBoxa2.Text = rdr[0].ToString();
                }
                setEnable(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Data dengan kode mata pelajaran ini tidak ada");
                setEnable(false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama_MP,jumlah_SKS,semester_MP from MP where kode_MP='" + textBoxb1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();

                    textBoxb3.Text = rdr[1].ToString();
                    textBoxb4.Text = rdr[2].ToString();
                    textBoxb2.Text = rdr[0].ToString();
                }
                setEnable2(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Data dengan kode mata pelajaran ini tidak ada");
                setEnable2(false);
            }
        }
    }
}