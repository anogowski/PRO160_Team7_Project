namespace XNAForm
{
    partial class PlayingForm
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.objectInfo_richTextbox = new System.Windows.Forms.RichTextBox();
            this.polyAdd_radioButton = new System.Windows.Forms.RadioButton();
            this.tool_delete_button = new System.Windows.Forms.Button();
            this.rectAdd_radioButton = new System.Windows.Forms.RadioButton();
            this.circleAdd_radioButton = new System.Windows.Forms.RadioButton();
            this.colorFill_link = new System.Windows.Forms.LinkLabel();
            this.colorFill_label = new System.Windows.Forms.Label();
            this.startFrozen_Checkbox = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.clearAll_button = new System.Windows.Forms.Button();
            this.clearPoly_button = new System.Windows.Forms.Button();
            this.clearCircles_button = new System.Windows.Forms.Button();
            this.clearRects_button = new System.Windows.Forms.Button();
            this.gravity_label = new System.Windows.Forms.Label();
            this.tool_Frozen_Checkbox = new System.Windows.Forms.CheckBox();
            this.tool_Bounce_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.gravity_trackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.tool_Friction_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tool_Mass_numUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.play_stop_button = new System.Windows.Forms.Button();
            this.fillColorChoser_colorDialog = new System.Windows.Forms.ColorDialog();
            this.viewingPanel.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tool_Bounce_numUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravity_trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tool_Friction_numUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tool_Mass_numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // viewingPanel
            // 
            this.viewingPanel.BackColor = System.Drawing.Color.SteelBlue;
            this.viewingPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.viewingPanel.Controls.Add(this.controlPanel);
            this.viewingPanel.Size = new System.Drawing.Size(600, 402);
            this.viewingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.viewingPanel_MouseMove);
            this.viewingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.viewingPanel_MouseDown);
            this.viewingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.viewingPanel_MouseUp);
            // 
            // controlPanel
            // 
            this.controlPanel.BackColor = System.Drawing.Color.Ivory;
            this.controlPanel.Controls.Add(this.tabControl1);
            this.controlPanel.Controls.Add(this.play_stop_button);
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(586, 122);
            this.controlPanel.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 116);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.objectInfo_richTextbox);
            this.tabPage1.Controls.Add(this.polyAdd_radioButton);
            this.tabPage1.Controls.Add(this.tool_delete_button);
            this.tabPage1.Controls.Add(this.rectAdd_radioButton);
            this.tabPage1.Controls.Add(this.circleAdd_radioButton);
            this.tabPage1.Controls.Add(this.colorFill_link);
            this.tabPage1.Controls.Add(this.colorFill_label);
            this.tabPage1.Controls.Add(this.startFrozen_Checkbox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 90);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Objects";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // objectInfo_richTextbox
            // 
            this.objectInfo_richTextbox.Location = new System.Drawing.Point(197, 5);
            this.objectInfo_richTextbox.Name = "objectInfo_richTextbox";
            this.objectInfo_richTextbox.ReadOnly = true;
            this.objectInfo_richTextbox.Size = new System.Drawing.Size(222, 43);
            this.objectInfo_richTextbox.TabIndex = 15;
            this.objectInfo_richTextbox.Text = "";
            // 
            // polyAdd_radioButton
            // 
            this.polyAdd_radioButton.AutoSize = true;
            this.polyAdd_radioButton.Location = new System.Drawing.Point(6, 52);
            this.polyAdd_radioButton.Name = "polyAdd_radioButton";
            this.polyAdd_radioButton.Size = new System.Drawing.Size(85, 17);
            this.polyAdd_radioButton.TabIndex = 14;
            this.polyAdd_radioButton.Text = "Add Polygon";
            this.polyAdd_radioButton.UseVisualStyleBackColor = true;
            // 
            // tool_delete_button
            // 
            this.tool_delete_button.Location = new System.Drawing.Point(108, 25);
            this.tool_delete_button.Name = "tool_delete_button";
            this.tool_delete_button.Size = new System.Drawing.Size(75, 23);
            this.tool_delete_button.TabIndex = 13;
            this.tool_delete_button.Text = "Delete";
            this.tool_delete_button.UseVisualStyleBackColor = true;
            this.tool_delete_button.Click += new System.EventHandler(this.tool_delete_button_Click);
            // 
            // rectAdd_radioButton
            // 
            this.rectAdd_radioButton.AutoSize = true;
            this.rectAdd_radioButton.Checked = true;
            this.rectAdd_radioButton.Location = new System.Drawing.Point(6, 29);
            this.rectAdd_radioButton.Name = "rectAdd_radioButton";
            this.rectAdd_radioButton.Size = new System.Drawing.Size(96, 17);
            this.rectAdd_radioButton.TabIndex = 12;
            this.rectAdd_radioButton.TabStop = true;
            this.rectAdd_radioButton.Text = "Add Rectangle";
            this.rectAdd_radioButton.UseVisualStyleBackColor = true;
            // 
            // circleAdd_radioButton
            // 
            this.circleAdd_radioButton.AutoSize = true;
            this.circleAdd_radioButton.Location = new System.Drawing.Point(6, 6);
            this.circleAdd_radioButton.Name = "circleAdd_radioButton";
            this.circleAdd_radioButton.Size = new System.Drawing.Size(73, 17);
            this.circleAdd_radioButton.TabIndex = 11;
            this.circleAdd_radioButton.Text = "Add Circle";
            this.circleAdd_radioButton.UseVisualStyleBackColor = true;
            // 
            // colorFill_link
            // 
            this.colorFill_link.AutoSize = true;
            this.colorFill_link.Location = new System.Drawing.Point(105, 64);
            this.colorFill_link.Name = "colorFill_link";
            this.colorFill_link.Size = new System.Drawing.Size(61, 13);
            this.colorFill_link.TabIndex = 10;
            this.colorFill_link.TabStop = true;
            this.colorFill_link.Text = "Color [Blue]";
            this.colorFill_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.colorFill_link_LinkClicked);
            // 
            // colorFill_label
            // 
            this.colorFill_label.AutoSize = true;
            this.colorFill_label.Location = new System.Drawing.Point(105, 51);
            this.colorFill_label.Name = "colorFill_label";
            this.colorFill_label.Size = new System.Drawing.Size(49, 13);
            this.colorFill_label.TabIndex = 9;
            this.colorFill_label.Text = "Fill Color:";
            // 
            // startFrozen_Checkbox
            // 
            this.startFrozen_Checkbox.AutoSize = true;
            this.startFrozen_Checkbox.Location = new System.Drawing.Point(108, 7);
            this.startFrozen_Checkbox.Name = "startFrozen_Checkbox";
            this.startFrozen_Checkbox.Size = new System.Drawing.Size(83, 17);
            this.startFrozen_Checkbox.TabIndex = 8;
            this.startFrozen_Checkbox.Text = "Start Frozen";
            this.startFrozen_Checkbox.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.clearAll_button);
            this.tabPage2.Controls.Add(this.clearPoly_button);
            this.tabPage2.Controls.Add(this.clearCircles_button);
            this.tabPage2.Controls.Add(this.clearRects_button);
            this.tabPage2.Controls.Add(this.gravity_label);
            this.tabPage2.Controls.Add(this.tool_Frozen_Checkbox);
            this.tabPage2.Controls.Add(this.tool_Bounce_numUpDown);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.gravity_trackBar);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tool_Friction_numUpDown);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tool_Mass_numUpDown);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 90);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tools";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Clear:";
            // 
            // clearAll_button
            // 
            this.clearAll_button.Location = new System.Drawing.Point(329, 67);
            this.clearAll_button.Name = "clearAll_button";
            this.clearAll_button.Size = new System.Drawing.Size(79, 23);
            this.clearAll_button.TabIndex = 15;
            this.clearAll_button.Text = "Clear All";
            this.clearAll_button.UseVisualStyleBackColor = true;
            this.clearAll_button.Click += new System.EventHandler(this.clearAll_button_Click);
            // 
            // clearPoly_button
            // 
            this.clearPoly_button.Location = new System.Drawing.Point(386, 43);
            this.clearPoly_button.Name = "clearPoly_button";
            this.clearPoly_button.Size = new System.Drawing.Size(22, 23);
            this.clearPoly_button.TabIndex = 18;
            this.clearPoly_button.Text = "P";
            this.clearPoly_button.UseVisualStyleBackColor = true;
            this.clearPoly_button.Click += new System.EventHandler(this.clearPoly_button_Click);
            // 
            // clearCircles_button
            // 
            this.clearCircles_button.Location = new System.Drawing.Point(358, 43);
            this.clearCircles_button.Name = "clearCircles_button";
            this.clearCircles_button.Size = new System.Drawing.Size(22, 23);
            this.clearCircles_button.TabIndex = 17;
            this.clearCircles_button.Text = "C";
            this.clearCircles_button.UseVisualStyleBackColor = true;
            this.clearCircles_button.Click += new System.EventHandler(this.clearCircles_button_Click);
            // 
            // clearRects_button
            // 
            this.clearRects_button.Location = new System.Drawing.Point(329, 43);
            this.clearRects_button.Name = "clearRects_button";
            this.clearRects_button.Size = new System.Drawing.Size(23, 23);
            this.clearRects_button.TabIndex = 16;
            this.clearRects_button.Text = "R";
            this.clearRects_button.UseVisualStyleBackColor = true;
            this.clearRects_button.Click += new System.EventHandler(this.clearRects_Click);
            // 
            // gravity_label
            // 
            this.gravity_label.AutoSize = true;
            this.gravity_label.Location = new System.Drawing.Point(9, 57);
            this.gravity_label.Name = "gravity_label";
            this.gravity_label.Size = new System.Drawing.Size(13, 13);
            this.gravity_label.TabIndex = 8;
            this.gravity_label.Text = "0";
            // 
            // tool_Frozen_Checkbox
            // 
            this.tool_Frozen_Checkbox.AutoSize = true;
            this.tool_Frozen_Checkbox.Location = new System.Drawing.Point(3, 6);
            this.tool_Frozen_Checkbox.Name = "tool_Frozen_Checkbox";
            this.tool_Frozen_Checkbox.Size = new System.Drawing.Size(58, 17);
            this.tool_Frozen_Checkbox.TabIndex = 10;
            this.tool_Frozen_Checkbox.Text = "Frozen";
            this.tool_Frozen_Checkbox.UseVisualStyleBackColor = true;
            this.tool_Frozen_Checkbox.CheckedChanged += new System.EventHandler(this.tool_Frozen_Checkbox_CheckedChanged);
            // 
            // tool_Bounce_numUpDown
            // 
            this.tool_Bounce_numUpDown.DecimalPlaces = 2;
            this.tool_Bounce_numUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.tool_Bounce_numUpDown.Location = new System.Drawing.Point(330, 5);
            this.tool_Bounce_numUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.tool_Bounce_numUpDown.Name = "tool_Bounce_numUpDown";
            this.tool_Bounce_numUpDown.Size = new System.Drawing.Size(49, 20);
            this.tool_Bounce_numUpDown.TabIndex = 9;
            this.tool_Bounce_numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tool_Bounce_numUpDown.ValueChanged += new System.EventHandler(this.tool_Bounce_numUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Gravity:";
            // 
            // gravity_trackBar
            // 
            this.gravity_trackBar.LargeChange = 1;
            this.gravity_trackBar.Location = new System.Drawing.Point(55, 38);
            this.gravity_trackBar.Maximum = 100;
            this.gravity_trackBar.Minimum = -100;
            this.gravity_trackBar.Name = "gravity_trackBar";
            this.gravity_trackBar.Size = new System.Drawing.Size(219, 45);
            this.gravity_trackBar.TabIndex = 6;
            this.gravity_trackBar.TickFrequency = 10;
            this.gravity_trackBar.Value = 100;
            this.gravity_trackBar.Scroll += new System.EventHandler(this.gravity_trackBar_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(280, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bounce:";
            // 
            // tool_Friction_numUpDown
            // 
            this.tool_Friction_numUpDown.DecimalPlaces = 2;
            this.tool_Friction_numUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.tool_Friction_numUpDown.Location = new System.Drawing.Point(225, 5);
            this.tool_Friction_numUpDown.Name = "tool_Friction_numUpDown";
            this.tool_Friction_numUpDown.Size = new System.Drawing.Size(49, 20);
            this.tool_Friction_numUpDown.TabIndex = 7;
            this.tool_Friction_numUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.tool_Friction_numUpDown.ValueChanged += new System.EventHandler(this.tool_Friction_numUpDown_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Friction:";
            // 
            // tool_Mass_numUpDown
            // 
            this.tool_Mass_numUpDown.DecimalPlaces = 2;
            this.tool_Mass_numUpDown.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.tool_Mass_numUpDown.Location = new System.Drawing.Point(108, 5);
            this.tool_Mass_numUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tool_Mass_numUpDown.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.tool_Mass_numUpDown.Name = "tool_Mass_numUpDown";
            this.tool_Mass_numUpDown.Size = new System.Drawing.Size(61, 20);
            this.tool_Mass_numUpDown.TabIndex = 5;
            this.tool_Mass_numUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.tool_Mass_numUpDown.ValueChanged += new System.EventHandler(this.tool_Mass_numUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mass:";
            // 
            // play_stop_button
            // 
            this.play_stop_button.BackColor = System.Drawing.Color.Red;
            this.play_stop_button.Location = new System.Drawing.Point(438, 25);
            this.play_stop_button.Name = "play_stop_button";
            this.play_stop_button.Size = new System.Drawing.Size(140, 95);
            this.play_stop_button.TabIndex = 13;
            this.play_stop_button.Text = "Stop";
            this.play_stop_button.UseVisualStyleBackColor = false;
            this.play_stop_button.Click += new System.EventHandler(this.play_stop_button_Click);
            // 
            // fillColorChoser_colorDialog
            // 
            this.fillColorChoser_colorDialog.Color = System.Drawing.Color.Blue;
            // 
            // PlayingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 402);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "PlayingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Physics Playground";
            this.Load += new System.EventHandler(this.PlayingForm_Load);
            this.viewingPanel.ResumeLayout(false);
            this.controlPanel.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tool_Bounce_numUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gravity_trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tool_Friction_numUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tool_Mass_numUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.CheckBox startFrozen_Checkbox;
        private System.Windows.Forms.Label colorFill_label;
        private System.Windows.Forms.LinkLabel colorFill_link;
        private System.Windows.Forms.ColorDialog fillColorChoser_colorDialog;
        private System.Windows.Forms.Button play_stop_button;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label gravity_label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar gravity_trackBar;
        private System.Windows.Forms.NumericUpDown tool_Mass_numUpDown;
        private System.Windows.Forms.RadioButton rectAdd_radioButton;
        private System.Windows.Forms.RadioButton circleAdd_radioButton;
        private System.Windows.Forms.NumericUpDown tool_Friction_numUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox tool_Frozen_Checkbox;
        private System.Windows.Forms.NumericUpDown tool_Bounce_numUpDown;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button tool_delete_button;
        private System.Windows.Forms.RadioButton polyAdd_radioButton;
        private System.Windows.Forms.RichTextBox objectInfo_richTextbox;
        private System.Windows.Forms.Button clearAll_button;
        private System.Windows.Forms.Button clearRects_button;
        private System.Windows.Forms.Button clearPoly_button;
        private System.Windows.Forms.Button clearCircles_button;
        private System.Windows.Forms.Label label5;

    }
}