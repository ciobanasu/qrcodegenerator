using System;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace QRCodeGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnSaveQRCode.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            QRCoder.QRCodeGenerator qrCode = new QRCoder.QRCodeGenerator();
            var myData = qrCode.CreateQrCode(txtQRCode.Text, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(myData);
            pictureBox1.Image = code.GetGraphic(50);
            btnSaveQRCode.Visible = true;
        }

        private void btnSaveQRCode_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        public void SaveImage()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.png;*.bmp;*jpg";
            ImageFormat format = ImageFormat.Png;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = ImageFormat.Bmp;
                        break;
                }
                pictureBox1.Image.Save(sfd.FileName, format);
            }
        }
    }
}
