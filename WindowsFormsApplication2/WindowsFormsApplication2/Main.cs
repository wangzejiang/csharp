using CefSharp;
using CefSharp.WinForms;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anylsycm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f3 = new Form3();
            f3.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var settings = new CefSettings
            {
                Locale = "zh-CN",
                AcceptLanguageList = "zh-CN",
                MultiThreadedMessageLoop = true
            };
            Cef.Initialize(settings);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form f4 = new Form4();
            f4.Show();
        }
    }
}
