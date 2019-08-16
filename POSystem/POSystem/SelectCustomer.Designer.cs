namespace POSystem
{
    partial class SelectCustomer
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
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_SelCPhone = new System.Windows.Forms.TextBox();
            this.txt_SelCName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(0, 61);
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.RowTemplate.Height = 23;
            this.dgvCustomers.Size = new System.Drawing.Size(668, 290);
            this.dgvCustomers.TabIndex = 6;
            this.dgvCustomers.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCustomers_MouseDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.txt_SelCPhone);
            this.groupBox3.Controls.Add(this.txt_SelCName);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(668, 61);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "筛选";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(280, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 12);
            this.label12.TabIndex = 0;
            this.label12.Text = "联系方式:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "名称:";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(552, 22);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "查询";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_SelCPhone
            // 
            this.txt_SelCPhone.Location = new System.Drawing.Point(356, 22);
            this.txt_SelCPhone.Name = "txt_SelCPhone";
            this.txt_SelCPhone.Size = new System.Drawing.Size(176, 21);
            this.txt_SelCPhone.TabIndex = 2;
            this.txt_SelCPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SelCustomer_KeyDown);
            // 
            // txt_SelCName
            // 
            this.txt_SelCName.Location = new System.Drawing.Point(71, 22);
            this.txt_SelCName.Name = "txt_SelCName";
            this.txt_SelCName.Size = new System.Drawing.Size(176, 21);
            this.txt_SelCName.TabIndex = 2;
            this.txt_SelCName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SelCustomer_KeyDown);
            // 
            // SelectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 351);
            this.Controls.Add(this.dgvCustomers);
            this.Controls.Add(this.groupBox3);
            this.Name = "SelectCustomer";
            this.Text = "SelectCustomer";
            this.Load += new System.EventHandler(this.SelectCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txt_SelCPhone;
        private System.Windows.Forms.TextBox txt_SelCName;
    }
}