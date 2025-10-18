namespace _0x0_V2
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnInput = new System.Windows.Forms.Button();
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.fileVersion = new System.Windows.Forms.Label();
            this.lastModified = new System.Windows.Forms.Label();
            this.IsDigitallySigned = new System.Windows.Forms.Label();
            this.creationDate = new System.Windows.Forms.Label();
            this.fileSize = new System.Windows.Forms.Label();
            this.IsNative = new System.Windows.Forms.Label();
            this.filetype = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.botChatID = new System.Windows.Forms.TextBox();
            this.botToken = new System.Windows.Forms.TextBox();
            this.discordWebhook = new System.Windows.Forms.TextBox();
            this.blockIPList = new System.Windows.Forms.TextBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numDelayAmount = new System.Windows.Forms.NumericUpDown();
            this.delayedExecution = new System.Windows.Forms.CheckBox();
            this.cryptoOnly = new System.Windows.Forms.CheckBox();
            this.installation = new System.Windows.Forms.CheckBox();
            this.antiCIS = new System.Windows.Forms.CheckBox();
            this.antiVirustotal = new System.Windows.Forms.CheckBox();
            this.antiSandbox = new System.Windows.Forms.CheckBox();
            this.antiVM = new System.Windows.Forms.CheckBox();
            this.antiDebug = new System.Windows.Forms.CheckBox();
            this.groupChangelog = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.groupMoreOptions = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.stringEncryption = new System.Windows.Forms.CheckBox();
            this.classObfuscation = new System.Windows.Forms.CheckBox();
            this.packer = new System.Windows.Forms.CheckBox();
            this.controlFlow = new System.Windows.Forms.CheckBox();
            this.groupOutputLog = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.copyErrorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupInfo.SuspendLayout();
            this.groupOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelayAmount)).BeginInit();
            this.groupChangelog.SuspendLayout();
            this.groupMoreOptions.SuspendLayout();
            this.groupOutputLog.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Path:";
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(70, 6);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(535, 20);
            this.txtInput.TabIndex = 1;
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(609, 6);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(74, 20);
            this.btnInput.TabIndex = 2;
            this.btnInput.Text = "...";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.fileVersion);
            this.groupInfo.Controls.Add(this.lastModified);
            this.groupInfo.Controls.Add(this.IsDigitallySigned);
            this.groupInfo.Controls.Add(this.creationDate);
            this.groupInfo.Controls.Add(this.fileSize);
            this.groupInfo.Controls.Add(this.IsNative);
            this.groupInfo.Controls.Add(this.filetype);
            this.groupInfo.Controls.Add(this.label8);
            this.groupInfo.Controls.Add(this.label7);
            this.groupInfo.Controls.Add(this.label6);
            this.groupInfo.Controls.Add(this.label5);
            this.groupInfo.Controls.Add(this.label4);
            this.groupInfo.Controls.Add(this.label3);
            this.groupInfo.Controls.Add(this.label2);
            this.groupInfo.Location = new System.Drawing.Point(12, 32);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(172, 183);
            this.groupInfo.TabIndex = 3;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "File Information";
            // 
            // fileVersion
            // 
            this.fileVersion.AutoSize = true;
            this.fileVersion.Location = new System.Drawing.Point(53, 152);
            this.fileVersion.Name = "fileVersion";
            this.fileVersion.Size = new System.Drawing.Size(19, 13);
            this.fileVersion.TabIndex = 14;
            this.fileVersion.Text = "....";
            // 
            // lastModified
            // 
            this.lastModified.AutoSize = true;
            this.lastModified.Location = new System.Drawing.Point(81, 130);
            this.lastModified.Name = "lastModified";
            this.lastModified.Size = new System.Drawing.Size(19, 13);
            this.lastModified.TabIndex = 13;
            this.lastModified.Text = "....";
            // 
            // IsDigitallySigned
            // 
            this.IsDigitallySigned.AutoSize = true;
            this.IsDigitallySigned.Location = new System.Drawing.Point(96, 107);
            this.IsDigitallySigned.Name = "IsDigitallySigned";
            this.IsDigitallySigned.Size = new System.Drawing.Size(19, 13);
            this.IsDigitallySigned.TabIndex = 12;
            this.IsDigitallySigned.Text = "....";
            // 
            // creationDate
            // 
            this.creationDate.AutoSize = true;
            this.creationDate.Location = new System.Drawing.Point(84, 84);
            this.creationDate.Name = "creationDate";
            this.creationDate.Size = new System.Drawing.Size(19, 13);
            this.creationDate.TabIndex = 11;
            this.creationDate.Text = "....";
            // 
            // fileSize
            // 
            this.fileSize.AutoSize = true;
            this.fileSize.Location = new System.Drawing.Point(82, 62);
            this.fileSize.Name = "fileSize";
            this.fileSize.Size = new System.Drawing.Size(19, 13);
            this.fileSize.TabIndex = 10;
            this.fileSize.Text = "....";
            // 
            // IsNative
            // 
            this.IsNative.AutoSize = true;
            this.IsNative.Location = new System.Drawing.Point(49, 41);
            this.IsNative.Name = "IsNative";
            this.IsNative.Size = new System.Drawing.Size(19, 13);
            this.IsNative.TabIndex = 9;
            this.IsNative.Text = "....";
            // 
            // filetype
            // 
            this.filetype.AutoSize = true;
            this.filetype.Location = new System.Drawing.Point(62, 21);
            this.filetype.Name = "filetype";
            this.filetype.Size = new System.Drawing.Size(19, 13);
            this.filetype.TabIndex = 8;
            this.filetype.Text = "....";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Version:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Last Modified:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Digital Signature:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Creation Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "File Size (KB):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Native:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Type:";
            // 
            // groupOptions
            // 
            this.groupOptions.Controls.Add(this.label10);
            this.groupOptions.Controls.Add(this.label9);
            this.groupOptions.Controls.Add(this.botChatID);
            this.groupOptions.Controls.Add(this.botToken);
            this.groupOptions.Controls.Add(this.discordWebhook);
            this.groupOptions.Controls.Add(this.blockIPList);
            this.groupOptions.Controls.Add(this.checkBox3);
            this.groupOptions.Controls.Add(this.checkBox2);
            this.groupOptions.Controls.Add(this.checkBox1);
            this.groupOptions.Controls.Add(this.numDelayAmount);
            this.groupOptions.Controls.Add(this.delayedExecution);
            this.groupOptions.Controls.Add(this.cryptoOnly);
            this.groupOptions.Controls.Add(this.installation);
            this.groupOptions.Controls.Add(this.antiCIS);
            this.groupOptions.Controls.Add(this.antiVirustotal);
            this.groupOptions.Controls.Add(this.antiSandbox);
            this.groupOptions.Controls.Add(this.antiVM);
            this.groupOptions.Controls.Add(this.antiDebug);
            this.groupOptions.Location = new System.Drawing.Point(190, 32);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(493, 183);
            this.groupOptions.TabIndex = 4;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Output Options";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(153, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Chat ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(153, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Bot Token:";
            // 
            // botChatID
            // 
            this.botChatID.BackColor = System.Drawing.SystemColors.Control;
            this.botChatID.Enabled = false;
            this.botChatID.Location = new System.Drawing.Point(205, 129);
            this.botChatID.Name = "botChatID";
            this.botChatID.Size = new System.Drawing.Size(269, 20);
            this.botChatID.TabIndex = 20;
            // 
            // botToken
            // 
            this.botToken.BackColor = System.Drawing.SystemColors.Control;
            this.botToken.Enabled = false;
            this.botToken.Location = new System.Drawing.Point(218, 107);
            this.botToken.Name = "botToken";
            this.botToken.Size = new System.Drawing.Size(256, 20);
            this.botToken.TabIndex = 19;
            // 
            // discordWebhook
            // 
            this.discordWebhook.BackColor = System.Drawing.SystemColors.Control;
            this.discordWebhook.Enabled = false;
            this.discordWebhook.Location = new System.Drawing.Point(320, 68);
            this.discordWebhook.Name = "discordWebhook";
            this.discordWebhook.Size = new System.Drawing.Size(154, 20);
            this.discordWebhook.TabIndex = 18;
            // 
            // blockIPList
            // 
            this.blockIPList.BackColor = System.Drawing.SystemColors.Control;
            this.blockIPList.Enabled = false;
            this.blockIPList.Location = new System.Drawing.Point(218, 43);
            this.blockIPList.Name = "blockIPList";
            this.blockIPList.Size = new System.Drawing.Size(256, 20);
            this.blockIPList.TabIndex = 17;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(151, 89);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(126, 17);
            this.checkBox3.TabIndex = 16;
            this.checkBox3.Text = "Telegram Notification";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(151, 70);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(168, 17);
            this.checkBox2.TabIndex = 15;
            this.checkBox2.Text = "Discord Webhook Notification";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(151, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(66, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Block IP";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numDelayAmount
            // 
            this.numDelayAmount.BackColor = System.Drawing.SystemColors.Control;
            this.numDelayAmount.Enabled = false;
            this.numDelayAmount.Location = new System.Drawing.Point(274, 19);
            this.numDelayAmount.Name = "numDelayAmount";
            this.numDelayAmount.Size = new System.Drawing.Size(200, 20);
            this.numDelayAmount.TabIndex = 13;
            // 
            // delayedExecution
            // 
            this.delayedExecution.AutoSize = true;
            this.delayedExecution.Location = new System.Drawing.Point(151, 22);
            this.delayedExecution.Name = "delayedExecution";
            this.delayedExecution.Size = new System.Drawing.Size(125, 17);
            this.delayedExecution.TabIndex = 10;
            this.delayedExecution.Text = "Delay Execution (ms)";
            this.delayedExecution.UseVisualStyleBackColor = true;
            // 
            // cryptoOnly
            // 
            this.cryptoOnly.AutoSize = true;
            this.cryptoOnly.Location = new System.Drawing.Point(14, 147);
            this.cryptoOnly.Name = "cryptoOnly";
            this.cryptoOnly.Size = new System.Drawing.Size(103, 17);
            this.cryptoOnly.TabIndex = 9;
            this.cryptoOnly.Text = "Smart Execution";
            this.cryptoOnly.UseVisualStyleBackColor = true;
            // 
            // installation
            // 
            this.installation.AutoSize = true;
            this.installation.Location = new System.Drawing.Point(14, 127);
            this.installation.Name = "installation";
            this.installation.Size = new System.Drawing.Size(76, 17);
            this.installation.TabIndex = 8;
            this.installation.Text = "Installation";
            this.installation.UseVisualStyleBackColor = true;
            // 
            // antiCIS
            // 
            this.antiCIS.AutoSize = true;
            this.antiCIS.Location = new System.Drawing.Point(14, 107);
            this.antiCIS.Name = "antiCIS";
            this.antiCIS.Size = new System.Drawing.Size(95, 17);
            this.antiCIS.TabIndex = 7;
            this.antiCIS.Text = "Anti-CIS/Asian";
            this.antiCIS.UseVisualStyleBackColor = true;
            // 
            // antiVirustotal
            // 
            this.antiVirustotal.AutoSize = true;
            this.antiVirustotal.Location = new System.Drawing.Point(14, 86);
            this.antiVirustotal.Name = "antiVirustotal";
            this.antiVirustotal.Size = new System.Drawing.Size(90, 17);
            this.antiVirustotal.TabIndex = 6;
            this.antiVirustotal.Text = "Anti-Virustotal";
            this.antiVirustotal.UseVisualStyleBackColor = true;
            // 
            // antiSandbox
            // 
            this.antiSandbox.AutoSize = true;
            this.antiSandbox.Location = new System.Drawing.Point(14, 65);
            this.antiSandbox.Name = "antiSandbox";
            this.antiSandbox.Size = new System.Drawing.Size(97, 17);
            this.antiSandbox.TabIndex = 4;
            this.antiSandbox.Text = "Anti-Sandboxie";
            this.antiSandbox.UseVisualStyleBackColor = true;
            // 
            // antiVM
            // 
            this.antiVM.AutoSize = true;
            this.antiVM.Location = new System.Drawing.Point(14, 44);
            this.antiVM.Name = "antiVM";
            this.antiVM.Size = new System.Drawing.Size(63, 17);
            this.antiVM.TabIndex = 1;
            this.antiVM.Text = "Anti-VM";
            this.antiVM.UseVisualStyleBackColor = true;
            // 
            // antiDebug
            // 
            this.antiDebug.AutoSize = true;
            this.antiDebug.Location = new System.Drawing.Point(14, 24);
            this.antiDebug.Name = "antiDebug";
            this.antiDebug.Size = new System.Drawing.Size(79, 17);
            this.antiDebug.TabIndex = 0;
            this.antiDebug.Text = "Anti-Debug";
            this.antiDebug.UseVisualStyleBackColor = true;
            // 
            // groupChangelog
            // 
            this.groupChangelog.Controls.Add(this.label12);
            this.groupChangelog.Controls.Add(this.label11);
            this.groupChangelog.Location = new System.Drawing.Point(12, 221);
            this.groupChangelog.Name = "groupChangelog";
            this.groupChangelog.Size = new System.Drawing.Size(187, 383);
            this.groupChangelog.TabIndex = 5;
            this.groupChangelog.TabStop = false;
            this.groupChangelog.Text = "Changelog";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 260);
            this.label12.TabIndex = 1;
            this.label12.Text = resources.GetString("label12.Text");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 78);
            this.label11.TabIndex = 0;
            this.label11.Text = "Pretty major updates since\r\nv1, which was released almost\r\n6 months ago now! So i" +
    " decided\r\nto get my shit together and refud\r\nand redo this amazing open source\r\n" +
    "crypter lmao. Enjoy";
            // 
            // groupMoreOptions
            // 
            this.groupMoreOptions.Controls.Add(this.label13);
            this.groupMoreOptions.Controls.Add(this.stringEncryption);
            this.groupMoreOptions.Controls.Add(this.classObfuscation);
            this.groupMoreOptions.Controls.Add(this.packer);
            this.groupMoreOptions.Controls.Add(this.controlFlow);
            this.groupMoreOptions.Location = new System.Drawing.Point(207, 221);
            this.groupMoreOptions.Name = "groupMoreOptions";
            this.groupMoreOptions.Size = new System.Drawing.Size(476, 86);
            this.groupMoreOptions.TabIndex = 6;
            this.groupMoreOptions.TabStop = false;
            this.groupMoreOptions.Text = "Obfuscation Options";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(226, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(239, 52);
            this.label13.TabIndex = 8;
            this.label13.Text = "Disclaimer: These are all in BETA, please keep in\r\nmind string encryption especia" +
    "lly tends to break\r\nTelegram/Webhook Notifications so be careful\r\nhave fun -_-";
            // 
            // stringEncryption
            // 
            this.stringEncryption.AutoSize = true;
            this.stringEncryption.Location = new System.Drawing.Point(108, 18);
            this.stringEncryption.Name = "stringEncryption";
            this.stringEncryption.Size = new System.Drawing.Size(106, 17);
            this.stringEncryption.TabIndex = 3;
            this.stringEncryption.Text = "String Encryption";
            this.stringEncryption.UseVisualStyleBackColor = true;
            // 
            // classObfuscation
            // 
            this.classObfuscation.AutoSize = true;
            this.classObfuscation.Location = new System.Drawing.Point(12, 61);
            this.classObfuscation.Name = "classObfuscation";
            this.classObfuscation.Size = new System.Drawing.Size(111, 17);
            this.classObfuscation.TabIndex = 2;
            this.classObfuscation.Text = "Class Obfuscation";
            this.classObfuscation.UseVisualStyleBackColor = true;
            // 
            // packer
            // 
            this.packer.AutoSize = true;
            this.packer.Location = new System.Drawing.Point(12, 39);
            this.packer.Name = "packer";
            this.packer.Size = new System.Drawing.Size(60, 17);
            this.packer.TabIndex = 1;
            this.packer.Text = "Packer";
            this.packer.UseVisualStyleBackColor = true;
            // 
            // controlFlow
            // 
            this.controlFlow.AutoSize = true;
            this.controlFlow.Location = new System.Drawing.Point(12, 18);
            this.controlFlow.Name = "controlFlow";
            this.controlFlow.Size = new System.Drawing.Size(84, 17);
            this.controlFlow.TabIndex = 0;
            this.controlFlow.Text = "Control Flow";
            this.controlFlow.UseVisualStyleBackColor = true;
            // 
            // groupOutputLog
            // 
            this.groupOutputLog.Controls.Add(this.listBox1);
            this.groupOutputLog.Location = new System.Drawing.Point(207, 313);
            this.groupOutputLog.Name = "groupOutputLog";
            this.groupOutputLog.Size = new System.Drawing.Size(476, 248);
            this.groupOutputLog.TabIndex = 7;
            this.groupOutputLog.TabStop = false;
            this.groupOutputLog.Text = "Output Debug Log";
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(9, 22);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(458, 212);
            this.listBox1.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearLogToolStripMenuItem,
            this.copyErrorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
            // 
            // clearLogToolStripMenuItem
            // 
            this.clearLogToolStripMenuItem.Name = "clearLogToolStripMenuItem";
            this.clearLogToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.clearLogToolStripMenuItem.Text = "Clear Log";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(207, 567);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(476, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Build";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // copyErrorToolStripMenuItem
            // 
            this.copyErrorToolStripMenuItem.Name = "copyErrorToolStripMenuItem";
            this.copyErrorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.copyErrorToolStripMenuItem.Text = "Copy Error";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 613);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupOutputLog);
            this.Controls.Add(this.groupMoreOptions);
            this.Controls.Add(this.groupChangelog);
            this.Controls.Add(this.groupOptions);
            this.Controls.Add(this.groupInfo);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Name = "FrmMain";
            this.Text = "0x0 V2";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDelayAmount)).EndInit();
            this.groupChangelog.ResumeLayout(false);
            this.groupChangelog.PerformLayout();
            this.groupMoreOptions.ResumeLayout(false);
            this.groupMoreOptions.PerformLayout();
            this.groupOutputLog.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label filetype;
        private System.Windows.Forms.Label IsNative;
        private System.Windows.Forms.Label creationDate;
        private System.Windows.Forms.Label fileSize;
        private System.Windows.Forms.Label IsDigitallySigned;
        private System.Windows.Forms.Label lastModified;
        private System.Windows.Forms.Label fileVersion;
        private System.Windows.Forms.GroupBox groupOptions;
        private System.Windows.Forms.CheckBox antiDebug;
        private System.Windows.Forms.CheckBox antiVM;
        private System.Windows.Forms.CheckBox antiSandbox;
        private System.Windows.Forms.CheckBox antiVirustotal;
        private System.Windows.Forms.CheckBox antiCIS;
        private System.Windows.Forms.CheckBox installation;
        private System.Windows.Forms.CheckBox cryptoOnly;
        private System.Windows.Forms.CheckBox delayedExecution;
        private System.Windows.Forms.NumericUpDown numDelayAmount;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.TextBox blockIPList;
        private System.Windows.Forms.TextBox discordWebhook;
        private System.Windows.Forms.TextBox botChatID;
        private System.Windows.Forms.TextBox botToken;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupChangelog;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupMoreOptions;
        private System.Windows.Forms.CheckBox controlFlow;
        private System.Windows.Forms.CheckBox packer;
        private System.Windows.Forms.CheckBox classObfuscation;
        private System.Windows.Forms.CheckBox stringEncryption;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupOutputLog;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyErrorToolStripMenuItem;
    }
}