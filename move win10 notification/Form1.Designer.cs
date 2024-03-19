namespace move_win10_notification
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			notifyIcon1 = new NotifyIcon(components);
			contextMenuStrip1 = new ContextMenuStrip(components);
			closeToolStripMenuItem = new ToolStripMenuItem();
			startToolStripMenuItem = new ToolStripMenuItem();
			startToggleBtn = new Button();
			statusPanel = new Panel();
			xPosTxtBox = new TextBox();
			yPosTxtBox = new TextBox();
			getLocationBtn = new Button();
			label1 = new Label();
			label2 = new Label();
			testNotificationBtn = new Button();
			checkBox1 = new CheckBox();
			saveConfigBtn = new Button();
			checkBox2 = new CheckBox();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// notifyIcon1
			// 
			notifyIcon1.ContextMenuStrip = contextMenuStrip1;
			notifyIcon1.Text = "notifyIcon1";
			notifyIcon1.Visible = true;
			notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { closeToolStripMenuItem, startToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(104, 48);
			// 
			// closeToolStripMenuItem
			// 
			closeToolStripMenuItem.Name = "closeToolStripMenuItem";
			closeToolStripMenuItem.Size = new Size(103, 22);
			closeToolStripMenuItem.Text = "Close";
			closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
			// 
			// startToolStripMenuItem
			// 
			startToolStripMenuItem.Name = "startToolStripMenuItem";
			startToolStripMenuItem.Size = new Size(103, 22);
			startToolStripMenuItem.Text = "Start";
			startToolStripMenuItem.Click += startToolStripMenuItem_Click;
			// 
			// startToggleBtn
			// 
			startToggleBtn.Location = new Point(115, 180);
			startToggleBtn.Name = "startToggleBtn";
			startToggleBtn.Size = new Size(75, 23);
			startToggleBtn.TabIndex = 1;
			startToggleBtn.Text = "Stop";
			startToggleBtn.UseVisualStyleBackColor = true;
			startToggleBtn.Click += startToggleBtn_Click;
			// 
			// statusPanel
			// 
			statusPanel.BackColor = Color.Lime;
			statusPanel.Location = new Point(196, 181);
			statusPanel.Name = "statusPanel";
			statusPanel.Size = new Size(22, 22);
			statusPanel.TabIndex = 2;
			// 
			// xPosTxtBox
			// 
			xPosTxtBox.Location = new Point(62, 94);
			xPosTxtBox.Name = "xPosTxtBox";
			xPosTxtBox.Size = new Size(100, 23);
			xPosTxtBox.TabIndex = 3;
			xPosTxtBox.Text = "0";
			xPosTxtBox.TextAlign = HorizontalAlignment.Center;
			// 
			// yPosTxtBox
			// 
			yPosTxtBox.Location = new Point(168, 94);
			yPosTxtBox.Name = "yPosTxtBox";
			yPosTxtBox.Size = new Size(100, 23);
			yPosTxtBox.TabIndex = 4;
			yPosTxtBox.Text = "0";
			yPosTxtBox.TextAlign = HorizontalAlignment.Center;
			// 
			// getLocationBtn
			// 
			getLocationBtn.Location = new Point(84, 123);
			getLocationBtn.Name = "getLocationBtn";
			getLocationBtn.Size = new Size(153, 23);
			getLocationBtn.TabIndex = 5;
			getLocationBtn.Text = "Get Top Left Location";
			getLocationBtn.UseVisualStyleBackColor = true;
			getLocationBtn.Click += getLocationBtn_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(107, 76);
			label1.Name = "label1";
			label1.Size = new Size(14, 15);
			label1.TabIndex = 6;
			label1.Text = "X";
			label1.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(214, 76);
			label2.Name = "label2";
			label2.Size = new Size(14, 15);
			label2.TabIndex = 7;
			label2.Text = "Y";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// testNotificationBtn
			// 
			testNotificationBtn.Location = new Point(115, 234);
			testNotificationBtn.Name = "testNotificationBtn";
			testNotificationBtn.Size = new Size(75, 23);
			testNotificationBtn.TabIndex = 8;
			testNotificationBtn.Text = "Preview";
			testNotificationBtn.UseVisualStyleBackColor = true;
			testNotificationBtn.Click += testNotificationBtn_Click;
			// 
			// checkBox1
			// 
			checkBox1.AutoSize = true;
			checkBox1.Location = new Point(71, 16);
			checkBox1.Name = "checkBox1";
			checkBox1.Size = new Size(91, 19);
			checkBox1.TabIndex = 9;
			checkBox1.Text = "Run on Start";
			checkBox1.UseVisualStyleBackColor = true;
			// 
			// saveConfigBtn
			// 
			saveConfigBtn.Location = new Point(168, 12);
			saveConfigBtn.Name = "saveConfigBtn";
			saveConfigBtn.Size = new Size(103, 23);
			saveConfigBtn.TabIndex = 10;
			saveConfigBtn.Text = "Save Config";
			saveConfigBtn.UseVisualStyleBackColor = true;
			saveConfigBtn.Click += saveConfigBtn_Click;
			// 
			// checkBox2
			// 
			checkBox2.AutoSize = true;
			checkBox2.Location = new Point(71, 41);
			checkBox2.Name = "checkBox2";
			checkBox2.Size = new Size(109, 19);
			checkBox2.TabIndex = 11;
			checkBox2.Text = "Start Minimized";
			checkBox2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(322, 312);
			Controls.Add(checkBox2);
			Controls.Add(saveConfigBtn);
			Controls.Add(checkBox1);
			Controls.Add(testNotificationBtn);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(getLocationBtn);
			Controls.Add(yPosTxtBox);
			Controls.Add(xPosTxtBox);
			Controls.Add(statusPanel);
			Controls.Add(startToggleBtn);
			Name = "Form1";
			Text = "Form1";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			Resize += Form1_Resize;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem closeToolStripMenuItem;
		private Button startToggleBtn;
		private Panel statusPanel;
		private TextBox xPosTxtBox;
		private TextBox yPosTxtBox;
		private Button getLocationBtn;
		private Label label1;
		private Label label2;
		private Button testNotificationBtn;
		private CheckBox checkBox1;
		private Button saveConfigBtn;
		private ToolStripMenuItem startToolStripMenuItem;
		private CheckBox checkBox2;
	}
}
