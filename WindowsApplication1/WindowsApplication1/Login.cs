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
    public partial class Login : Form
    {
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code;
            Form1 f1 = new Form1();
            Login f2 = new Login();
            using (SqlConnection cn = new SqlConnection(conn))
            {
                SqlCommand cmd = new SqlCommand("SELECT role from Login where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "' ", cn);
                cn.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                rdr.Read();
                if (rdr.HasRows == true)
                {
                    code = rdr[0].ToString();
                    cn.Close();
                    if (code.Equals("1"))
                    {
                        f1.Show();
                        Hide();
                    }
                     
                    else if (code.Equals("2"))
                        label1.Text = "2";
                    else
                        label1.Text = "3";
                }
            }
        }
    }
}