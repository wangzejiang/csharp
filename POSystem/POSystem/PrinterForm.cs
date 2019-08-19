using Aspose.Cells;
using Aspose.Cells.Rendering;
using POSystem.BLL;
using POSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSystem
{
    public partial class PrinterForm : Form
    {
        private int OID;
        private Worksheet worksheet;
        private ImageOrPrintOptions options;
        public void init()
        {
            worksheet = Common.getPrintWorkbook(OID);
            //Worksheet worksheet = new Worksheet();
            //Get the worksheet to be printed
            worksheet.PageSetup.Orientation = PageOrientationType.Portrait;
            //worksheet.PageSetup.TopMargin = 0.1;
            worksheet.PageSetup.LeftMargin = 0.1;
            worksheet.PageSetup.RightMargin = 0.1;
            worksheet.PageSetup.BottomMargin = 0.1;
            worksheet.PageSetup.PrintArea = string.Format("A1:J{0}", worksheet.Cells.MaxRow);
            options = new ImageOrPrintOptions();
            options.ImageFormat = ImageFormat.Jpeg;
            options.PrintingPage = PrintingPageType.IgnoreBlank;

        }
        public PrinterForm(int OID)
        {
            this.OID = OID;
            InitializeComponent();
            init();
            PrinterSettings printSettings = new PrinterSettings();
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                string pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(pkInstalledPrinters);
            }
            comboBox1.Text = printSettings.PrinterName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SheetRender sr = new SheetRender(worksheet, options);
            for (int i = 0; i < sr.PageCount; i++)
            {
                Image map = sr.ToImage(i);
                map.Save("img" + i + ".jpg");
                PrintForm PrintForm = new PrintForm(map);
                PrintForm.StartPosition = FormStartPosition.CenterParent;
                PrintForm.Show(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SheetRender sr = new SheetRender(worksheet, options);
            string strPrinterName = comboBox1.Text;
            sr.ToPrinter(strPrinterName);
            OrderInfo oldorder = new OrderInfo();
            oldorder.OID = OID;
            OrderInfo neworder = new OrderInfo();
            neworder.OStatus = 1;
            OrderInfoManager.UpdateOrderInfo(neworder, oldorder);
            this.Close();
        }
    }
}
