namespace Telemetry_Server.NET
{
    partial class ServerSetup
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.changeLocationButton = new System.Windows.Forms.Button();
            this.dataSharePathLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.urlFormatTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.getRadioButton = new System.Windows.Forms.RadioButton();
            this.postRadioButton = new System.Windows.Forms.RadioButton();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sendIntTextBox = new System.Windows.Forms.TextBox();
            this.readIntTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.logCheckBox = new System.Windows.Forms.CheckBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.changeLocationButton);
            this.groupBox1.Controls.Add(this.dataSharePathLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 77);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "dataShare.data location:";
            // 
            // changeLocationButton
            // 
            this.changeLocationButton.Location = new System.Drawing.Point(274, 48);
            this.changeLocationButton.Name = "changeLocationButton";
            this.changeLocationButton.Size = new System.Drawing.Size(75, 23);
            this.changeLocationButton.TabIndex = 1;
            this.changeLocationButton.Text = "Change...";
            this.changeLocationButton.UseVisualStyleBackColor = true;
            this.changeLocationButton.Click += new System.EventHandler(this.changeLocationButton_Click);
            // 
            // dataSharePathLabel
            // 
            this.dataSharePathLabel.AutoSize = true;
            this.dataSharePathLabel.Location = new System.Drawing.Point(6, 17);
            this.dataSharePathLabel.Name = "dataSharePathLabel";
            this.dataSharePathLabel.Size = new System.Drawing.Size(35, 13);
            this.dataSharePathLabel.TabIndex = 2;
            this.dataSharePathLabel.Text = "label2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.urlFormatTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.getRadioButton);
            this.groupBox2.Controls.Add(this.postRadioButton);
            this.groupBox2.Controls.Add(this.addressTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(355, 102);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "WWW transmission";
            // 
            // urlFormatTextBox
            // 
            this.urlFormatTextBox.Location = new System.Drawing.Point(80, 46);
            this.urlFormatTextBox.Name = "urlFormatTextBox";
            this.urlFormatTextBox.Size = new System.Drawing.Size(269, 20);
            this.urlFormatTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "URL format:";
            // 
            // getRadioButton
            // 
            this.getRadioButton.AutoSize = true;
            this.getRadioButton.Location = new System.Drawing.Point(102, 79);
            this.getRadioButton.Name = "getRadioButton";
            this.getRadioButton.Size = new System.Drawing.Size(69, 17);
            this.getRadioButton.TabIndex = 3;
            this.getRadioButton.TabStop = true;
            this.getRadioButton.Text = "Use GET";
            this.getRadioButton.UseVisualStyleBackColor = true;
            // 
            // postRadioButton
            // 
            this.postRadioButton.AutoSize = true;
            this.postRadioButton.Location = new System.Drawing.Point(10, 79);
            this.postRadioButton.Name = "postRadioButton";
            this.postRadioButton.Size = new System.Drawing.Size(76, 17);
            this.postRadioButton.TabIndex = 2;
            this.postRadioButton.TabStop = true;
            this.postRadioButton.Text = "Use POST";
            this.postRadioButton.UseVisualStyleBackColor = true;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(80, 17);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(269, 20);
            this.addressTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sendIntTextBox);
            this.groupBox3.Controls.Add(this.readIntTextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.logCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(13, 205);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(272, 91);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other";
            // 
            // sendIntTextBox
            // 
            this.sendIntTextBox.Location = new System.Drawing.Point(103, 36);
            this.sendIntTextBox.Name = "sendIntTextBox";
            this.sendIntTextBox.Size = new System.Drawing.Size(163, 20);
            this.sendIntTextBox.TabIndex = 4;
            // 
            // readIntTextBox
            // 
            this.readIntTextBox.Location = new System.Drawing.Point(103, 13);
            this.readIntTextBox.Name = "readIntTextBox";
            this.readIntTextBox.Size = new System.Drawing.Size(163, 20);
            this.readIntTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Send interval (ms)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Read interval (ms)";
            // 
            // logCheckBox
            // 
            this.logCheckBox.AutoSize = true;
            this.logCheckBox.Location = new System.Drawing.Point(9, 60);
            this.logCheckBox.Name = "logCheckBox";
            this.logCheckBox.Size = new System.Drawing.Size(68, 17);
            this.logCheckBox.TabIndex = 0;
            this.logCheckBox.Text = "Log data";
            this.logCheckBox.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(291, 272);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(291, 244);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 7;
            this.saveSettingsButton.Text = "Save";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // ServerSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 308);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServerSetup";
            this.Text = "Server configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button changeLocationButton;
        private System.Windows.Forms.Label dataSharePathLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox urlFormatTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton getRadioButton;
        private System.Windows.Forms.RadioButton postRadioButton;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox sendIntTextBox;
        private System.Windows.Forms.TextBox readIntTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox logCheckBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}