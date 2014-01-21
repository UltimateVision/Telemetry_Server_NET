namespace Telemetry_Server.NET
{
    partial class PluginManager
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
            this.pluginFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // pluginFlowLayoutPanel
            // 
            this.pluginFlowLayoutPanel.AutoScroll = true;
            this.pluginFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.pluginFlowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.pluginFlowLayoutPanel.Name = "pluginFlowLayoutPanel";
            this.pluginFlowLayoutPanel.Size = new System.Drawing.Size(240, 200);
            this.pluginFlowLayoutPanel.TabIndex = 0;
            // 
            // PluginManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 222);
            this.Controls.Add(this.pluginFlowLayoutPanel);
            this.Name = "PluginManager";
            this.Text = "PluginManager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pluginFlowLayoutPanel;
    }
}