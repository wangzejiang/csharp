using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public partial class EditProduct : Form
    {
        private ProductInfo pro = new ProductInfo();
        private Attachment att = new Attachment();
        internal MainForm mainForm;

        public EditProduct(int PID, Guid PImageID)
        {
            pro.PID = PID;
            att.ID = PImageID;
            InitializeComponent();
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            pro = ProductInfoManager.GetProductInfo2(pro);
            textBox_pName.Text = pro.PName;
            textBox_pNumber.Text = pro.PNumber;
            textBox_pPrice.Text = pro.PPrice.ToString();
            textBox_pPriceX.Text = pro.PPriceX.ToString();
            textBox_pRemark.Text = pro.PRemark;
            textBox_pSuppliter.Text = pro.PSuppliter;
            textBox_pWeight.Text = pro.PWeigth.ToString();
            MemoryStream ms = new MemoryStream(pro.PImageBytes); 
            pictureBox_pImage.Image = Image.FromStream(ms);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pro.PName = textBox_pName.Text;
            pro.PNumber = textBox_pNumber.Text;
            pro.PPrice = decimal.Parse(textBox_pPrice.Text);
            pro.PPriceX = decimal.Parse(textBox_pPriceX.Text);
            pro.PRemark = textBox_pRemark.Text;
            pro.PSuppliter = textBox_pSuppliter.Text;
            pro.PWeigth = decimal.Parse(textBox_pWeight.Text);
            pro.PImageID = null;
            pro.CreateDate = null;
            pro.UpdateDate = null;
            ProductInfo pInfo = new ProductInfo();
            pInfo.PID = pro.PID;
            int idx = ProductInfoManager.UpdateProductInfo(pro, pInfo);
            if (idx > 0)
            {
                mainForm.selectProduct(pro.PID);
                MessageBoxEx.Show(this, "修改商品信息成功!");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "iamge files(*.jpg)|*.jpg";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog(this) == DialogResult.OK)
            {
                Image img = Image.FromFile(ofd.FileName);
                Bitmap newImg = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(newImg);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, new Rectangle(0, 0, 100, 100), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                g.Dispose();
                MemoryStream ms = new MemoryStream();
                newImg.Save(ms, ImageFormat.Jpeg);
                byte[] bs = ms.ToArray();

                pictureBox_pImage.Image = img;

                Attachment attachment = new Attachment();
                attachment.Content = bs;
                attachment.Length = bs.Length;
                int idx = AttachmentManager.UpdateAttachment(attachment, att);
                if(idx > 0)
                {
                    mainForm.selectProduct(pro.PID);
                    MessageBoxEx.Show(this, "修改商品图片成功!");
                }
            }
        }
    }
}
