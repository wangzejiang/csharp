namespace mc
{
    partial class main
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnUnInstall = new System.Windows.Forms.Button();
            this.btnInstallHook = new System.Windows.Forms.Button();
            this.lbMouseState = new System.Windows.Forms.Label();
            this.lbKeyState = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(266, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnUnInstall
            // 
            this.btnUnInstall.Location = new System.Drawing.Point(59, 254);
            this.btnUnInstall.Name = "btnUnInstall";
            this.btnUnInstall.Size = new System.Drawing.Size(156, 23);
            this.btnUnInstall.TabIndex = 1;
            this.btnUnInstall.Text = "btnUnInstall";
            this.btnUnInstall.UseVisualStyleBackColor = true;
            this.btnUnInstall.Click += new System.EventHandler(this.btnUnInstall_Click);
            // 
            // btnInstallHook
            // 
            this.btnInstallHook.Location = new System.Drawing.Point(284, 254);
            this.btnInstallHook.Name = "btnInstallHook";
            this.btnInstallHook.Size = new System.Drawing.Size(155, 23);
            this.btnInstallHook.TabIndex = 2;
            this.btnInstallHook.Text = "btnInstallHook";
            this.btnInstallHook.UseVisualStyleBackColor = true;
            this.btnInstallHook.Click += new System.EventHandler(this.btnInstallHook_Click);
            // 
            // lbMouseState
            // 
            this.lbMouseState.AutoSize = true;
            this.lbMouseState.Location = new System.Drawing.Point(95, 174);
            this.lbMouseState.Name = "lbMouseState";
            this.lbMouseState.Size = new System.Drawing.Size(77, 12);
            this.lbMouseState.TabIndex = 3;
            this.lbMouseState.Text = "lbMouseState";
            // 
            // lbKeyState
            // 
            this.lbKeyState.AutoSize = true;
            this.lbKeyState.Location = new System.Drawing.Point(298, 174);
            this.lbKeyState.Name = "lbKeyState";
            this.lbKeyState.Size = new System.Drawing.Size(65, 12);
            this.lbKeyState.TabIndex = 4;
            this.lbKeyState.Text = "lbKeyState";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "label1";
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 377);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbKeyState);
            this.Controls.Add(this.lbMouseState);
            this.Controls.Add(this.btnInstallHook);
            this.Controls.Add(this.btnUnInstall);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "main";
            this.Text = "main";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.Load += new System.EventHandler(this.main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnUnInstall;
        private System.Windows.Forms.Button btnInstallHook;
        private System.Windows.Forms.Label lbMouseState;
        private System.Windows.Forms.Label lbKeyState;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
}