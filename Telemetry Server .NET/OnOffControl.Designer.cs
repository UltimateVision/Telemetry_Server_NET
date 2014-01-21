namespace Telemetry_Server.NET
{
    partial class OnOffControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PluginNameLabel = new System.Windows.Forms.Label();
            this.AuthorNameLabel = new System.Windows.Forms.Label();
            this.OnOffButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PluginNameLabel
            // 
            this.PluginNameLabel.AutoSize = true;
            this.PluginNameLabel.Location = new System.Drawing.Point(7, 6);
            this.PluginNameLabel.Name = "PluginNameLabel";
            this.PluginNameLabel.Size = new System.Drawing.Size(35, 13);
            this.PluginNameLabel.TabIndex = 0;
            this.PluginNameLabel.Text = "label1";
            // 
            // AuthorNameLabel
            // 
            this.AuthorNameLabel.AutoSize = true;
            this.AuthorNameLabel.Location = new System.Drawing.Point(7, 27);
            this.AuthorNameLabel.Name = "AuthorNameLabel";
            this.AuthorNameLabel.Size = new System.Drawing.Size(35, 13);
            this.AuthorNameLabel.TabIndex = 1;
            this.AuthorNameLabel.Text = "label1";
            // 
            // OnOffButton
            // 
            this.OnOffButton.Location = new System.Drawing.Point(171, 6);
            this.OnOffButton.Name = "OnOffButton";
            this.OnOffButton.Size = new System.Drawing.Size(56, 34);
            this.OnOffButton.TabIndex = 2;
            this.OnOffButton.Text = "On";
            this.OnOffButton.UseVisualStyleBackColor = true;
            this.OnOffButton.Click += new System.EventHandler(this.OnOffButton_Click);
            // 
            // OnOffControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OnOffButton);
            this.Controls.Add(this.AuthorNameLabel);
            this.Controls.Add(this.PluginNameLabel);
            this.Name = "OnOffControl";
            this.Size = new System.Drawing.Size(230, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PluginNameLabel;
        private System.Windows.Forms.Label AuthorNameLabel;
        private System.Windows.Forms.Button OnOffButton;
    }
}
