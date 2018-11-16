using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutMachine_v0._1
{
    public partial class Form1 : Form
    {
        Image originImage;
        Image step1, step2, step3;
        Image finalImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void motorStep_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumberKeypress(sender, e);
        }
        private void rangeWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumberKeypress(sender, e);
        
        }
        private void rangeHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            onlyNumberKeypress(sender, e);
        }

        private void onlyNumberKeypress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '1'|| e.KeyChar == '2' ||
               e.KeyChar == '3' || e.KeyChar == '4' ||
               e.KeyChar == '5' || e.KeyChar == '6' ||
               e.KeyChar == '7' || e.KeyChar == '8' ||
               e.KeyChar == '9' || e.KeyChar == '0' ||
               e.KeyChar == 8   || e.KeyChar == 46)
            {
                if (e.KeyChar == '.')
                {
                    TextBox text = (TextBox)sender;

                    if (text.Text.Contains("."))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else
                {
                    e.Handled = false;
                }                
            }
            else
            {
                e.Handled = true;
            }
        }

        private void captureBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            /*
            if (file.ShowDialog() == DialogResult.OK)
            {
                originImage = Image.FromFile(file.FileName);
                captureBox.Image = new Bitmap(originImage, captureBox.Width, captureBox.Height);
                tabControl1.SelectTab(0);
                step1Box.Image = null;
                step2Box.Image = null;
                step3Box.Image = null;
            }
            */
            
            WebClient web = new WebClient();
            web.DownloadFile(@"C:\Jian\CutMachine_v0.1\test1.jpg", Application.StartupPath + "souce.jpg");
            originImage = Image.FromFile(Application.StartupPath + "souce.jpg");
            captureBox.Image = new Bitmap(originImage, captureBox.Width, captureBox.Height);
            tabControl1.SelectTab(0);
            step1Box.Image = null;
            step2Box.Image = null;
            step3Box.Image = null;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            originImage.Save(Application.StartupPath + "/temp.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
            EdgeAlogorithm edge = new EdgeAlogorithm(Application.StartupPath + "/temp.jpeg");
            //1. final image
            finalImage = edge.ContourImage.Bitmap;
            finalBox.Image = new Bitmap(finalImage, finalBox.Width, finalBox.Height);
            step1 = edge.Step1.Bitmap;
            step1Box.Image = new Bitmap(step1, step1Box.Width, step1Box.Height);
            step2 = edge.Step2.Bitmap;
            step2Box.Image = new Bitmap(step2, step2Box.Width, step2Box.Height);
            step3 = edge.Step3.Bitmap;
            step3Box.Image = new Bitmap(step3, step3Box.Width, step3Box.Height);
            tabControl1.SelectTab(4);
        }

        public Mat ConvertBitmapToMat(Bitmap bmp)
        {
            // Lock the bitmap's bits.  
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
     
            System.Drawing.Imaging.BitmapData bmpData =
                bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat);
     
           // data = scan0 is a pointer to our memory block.
           IntPtr data = bmpData.Scan0;
    
           // step = stride = amount of bytes for a single line of the image
           int step = bmpData.Stride;
    
           // So you can try to get you Mat instance like this:
           Mat mat = new Mat(bmp.Height, bmp.Width, Emgu.CV.CvEnum.DepthType.Cv32F, 4, data, step);
    
           // Unlock the bits.
           //bmp.UnlockBits(bmpData);
    
           return mat;
       }

        private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Height = this.Height - 50;
            panel9.Height = this.Height - 50;
            panel9.Width = this.Width - panel9.Width - 30;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.MaximumSize = new Size(panel3.Width * 5, panel3.Width * 2);
            this.OnResize(null);
        }

        private void step1Box_Resize(object sender, EventArgs e)
        {
            PictureBox picBox = (PictureBox)sender;

            //picBox.Size = picBox.Parent.Size;
            //if (picBox.Image != null)
            //    picBox.Image = new Bitmap(picBox.Image, picBox.Width, picBox.Height);
        }

        private Bitmap ImageResize(Image img, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.Transparent);
            g.DrawImage(img, new Rectangle(0, 0, bmp.Width, bmp.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            return bmp;
        }
    }
}
