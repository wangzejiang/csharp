namespace POSystem
{
    partial class EditOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtp_OrderDate = new System.Windows.Forms.DateTimePicker();
            this.txt_orderNumber = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Order_CName = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_Order_CPhone = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_Order_CAddress = new System.Windows.Forms.TextBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_WeigthCount = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txt_OrderPriceXCount = new System.Windows.Forms.TextBox();
            this.txt_OrderPriceCount = new System.Windows.Forms.TextBox();
            this.txt_OrderPriceZCount = new System.Windows.Forms.TextBox();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.dgvSubOrders = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_OrderOtherPrice = new System.Windows.Forms.TextBox();
            this.txt_Order_PriceOK = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_OrderRemark2 = new System.Windows.Forms.TextBox();
            this.txt_OrderRemark = new System.Windows.Forms.TextBox();
            this.button10 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubOrders)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtp_OrderDate);
            this.panel2.Controls.Add(this.txt_orderNumber);
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1296, 145);
            this.panel2.TabIndex = 4;
            // 
            // dtp_OrderDate
            // 
            this.dtp_OrderDate.Location = new System.Drawing.Point(595, 110);
            this.dtp_OrderDate.Name = "dtp_OrderDate";
            this.dtp_OrderDate.Size = new System.Drawing.Size(150, 21);
            this.dtp_OrderDate.TabIndex = 2;
            // 
            // txt_orderNumber
            // 
            this.txt_orderNumber.Location = new System.Drawing.Point(307, 110);
            this.txt_orderNumber.Name = "txt_orderNumber";
            this.txt_orderNumber.ReadOnly = true;
            this.txt_orderNumber.Size = new System.Drawing.Size(199, 21);
            this.txt_orderNumber.TabIndex = 1;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(224, 114);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(65, 12);
            this.label28.TabIndex = 4;
            this.label28.Text = "订单编号：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(512, 114);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(65, 12);
            this.label22.TabIndex = 4;
            this.label22.Text = "订单时间：";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.txt_Order_CName);
            this.groupBox8.Controls.Add(this.label18);
            this.groupBox8.Controls.Add(this.txt_Order_CPhone);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.txt_Order_CAddress);
            this.groupBox8.Controls.Add(this.button8);
            this.groupBox8.Location = new System.Drawing.Point(19, 14);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(726, 86);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "客户信息";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(15, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 12);
            this.label17.TabIndex = 0;
            this.label17.Text = "名称:";
            // 
            // txt_Order_CName
            // 
            this.txt_Order_CName.Location = new System.Drawing.Point(70, 16);
            this.txt_Order_CName.Name = "txt_Order_CName";
            this.txt_Order_CName.Size = new System.Drawing.Size(245, 21);
            this.txt_Order_CName.TabIndex = 1;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(378, 20);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(65, 12);
            this.label18.TabIndex = 0;
            this.label18.Text = "联系方式：";
            // 
            // txt_Order_CPhone
            // 
            this.txt_Order_CPhone.Location = new System.Drawing.Point(456, 16);
            this.txt_Order_CPhone.Name = "txt_Order_CPhone";
            this.txt_Order_CPhone.Size = new System.Drawing.Size(232, 21);
            this.txt_Order_CPhone.TabIndex = 1;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 12);
            this.label19.TabIndex = 0;
            this.label19.Text = "地址:";
            // 
            // txt_Order_CAddress
            // 
            this.txt_Order_CAddress.Location = new System.Drawing.Point(70, 48);
            this.txt_Order_CAddress.Name = "txt_Order_CAddress";
            this.txt_Order_CAddress.Size = new System.Drawing.Size(618, 21);
            this.txt_Order_CAddress.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(321, 16);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(36, 23);
            this.button8.TabIndex = 2;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.Controls.Add(this.txt_WeigthCount);
            this.groupBox7.Controls.Add(this.label25);
            this.groupBox7.Controls.Add(this.label24);
            this.groupBox7.Controls.Add(this.label20);
            this.groupBox7.Controls.Add(this.txt_OrderPriceXCount);
            this.groupBox7.Controls.Add(this.txt_OrderPriceCount);
            this.groupBox7.Controls.Add(this.txt_OrderPriceZCount);
            this.groupBox7.Location = new System.Drawing.Point(776, 14);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(502, 119);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "订单信息";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(31, 33);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 12);
            this.label21.TabIndex = 0;
            this.label21.Text = "总重量:";
            // 
            // txt_WeigthCount
            // 
            this.txt_WeigthCount.Location = new System.Drawing.Point(93, 30);
            this.txt_WeigthCount.Name = "txt_WeigthCount";
            this.txt_WeigthCount.ReadOnly = true;
            this.txt_WeigthCount.Size = new System.Drawing.Size(130, 21);
            this.txt_WeigthCount.TabIndex = 3;
            this.txt_WeigthCount.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(263, 71);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 12);
            this.label25.TabIndex = 0;
            this.label25.Text = "总售价:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(263, 33);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "总成本:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(31, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 0;
            this.label20.Text = "总利润:";
            // 
            // txt_OrderPriceXCount
            // 
            this.txt_OrderPriceXCount.Location = new System.Drawing.Point(325, 68);
            this.txt_OrderPriceXCount.Name = "txt_OrderPriceXCount";
            this.txt_OrderPriceXCount.ReadOnly = true;
            this.txt_OrderPriceXCount.Size = new System.Drawing.Size(130, 21);
            this.txt_OrderPriceXCount.TabIndex = 3;
            this.txt_OrderPriceXCount.Text = "0";
            // 
            // txt_OrderPriceCount
            // 
            this.txt_OrderPriceCount.Location = new System.Drawing.Point(325, 30);
            this.txt_OrderPriceCount.Name = "txt_OrderPriceCount";
            this.txt_OrderPriceCount.ReadOnly = true;
            this.txt_OrderPriceCount.Size = new System.Drawing.Size(130, 21);
            this.txt_OrderPriceCount.TabIndex = 3;
            this.txt_OrderPriceCount.Text = "0";
            // 
            // txt_OrderPriceZCount
            // 
            this.txt_OrderPriceZCount.Location = new System.Drawing.Point(93, 68);
            this.txt_OrderPriceZCount.Name = "txt_OrderPriceZCount";
            this.txt_OrderPriceZCount.ReadOnly = true;
            this.txt_OrderPriceZCount.Size = new System.Drawing.Size(130, 21);
            this.txt_OrderPriceZCount.TabIndex = 3;
            this.txt_OrderPriceZCount.Text = "0";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(106, 108);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(74, 27);
            this.button9.TabIndex = 0;
            this.button9.Text = "移除商品";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(19, 108);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(74, 27);
            this.button7.TabIndex = 0;
            this.button7.Text = "添加商品";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // dgvSubOrders
            // 
            this.dgvSubOrders.AllowUserToAddRows = false;
            this.dgvSubOrders.AllowUserToDeleteRows = false;
            this.dgvSubOrders.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvSubOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubOrders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubOrders.Location = new System.Drawing.Point(0, 145);
            this.dgvSubOrders.Name = "dgvSubOrders";
            this.dgvSubOrders.RowTemplate.Height = 100;
            this.dgvSubOrders.Size = new System.Drawing.Size(1296, 684);
            this.dgvSubOrders.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label30);
            this.panel4.Controls.Add(this.label29);
            this.panel4.Controls.Add(this.txt_OrderOtherPrice);
            this.panel4.Controls.Add(this.txt_Order_PriceOK);
            this.panel4.Controls.Add(this.label27);
            this.panel4.Controls.Add(this.label26);
            this.panel4.Controls.Add(this.txt_OrderRemark2);
            this.panel4.Controls.Add(this.txt_OrderRemark);
            this.panel4.Controls.Add(this.button10);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 829);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1296, 68);
            this.panel4.TabIndex = 6;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(693, 45);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(65, 12);
            this.label30.TabIndex = 3;
            this.label30.Text = "其他费用：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(693, 16);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 12);
            this.label29.TabIndex = 3;
            this.label29.Text = "实际售价：";
            // 
            // txt_OrderOtherPrice
            // 
            this.txt_OrderOtherPrice.Location = new System.Drawing.Point(776, 40);
            this.txt_OrderOtherPrice.Name = "txt_OrderOtherPrice";
            this.txt_OrderOtherPrice.Size = new System.Drawing.Size(176, 21);
            this.txt_OrderOtherPrice.TabIndex = 1;
            // 
            // txt_Order_PriceOK
            // 
            this.txt_Order_PriceOK.Location = new System.Drawing.Point(776, 11);
            this.txt_Order_PriceOK.Name = "txt_Order_PriceOK";
            this.txt_Order_PriceOK.Size = new System.Drawing.Size(176, 21);
            this.txt_Order_PriceOK.TabIndex = 1;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(347, 14);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(65, 12);
            this.label27.TabIndex = 2;
            this.label27.Text = "内部备注：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(16, 14);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(65, 12);
            this.label26.TabIndex = 2;
            this.label26.Text = "订单备注：";
            // 
            // txt_OrderRemark2
            // 
            this.txt_OrderRemark2.Location = new System.Drawing.Point(430, 11);
            this.txt_OrderRemark2.Multiline = true;
            this.txt_OrderRemark2.Name = "txt_OrderRemark2";
            this.txt_OrderRemark2.Size = new System.Drawing.Size(240, 52);
            this.txt_OrderRemark2.TabIndex = 1;
            // 
            // txt_OrderRemark
            // 
            this.txt_OrderRemark.Location = new System.Drawing.Point(99, 11);
            this.txt_OrderRemark.Multiline = true;
            this.txt_OrderRemark.Name = "txt_OrderRemark";
            this.txt_OrderRemark.Size = new System.Drawing.Size(235, 52);
            this.txt_OrderRemark.TabIndex = 1;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(973, 24);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(91, 29);
            this.button10.TabIndex = 0;
            this.button10.Text = "保存";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // EditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1296, 897);
            this.Controls.Add(this.dgvSubOrders);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel4);
            this.Name = "EditOrder";
            this.Text = "订单编辑";
            this.Load += new System.EventHandler(this.EditOrder_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubOrders)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtp_OrderDate;
        private System.Windows.Forms.TextBox txt_orderNumber;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_Order_CName;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_Order_CPhone;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_Order_CAddress;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_WeigthCount;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txt_OrderPriceXCount;
        private System.Windows.Forms.TextBox txt_OrderPriceCount;
        private System.Windows.Forms.TextBox txt_OrderPriceZCount;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.DataGridView dgvSubOrders;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_OrderOtherPrice;
        private System.Windows.Forms.TextBox txt_Order_PriceOK;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_OrderRemark2;
        private System.Windows.Forms.TextBox txt_OrderRemark;
        private System.Windows.Forms.Button button10;
    }
}