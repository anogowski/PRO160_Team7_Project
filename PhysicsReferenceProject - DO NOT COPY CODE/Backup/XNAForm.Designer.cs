namespace XNAForm
{
    partial class XNAForm
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
            this.viewingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // viewingPanel
            // 
            this.viewingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.viewingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewingPanel.Location = new System.Drawing.Point(0, 0);
            this.viewingPanel.Name = "viewingPanel";
            this.viewingPanel.Size = new System.Drawing.Size(518, 377);
            this.viewingPanel.TabIndex = 1;
            this.viewingPanel.BackColorChanged += new System.EventHandler(this.ViewingPanel_BackColor_Changed);
            this.viewingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.On_viewingPanel_Paint);
            this.viewingPanel.Resize += new System.EventHandler(this.On_viewingPanel_Resize);
            // 
            // XNAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 377);
            this.Controls.Add(this.viewingPanel);
            this.DoubleBuffered = true;
            this.Name = "XNAForm";
            this.Text = "XNAForm";
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel viewingPanel;


    }
}

