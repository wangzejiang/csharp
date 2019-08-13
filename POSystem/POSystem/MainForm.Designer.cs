namespace POSystem
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mianMenu = new System.Windows.Forms.MenuStrip();
            this.订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新订单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.订单查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增商品ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.商品查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增客户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.tabPage商品列表 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Gb_ProductWhere = new System.Windows.Forms.GroupBox();
            this.商品名称 = new System.Windows.Forms.Label();
            this.查询 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage添加商品 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.pictureBox_pImage = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_pRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_pNumber = new System.Windows.Forms.TextBox();
            this.textBox_pWeight = new System.Windows.Forms.TextBox();
            this.textBox_pSuppliter = new System.Windows.Forms.TextBox();
            this.textBox_pPrice = new System.Windows.Forms.TextBox();
            this.textBox_pName = new System.Windows.Forms.TextBox();
            this.tabPage添加客户 = new System.Windows.Forms.TabPage();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox_cAddress = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_cPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_cName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage客户列表 = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tabPage订单列表 = new System.Windows.Forms.TabPage();
            this.tabPage新订单 = new System.Windows.Forms.TabPage();
            this.tabPage欢迎页 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mianMenu.SuspendLayout();
            this.MainTabControl.SuspendLayout();
            this.tabPage商品列表.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.Gb_ProductWhere.SuspendLayout();
            this.tabPage添加商品.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage添加客户.SuspendLayout();
            this.tabPage客户列表.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.tabPage欢迎页.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mianMenu
            // 
            this.mianMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.mianMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.订单ToolStripMenuItem,
            this.商品ToolStripMenuItem,
            this.客户ToolStripMenuItem});
            this.mianMenu.Location = new System.Drawing.Point(0, 0);
            this.mianMenu.Name = "mianMenu";
            this.mianMenu.Size = new System.Drawing.Size(1167, 28);
            this.mianMenu.TabIndex = 1;
            this.mianMenu.Text = "menu";
            // 
            // 订单ToolStripMenuItem
            // 
            this.订单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新订单ToolStripMenuItem,
            this.订单查询ToolStripMenuItem});
            this.订单ToolStripMenuItem.Name = "订单ToolStripMenuItem";
            this.订单ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.订单ToolStripMenuItem.Text = "订单";
            // 
            // 新订单ToolStripMenuItem
            // 
            this.新订单ToolStripMenuItem.Name = "新订单ToolStripMenuItem";
            this.新订单ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.新订单ToolStripMenuItem.Text = "新订单";
            this.新订单ToolStripMenuItem.Click += new System.EventHandler(this.新订单ToolStripMenuItem_Click);
            // 
            // 订单查询ToolStripMenuItem
            // 
            this.订单查询ToolStripMenuItem.Name = "订单查询ToolStripMenuItem";
            this.订单查询ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.订单查询ToolStripMenuItem.Text = "订单查询";
            this.订单查询ToolStripMenuItem.Click += new System.EventHandler(this.订单查询ToolStripMenuItem_Click);
            // 
            // 商品ToolStripMenuItem
            // 
            this.商品ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增商品ToolStripMenuItem,
            this.商品查询ToolStripMenuItem});
            this.商品ToolStripMenuItem.Name = "商品ToolStripMenuItem";
            this.商品ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.商品ToolStripMenuItem.Text = "商品";
            // 
            // 新增商品ToolStripMenuItem
            // 
            this.新增商品ToolStripMenuItem.Name = "新增商品ToolStripMenuItem";
            this.新增商品ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.新增商品ToolStripMenuItem.Text = "新增商品";
            this.新增商品ToolStripMenuItem.Click += new System.EventHandler(this.新增商品ToolStripMenuItem_Click);
            // 
            // 商品查询ToolStripMenuItem
            // 
            this.商品查询ToolStripMenuItem.Name = "商品查询ToolStripMenuItem";
            this.商品查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.商品查询ToolStripMenuItem.Text = "商品查询";
            this.商品查询ToolStripMenuItem.Click += new System.EventHandler(this.商品查询ToolStripMenuItem_Click);
            // 
            // 客户ToolStripMenuItem
            // 
            this.客户ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增客户ToolStripMenuItem,
            this.客户查询ToolStripMenuItem});
            this.客户ToolStripMenuItem.Name = "客户ToolStripMenuItem";
            this.客户ToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.客户ToolStripMenuItem.Text = "客户";
            // 
            // 新增客户ToolStripMenuItem
            // 
            this.新增客户ToolStripMenuItem.Name = "新增客户ToolStripMenuItem";
            this.新增客户ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.新增客户ToolStripMenuItem.Text = "新增客户";
            this.新增客户ToolStripMenuItem.Click += new System.EventHandler(this.新增客户ToolStripMenuItem_Click);
            // 
            // 客户查询ToolStripMenuItem
            // 
            this.客户查询ToolStripMenuItem.Name = "客户查询ToolStripMenuItem";
            this.客户查询ToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.客户查询ToolStripMenuItem.Text = "客户查询";
            this.客户查询ToolStripMenuItem.Click += new System.EventHandler(this.客户查询ToolStripMenuItem_Click);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.tabPage商品列表);
            this.MainTabControl.Controls.Add(this.tabPage添加商品);
            this.MainTabControl.Controls.Add(this.tabPage添加客户);
            this.MainTabControl.Controls.Add(this.tabPage客户列表);
            this.MainTabControl.Controls.Add(this.tabPage订单列表);
            this.MainTabControl.Controls.Add(this.tabPage新订单);
            this.MainTabControl.Controls.Add(this.tabPage欢迎页);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTabControl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainTabControl.Location = new System.Drawing.Point(0, 28);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(1167, 585);
            this.MainTabControl.TabIndex = 2;
            this.MainTabControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.MainTabControl_MouseDoubleClick);
            // 
            // tabPage商品列表
            // 
            this.tabPage商品列表.Controls.Add(this.dgvProducts);
            this.tabPage商品列表.Controls.Add(this.panel1);
            this.tabPage商品列表.Controls.Add(this.Gb_ProductWhere);
            this.tabPage商品列表.Location = new System.Drawing.Point(4, 24);
            this.tabPage商品列表.Name = "tabPage商品列表";
            this.tabPage商品列表.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage商品列表.Size = new System.Drawing.Size(1159, 557);
            this.tabPage商品列表.TabIndex = 0;
            this.tabPage商品列表.Text = "商品列表";
            this.tabPage商品列表.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 519);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1153, 35);
            this.panel1.TabIndex = 3;
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(3, 81);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 100;
            this.dgvProducts.Size = new System.Drawing.Size(1153, 438);
            this.dgvProducts.TabIndex = 2;
            // 
            // Gb_ProductWhere
            // 
            this.Gb_ProductWhere.Controls.Add(this.商品名称);
            this.Gb_ProductWhere.Controls.Add(this.查询);
            this.Gb_ProductWhere.Controls.Add(this.textBox1);
            this.Gb_ProductWhere.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gb_ProductWhere.Location = new System.Drawing.Point(3, 3);
            this.Gb_ProductWhere.Name = "Gb_ProductWhere";
            this.Gb_ProductWhere.Size = new System.Drawing.Size(1153, 78);
            this.Gb_ProductWhere.TabIndex = 1;
            this.Gb_ProductWhere.TabStop = false;
            this.Gb_ProductWhere.Text = "筛选";
            // 
            // 商品名称
            // 
            this.商品名称.AutoSize = true;
            this.商品名称.Location = new System.Drawing.Point(15, 28);
            this.商品名称.Name = "商品名称";
            this.商品名称.Size = new System.Drawing.Size(70, 14);
            this.商品名称.TabIndex = 0;
            this.商品名称.Text = "商品名称:";
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(1054, 28);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(75, 23);
            this.查询.TabIndex = 1;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.查询_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(91, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 23);
            this.textBox1.TabIndex = 2;
            // 
            // tabPage添加商品
            // 
            this.tabPage添加商品.Controls.Add(this.groupBox2);
            this.tabPage添加商品.Controls.Add(this.button2);
            this.tabPage添加商品.Controls.Add(this.button1);
            this.tabPage添加商品.Controls.Add(this.groupBox1);
            this.tabPage添加商品.Location = new System.Drawing.Point(4, 24);
            this.tabPage添加商品.Name = "tabPage添加商品";
            this.tabPage添加商品.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage添加商品.Size = new System.Drawing.Size(1159, 557);
            this.tabPage添加商品.TabIndex = 1;
            this.tabPage添加商品.Text = "添加商品";
            this.tabPage添加商品.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.pictureBox_pImage);
            this.groupBox2.Location = new System.Drawing.Point(580, 43);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(452, 419);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "产品图片";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(192, 360);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "上传";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox_pImage
            // 
            this.pictureBox_pImage.Location = new System.Drawing.Point(48, 37);
            this.pictureBox_pImage.Name = "pictureBox_pImage";
            this.pictureBox_pImage.Size = new System.Drawing.Size(365, 317);
            this.pictureBox_pImage.TabIndex = 4;
            this.pictureBox_pImage.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(580, 488);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(132, 40);
            this.button2.TabIndex = 15;
            this.button2.Text = "清空";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_pRemark);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_pNumber);
            this.groupBox1.Controls.Add(this.textBox_pWeight);
            this.groupBox1.Controls.Add(this.textBox_pSuppliter);
            this.groupBox1.Controls.Add(this.textBox_pPrice);
            this.groupBox1.Controls.Add(this.textBox_pName);
            this.groupBox1.Location = new System.Drawing.Point(74, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 419);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "产品信息";
            // 
            // textBox_pRemark
            // 
            this.textBox_pRemark.Location = new System.Drawing.Point(98, 267);
            this.textBox_pRemark.Multiline = true;
            this.textBox_pRemark.Name = "textBox_pRemark";
            this.textBox_pRemark.Size = new System.Drawing.Size(298, 116);
            this.textBox_pRemark.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 270);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 14);
            this.label10.TabIndex = 19;
            this.label10.Text = "备注：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 19;
            this.label5.Text = "编码：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 19;
            this.label4.Text = "厂家：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 20;
            this.label3.Text = "重量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 21;
            this.label2.Text = "名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "价格:";
            // 
            // textBox_pNumber
            // 
            this.textBox_pNumber.Location = new System.Drawing.Point(98, 223);
            this.textBox_pNumber.Name = "textBox_pNumber";
            this.textBox_pNumber.Size = new System.Drawing.Size(298, 23);
            this.textBox_pNumber.TabIndex = 18;
            // 
            // textBox_pWeight
            // 
            this.textBox_pWeight.Location = new System.Drawing.Point(98, 132);
            this.textBox_pWeight.Name = "textBox_pWeight";
            this.textBox_pWeight.Size = new System.Drawing.Size(298, 23);
            this.textBox_pWeight.TabIndex = 17;
            // 
            // textBox_pSuppliter
            // 
            this.textBox_pSuppliter.Location = new System.Drawing.Point(98, 176);
            this.textBox_pSuppliter.Name = "textBox_pSuppliter";
            this.textBox_pSuppliter.Size = new System.Drawing.Size(298, 23);
            this.textBox_pSuppliter.TabIndex = 18;
            // 
            // textBox_pPrice
            // 
            this.textBox_pPrice.Location = new System.Drawing.Point(98, 84);
            this.textBox_pPrice.Name = "textBox_pPrice";
            this.textBox_pPrice.Size = new System.Drawing.Size(298, 23);
            this.textBox_pPrice.TabIndex = 16;
            // 
            // textBox_pName
            // 
            this.textBox_pName.Location = new System.Drawing.Point(98, 37);
            this.textBox_pName.Name = "textBox_pName";
            this.textBox_pName.Size = new System.Drawing.Size(298, 23);
            this.textBox_pName.TabIndex = 15;
            // 
            // tabPage添加客户
            // 
            this.tabPage添加客户.Controls.Add(this.button5);
            this.tabPage添加客户.Controls.Add(this.textBox_cAddress);
            this.tabPage添加客户.Controls.Add(this.label9);
            this.tabPage添加客户.Controls.Add(this.textBox_cPhone);
            this.tabPage添加客户.Controls.Add(this.label8);
            this.tabPage添加客户.Controls.Add(this.textBox_cName);
            this.tabPage添加客户.Controls.Add(this.label7);
            this.tabPage添加客户.Location = new System.Drawing.Point(4, 24);
            this.tabPage添加客户.Name = "tabPage添加客户";
            this.tabPage添加客户.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage添加客户.Size = new System.Drawing.Size(1159, 557);
            this.tabPage添加客户.TabIndex = 2;
            this.tabPage添加客户.Text = "添加客户";
            this.tabPage添加客户.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(497, 274);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(104, 38);
            this.button5.TabIndex = 2;
            this.button5.Text = "保存";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox_cAddress
            // 
            this.textBox_cAddress.Location = new System.Drawing.Point(497, 229);
            this.textBox_cAddress.Name = "textBox_cAddress";
            this.textBox_cAddress.Size = new System.Drawing.Size(220, 23);
            this.textBox_cAddress.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(414, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 14);
            this.label9.TabIndex = 0;
            this.label9.Text = "客户地址：";
            // 
            // textBox_cPhone
            // 
            this.textBox_cPhone.Location = new System.Drawing.Point(497, 189);
            this.textBox_cPhone.Name = "textBox_cPhone";
            this.textBox_cPhone.Size = new System.Drawing.Size(220, 23);
            this.textBox_cPhone.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(414, 194);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 14);
            this.label8.TabIndex = 0;
            this.label8.Text = "客户电话：";
            // 
            // textBox_cName
            // 
            this.textBox_cName.Location = new System.Drawing.Point(497, 151);
            this.textBox_cName.Name = "textBox_cName";
            this.textBox_cName.Size = new System.Drawing.Size(220, 23);
            this.textBox_cName.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(414, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 0;
            this.label7.Text = "客户名称：";
            // 
            // tabPage客户列表
            // 
            this.tabPage客户列表.Controls.Add(this.dgvCustomers);
            this.tabPage客户列表.Controls.Add(this.groupBox3);
            this.tabPage客户列表.Location = new System.Drawing.Point(4, 24);
            this.tabPage客户列表.Name = "tabPage客户列表";
            this.tabPage客户列表.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage客户列表.Size = new System.Drawing.Size(1159, 557);
            this.tabPage客户列表.TabIndex = 3;
            this.tabPage客户列表.Text = "客户列表";
            this.tabPage客户列表.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToOrderColumns = true;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 81);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.RowTemplate.Height = 23;
            this.dgvCustomers.Size = new System.Drawing.Size(1153, 473);
            this.dgvCustomers.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1153, 78);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "筛选";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 14);
            this.label6.TabIndex = 0;
            this.label6.Text = "名称:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1054, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(96, 28);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(176, 23);
            this.textBox2.TabIndex = 2;
            // 
            // tabPage订单列表
            // 
            this.tabPage订单列表.Location = new System.Drawing.Point(4, 24);
            this.tabPage订单列表.Name = "tabPage订单列表";
            this.tabPage订单列表.Size = new System.Drawing.Size(1159, 557);
            this.tabPage订单列表.TabIndex = 4;
            this.tabPage订单列表.Text = "订单列表";
            this.tabPage订单列表.UseVisualStyleBackColor = true;
            // 
            // tabPage新订单
            // 
            this.tabPage新订单.Location = new System.Drawing.Point(4, 24);
            this.tabPage新订单.Name = "tabPage新订单";
            this.tabPage新订单.Size = new System.Drawing.Size(1159, 557);
            this.tabPage新订单.TabIndex = 5;
            this.tabPage新订单.Text = "新订单";
            this.tabPage新订单.UseVisualStyleBackColor = true;
            // 
            // tabPage欢迎页
            // 
            this.tabPage欢迎页.Controls.Add(this.pictureBox1);
            this.tabPage欢迎页.Location = new System.Drawing.Point(4, 24);
            this.tabPage欢迎页.Name = "tabPage欢迎页";
            this.tabPage欢迎页.Size = new System.Drawing.Size(1159, 557);
            this.tabPage欢迎页.TabIndex = 6;
            this.tabPage欢迎页.Text = "欢迎页";
            this.tabPage欢迎页.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::POSystem.Properties.Resources._1_joshrobinson_queencharlottetrack_marlboroughsounds2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1159, 557);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 613);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.mianMenu);
            this.Name = "MainForm";
            this.Text = "订单管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.PoSystem_Load);
            this.mianMenu.ResumeLayout(false);
            this.mianMenu.PerformLayout();
            this.MainTabControl.ResumeLayout(false);
            this.tabPage商品列表.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.Gb_ProductWhere.ResumeLayout(false);
            this.Gb_ProductWhere.PerformLayout();
            this.tabPage添加商品.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage添加客户.ResumeLayout(false);
            this.tabPage添加客户.PerformLayout();
            this.tabPage客户列表.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage欢迎页.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip mianMenu;
        private System.Windows.Forms.ToolStripMenuItem 订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新订单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 订单查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增商品ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 商品查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增客户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 客户查询ToolStripMenuItem;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage tabPage商品列表;
        private System.Windows.Forms.TabPage tabPage添加商品;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage添加客户;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.Label 商品名称;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factoryNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nunberDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabPage客户列表;
        private System.Windows.Forms.TabPage tabPage订单列表;
        private System.Windows.Forms.TabPage tabPage新订单;
        private System.Windows.Forms.TabPage tabPage欢迎页;
        private System.Windows.Forms.GroupBox Gb_ProductWhere;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox_pImage;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_pNumber;
        private System.Windows.Forms.TextBox textBox_pWeight;
        private System.Windows.Forms.TextBox textBox_pSuppliter;
        private System.Windows.Forms.TextBox textBox_pPrice;
        private System.Windows.Forms.TextBox textBox_pName;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox_cAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_cPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_cName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_pRemark;
        private System.Windows.Forms.Label label10;
    }
}

