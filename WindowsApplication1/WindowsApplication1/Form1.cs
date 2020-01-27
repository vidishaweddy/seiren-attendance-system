using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus.png";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah1.png";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah1.png";
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
            }
            else if (panel2.Visible == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah.png";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah1.png";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus1.png";
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah.png";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus1.png";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah1.png";
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah.png";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah1.png";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus1.png"; 
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus.png";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah1.png";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah1.png";
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = true;
            }
            else if (panel3.Visible == true)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah.png";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah1.png";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus1.png";
                panel1.Visible = true;
                panel2.Visible = false;
                panel3.Visible = false;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\ubah.png";
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\hapus1.png";
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox3.ImageLocation = @"C:\Users\VidiValianto\Documents\Visual Studio 2005\Projects\WindowsApplication1\WindowsApplication1\images\tambah1.png";
                panel1.Visible = false;
                panel2.Visible = true;
                panel3.Visible = false;
            }
        }
    }
}