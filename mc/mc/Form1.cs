using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            iWidth = Screen.PrimaryScreen.Bounds.Width;
            iHeight = Screen.PrimaryScreen.Bounds.Height;
            s = new Size(iWidth, iHeight);
            p = new Point(0, 0);
            r1 = new Rectangle(0, 0, iWidth / 2, iWidth / 2);
            r2 = new Rectangle(0, 0, iWidth, iHeight);
            img = new Bitmap(iWidth, iHeight);
            gc = Graphics.FromImage(img);
            gc.InterpolationMode = InterpolationMode.Low;

            IPEndPoint ipendpiont = new IPEndPoint(IPAddress.Parse("192.168.0.22"), 121);
            sendsocket.Connect(ipendpiont);

            timer1.Interval = 1000;
            timer1.Start();


            MessageBox.Show("Test");
        }

        private Rectangle r1;
        private Rectangle r2;
        private int iWidth;
        private int iHeight;
        private Image img;
        private Graphics gc;
        private Point p;
        private Size s;

        static Socket sendsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] imgByte = new byte[10240];

        private void timer1_Tick(object sender, EventArgs e)
        {
            gc.CopyFromScreen(p, p, s);
            gc.DrawImage(img, r1, r2, GraphicsUnit.Pixel);
            imgByte = photoImageInsert(img);

            sendsocket.Send(imgByte);
           //sendsocket.Shutdown(System.Net.Sockets.SocketShutdown.Send);
           //sendsocket.Close();
            //sendsocket.Dispose();
            //timer1.Stop();
        }

        public byte[] photoImageInsert(System.Drawing.Image imgPhoto)
        {
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
