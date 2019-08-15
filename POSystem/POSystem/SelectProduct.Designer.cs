namespace POSystem
{
    partial class SelectProduct
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
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Gb_ProductWhere = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.商品名称 = new System.Windows.Forms.Label();
            this.查询 = new System.Windows.Forms.Button();
            this.txt_SelPNumber = new System.Windows.Forms.TextBox();
            this.txt_SelPSuppliter = new System.Windows.Forms.TextBox();
            this.txt_SelPName = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            this.Gb_ProductWhere.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvProducts
            // 
            this.dgvProducts.AllowUserToAddRows = false;
            this.dgvProducts.AllowUserToDeleteRows = false;
            this.dgvProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProducts.Location = new System.Drawing.Point(0, 94);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.ReadOnly = true;
            this.dgvProducts.RowTemplate.Height = 100;
            this.dgvProducts.Size = new System.Drawing.Size(941, 407);
            this.dgvProducts.TabIndex = 4;
            this.dgvProducts.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvProducts_MouseDoubleClick);
            // 
            // Gb_ProductWhere
            // 
            this.Gb_ProductWhere.Controls.Add(this.label14);
            this.Gb_ProductWhere.Controls.Add(this.label13);
            this.Gb_ProductWhere.Controls.Add(this.商品名称);
            this.Gb_ProductWhere.Controls.Add(this.查询);
            this.Gb_ProductWhere.Controls.Add(this.txt_SelPNumber);
            this.Gb_ProductWhere.Controls.Add(this.txt_SelPSuppliter);
            this.Gb_ProductWhere.Controls.Add(this.txt_SelPName);
            this.Gb_ProductWhere.Dock = System.Windows.Forms.DockStyle.Top;
            this.Gb_ProductWhere.Location = new System.Drawing.Point(0, 0);
            this.Gb_ProductWhere.Name = "Gb_ProductWhere";
            this.Gb_ProductWhere.Size = new System.Drawing.Size(941, 49);
            this.Gb_ProductWhere.TabIndex = 3;
            this.Gb_ProductWhere.TabStop = false;
            this.Gb_ProductWhere.Text = "筛选";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(570, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 12);
            this.label14.TabIndex = 0;
            this.label14.Text = "商品编号:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(293, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "供应商:";
            // 
            // 商品名称
            // 
            this.商品名称.AutoSize = true;
            this.商品名称.Location = new System.Drawing.Point(16, 19);
            this.商品名称.Name = "商品名称";
            this.商品名称.Size = new System.Drawing.Size(59, 12);
            this.商品名称.TabIndex = 0;
            this.商品名称.Text = "商品名称:";
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(851, 16);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(75, 23);
            this.查询.TabIndex = 1;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.查询_Click);
            // 
            // txt_SelPNumber
            // 
            this.txt_SelPNumber.Location = new System.Drawing.Point(646, 16);
            this.txt_SelPNumber.Name = "txt_SelPNumber";
            this.txt_SelPNumber.Size = new System.Drawing.Size(176, 21);
            this.txt_SelPNumber.TabIndex = 2;
            // 
            // txt_SelPSuppliter
            // 
            this.txt_SelPSuppliter.Location = new System.Drawing.Point(369, 16);
            this.txt_SelPSuppliter.Name = "txt_SelPSuppliter";
            this.txt_SelPSuppliter.Size = new System.Drawing.Size(176, 21);
            this.txt_SelPSuppliter.TabIndex = 2;
            // 
            // txt_SelPName
            // 
            this.txt_SelPName.Location = new System.Drawing.Point(92, 16);
            this.txt_SelPName.Name = "txt_SelPName";
            this.txt_SelPName.Size = new System.Drawing.Size(176, 21);
            this.txt_SelPName.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(371, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 21);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(293, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品数量:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(941, 45);
            this.panel1.TabIndex = 5;
            // 
            // SelectProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 501);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Gb_ProductWhere);
            this.Name = "SelectProduct";
            this.Text = "SelectProduct";
            this.Load += new System.EventHandler(this.SelectProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            this.Gb_ProductWhere.ResumeLayout(false);
            this.Gb_ProductWhere.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.GroupBox Gb_ProductWhere;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label 商品名称;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.TextBox txt_SelPNumber;
        private System.Windows.Forms.TextBox txt_SelPSuppliter;
        private System.Windows.Forms.TextBox txt_SelPName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
    }
}