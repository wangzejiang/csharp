using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mc
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void ScreenSend()
        {
            Socket receiveSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint hostIpEndPoint = new IPEndPoint(IPAddress.Parse("192.168.0.22"), 121);

            //设置接收数据缓冲区的大小
            byte[] b = new byte[40960];
            receiveSocket.Bind(hostIpEndPoint);
            //监听
            receiveSocket.Listen(2);

            while (true)
            {
                //接受客户端连接
                Socket hostSocket = receiveSocket.Accept();
                //如何确定该数组大小
                MemoryStream fs = new MemoryStream();
                int length = 0;
                //每次只能读取小于等于缓冲区的大小
                while ((length = hostSocket.Receive(b)) > 0)
                {
                    fs.Write(b, 0, length);
                }
                fs.Flush();
                Bitmap Img = new Bitmap(fs);
                pictureBox1.Image = Img;
                fs.Close();
               // hostSocket.Shutdown(SocketShutdown.Receive);
                //hostSocket.Close();
            }
            
            //关闭发送连接
            // receiveSocket.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Thread ScreenSendThread = new Thread(new ThreadStart(ScreenSend));

            ScreenSendThread.Start();
            MessageBox.Show("Test");
        }
    }
}
