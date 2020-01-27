using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsApplication1
{
    public partial class Absenform : Form, DPFP.Capture.EventHandler
    {
        string conn = "Server=VIDIVALIANTO-PC;Database=seirendb;User Id=sa; password=*gunawan70807;";
        bool masuk = false;
        bool ijin = false;
        bool sakit = false;
        string barcode = "";
        public Absenform()
        {
            InitializeComponent();
            labelBD.Visible = false;
            labelFP.Visible = false;
            Picture.Visible = false;
            textBoxBD.Visible = false;
            panel2.Visible = false;
            this.Height = 350;
            textBoxket.Enabled = false;
            button2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            textBox1.Text = "2";
            //this.Size.Height = 545;
            //this.Size.Width = 450;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                labelFP.Visible = true;
                Picture.Visible = true;
                this.Height = 545;
                Init();
                Start();
            }
            else
            {
                labelFP.Visible = false;
                Picture.Visible = false;
                this.Height = 350;
                Stop();
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                labelBD.Visible = true;
                textBoxBD.Visible = true;
                this.Height = 380;
            }
            else
            {
                labelBD.Visible = false;
                textBoxBD.Visible = false;
                this.Height = 350;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                panel2.Visible = true;
                this.Height = 545;
            }
            else
            {
                panel2.Visible = false;
                this.Height = 350;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*try
            {*/
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlCommand cmd = new SqlCommand("SELECT nama from Pelajar where no_induk='" + textBox1.Text + "'", cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();
                    textBox2.Text = rdr[0].ToString();
                    cn.Close();
                    cmd.CommandText="select kodebarcode from DataAbsensiPelajar where no_induk='" + textBox1.Text + "'";
                    cmd.Connection = cn;
                    cn.Open();
                    rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    rdr.Read();
                    if (rdr.HasRows)
                    {
                        barcode = rdr[0].ToString();
                    }
                    cn.Close();
                }
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
            /*}
            catch (Exception)
            {
                MessageBox.Show("Data dengan Nomor Induk ini tidak ditemukan");
            }*/
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                textBoxket.Enabled = false;
                button1.Enabled = true;
                masuk = true;
                ijin = false;
                sakit = false;
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                textBoxket.Enabled = true;
                masuk = false;
                ijin = true;
                sakit = false;
                MessageBox.Show("Anda harus mengisi keterangan ijin untuk melanjutkan");
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                textBoxket.Enabled = true;
                masuk = false;
                ijin = false;
                sakit = true;
                MessageBox.Show("Anda harus mengisi keterangan sakit untuk melanjutkan");
            }
        }

        private void textBoxket_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!textBoxket.Text.Equals(""))
            {
                button2.Enabled = true;
                status.Text = "Belum Terverifikasi";
            }
            else
            {
                button2.Enabled = false;
                status.Text = "Terverifikasi";
            }
        }
        public void Verify(DPFP.Template template)
        {
            Template = template;
            ShowDialog();
        }

        protected void Init()
        {
            try
            {
                Capturer = new DPFP.Capture.Capture();				// Create a capture operation.

                if (null != Capturer)
                    Capturer.EventHandler = this;
                else// Subscribe for capturing events.
                    MessageBox.Show("Can't initiate capture operation!");
            }
            catch
            {
                MessageBox.Show("Can't initiate capture operation!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Verificator = new DPFP.Verification.Verification();		// Create a fingerprint template verificator
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
        protected void Process(DPFP.Sample Sample)
        {
            DrawPicture(ConvertSampleToBitmap(Sample));
            // Process the sample and create a feature set for the enrollment purpose.
            
        }
        private void DrawPicture(Bitmap bitmap)
        {
                Picture.Image = new Bitmap(bitmap, Picture.Size);	// fit the image into the picture box
        }
        protected Bitmap ConvertSampleToBitmap(DPFP.Sample Sample)
        {
            DPFP.Capture.SampleConversion Convertor = new DPFP.Capture.SampleConversion();	// Create a sample convertor.
            Bitmap bitmap = null;												            // TODO: the size doesn't matter
            Convertor.ConvertToPicture(Sample, ref bitmap);									// TODO: return bitmap as a result
            return bitmap;
        }
        protected void Start()
        {
            if (null != Capturer)
            {
                try
                {
                    Capturer.StartCapture();
                    //SetPrompt("Using the fingerprint reader, scan your fingerprint.");
                }
                catch
                {
                    //SetPrompt("Can't initiate capture!");
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
                    //SetPrompt("Can't terminate capture!");
                }
            }
        }
        public void OnComplete(object Capture, string ReaderSerialNumber, DPFP.Sample Sample)
        {
            string nim = "";
            if (radioButton1.Checked)
            {
                this.Invoke((MethodInvoker)delegate
                            { nim = textBox1.Text; });
                Process(Sample);
                DPFP.FeatureSet features = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);
                DPFP.Template Template3 = new DPFP.Template();
                using (SqlConnection cn = new SqlConnection(conn))
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("select kodefingerprint from DataAbsensiPelajar where no_induk='"+nim+"' ", conn);
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds, "data");
                    DataRow myRow;
                    byte[] MyData = new byte[0];
                    myRow = ds.Tables["data"].Rows[0];
                    MyData = (byte[])myRow["kodefingerprint"];
                    Template3.DeSerialize(MyData);
                }
                // Check quality of the sample and start verification if it's good
                // TODO: move to a separate task
                if (features != null)
                {
                    // Compare the feature set with our template
                    DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                    Verificator.Verify(features, Template3, ref result);
                    if (result.Verified)
                    {

                        this.Invoke((MethodInvoker)delegate
                            { status.Text = "Terverifikasi"; });
                        masuk = true;
                        ijin = false;
                        sakit = false;
                        this.Invoke((MethodInvoker)delegate
                            { button2.Enabled = true; });
                    }
                    else
                    {
                        masuk = false;
                        this.Invoke((MethodInvoker)delegate
                            { status.Text = "Belum Terverifikasi"; });
                    }
                }
            }
        }
        public void OnFingerGone(object Capture, string ReaderSerialNumber)
        {
            //MessageBox.Show("The finger was removed from the fingerprint reader.");
        }

        public void OnFingerTouch(object Capture, string ReaderSerialNumber)
        {
            //MessageBox.Show("The fingerprint reader was touched.");
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
        private DPFP.Verification.Verification Verificator;
        private DPFP.Capture.Capture Capturer;
        private DPFP.Template Template;

        private void Absenform_Load(object sender, EventArgs e)
        {
            
        }

        private void Absenform_FormClosed(object sender, FormClosedEventArgs e)
        {
            Stop();
        }
        private void textBoxBD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!barcode.Equals(""))
            {
                if (textBoxBD.Text.Equals(barcode))
                {
                    status.Text = "Terverifikasi";
                    masuk = true;
                    ijin = false;
                    sakit = false;
                    button2.Enabled = true;
                }
                else
                {
                    masuk = false;
                    status.Text = "Belum Terverifikasi";
                }
            }
        }
    }
}