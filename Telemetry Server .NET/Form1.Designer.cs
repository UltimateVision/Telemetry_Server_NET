namespace Telemetry_Server.NET
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.websiteTransferButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.clientCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webStatusLabel = new System.Windows.Forms.Label();
            this.readDataButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.toolStripShowSetup = new System.Windows.Forms.ToolStripButton();
            this.toolStripTestChannel = new System.Windows.Forms.ToolStripButton();
            this.toolStripStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 127);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(449, 121);
            this.listBox1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Start";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Peek";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripShowSetup,
            this.toolStripTestChannel,
            this.toolStripStatistics,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(473, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 258);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(473, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // websiteTransferButton
            // 
            this.websiteTransferButton.Location = new System.Drawing.Point(6, 19);
            this.websiteTransferButton.Name = "websiteTransferButton";
            this.websiteTransferButton.Size = new System.Drawing.Size(75, 23);
            this.websiteTransferButton.TabIndex = 7;
            this.websiteTransferButton.Text = "Start";
            this.websiteTransferButton.UseVisualStyleBackColor = true;
            this.websiteTransferButton.Click += new System.EventHandler(this.websiteTransferButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ipLabel);
            this.groupBox1.Controls.Add(this.clientCountLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 93);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "TCP/IP Server";
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Location = new System.Drawing.Point(7, 70);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(61, 13);
            this.ipLabel.TabIndex = 5;
            this.ipLabel.Text = "IP Address:";
            // 
            // clientCountLabel
            // 
            this.clientCountLabel.AutoSize = true;
            this.clientCountLabel.Location = new System.Drawing.Point(46, 49);
            this.clientCountLabel.Name = "clientCountLabel";
            this.clientCountLabel.Size = new System.Drawing.Size(35, 13);
            this.clientCountLabel.TabIndex = 4;
            this.clientCountLabel.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Clients:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webStatusLabel);
            this.groupBox2.Controls.Add(this.websiteTransferButton);
            this.groupBox2.Location = new System.Drawing.Point(205, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 93);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WWW transfer";
            // 
            // webStatusLabel
            // 
            this.webStatusLabel.AutoSize = true;
            this.webStatusLabel.Location = new System.Drawing.Point(6, 49);
            this.webStatusLabel.Name = "webStatusLabel";
            this.webStatusLabel.Size = new System.Drawing.Size(43, 13);
            this.webStatusLabel.TabIndex = 8;
            this.webStatusLabel.Text = "Status: ";
            // 
            // readDataButton
            // 
            this.readDataButton.Location = new System.Drawing.Point(5, 18);
            this.readDataButton.Name = "readDataButton";
            this.readDataButton.Size = new System.Drawing.Size(63, 23);
            this.readDataButton.TabIndex = 10;
            this.readDataButton.Text = "Read";
            this.readDataButton.UseVisualStyleBackColor = true;
            this.readDataButton.Click += new System.EventHandler(this.readDataButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.readDataButton);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(387, 29);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(74, 92);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Data";
            // 
            // toolStripShowSetup
            // 
            this.toolStripShowSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripShowSetup.Image = global::Telemetry_Server.NET.Properties.Resources.cog_icon_24;
            this.toolStripShowSetup.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripShowSetup.Name = "toolStripShowSetup";
            this.toolStripShowSetup.Size = new System.Drawing.Size(23, 22);
            this.toolStripShowSetup.Text = "Server Setup";
            this.toolStripShowSetup.Click += new System.EventHandler(this.toolStripShowSetup_Click);
            // 
            // toolStripTestChannel
            // 
            this.toolStripTestChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripTestChannel.Image = global::Telemetry_Server.NET.Properties.Resources.checkbox_checked_icon_24;
            this.toolStripTestChannel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripTestChannel.Name = "toolStripTestChannel";
            this.toolStripTestChannel.Size = new System.Drawing.Size(23, 22);
            this.toolStripTestChannel.Text = "Test channels";
            this.toolStripTestChannel.Click += new System.EventHandler(this.toolStripTestChannel_Click);
            // 
            // toolStripStatistics
            // 
            this.toolStripStatistics.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripStatistics.Image = global::Telemetry_Server.NET.Properties.Resources.chart_line_icon_24;
            this.toolStripStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripStatistics.Name = "toolStripStatistics";
            this.toolStripStatistics.Size = new System.Drawing.Size(23, 22);
            this.toolStripStatistics.Text = "Statistics";
            this.toolStripStatistics.Click += new System.EventHandler(this.toolStripStatistics_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::Telemetry_Server.NET.Properties.Resources.info_icon_24;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 280);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ETS 2 Telemetry Server .NET";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripShowSetup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button websiteTransferButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label clientCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripButton toolStripTestChannel;
        private System.Windows.Forms.ToolStripButton toolStripStatistics;
        private System.Windows.Forms.Label webStatusLabel;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Button readDataButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

