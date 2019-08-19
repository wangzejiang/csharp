using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public partial class PrintForm : Form
    {
        private Image image;
        public PrintForm(Image img)
        {
            this.image = img;
            InitializeComponent();
        }

        private void PrintForm_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = image;
        }
    }
}
