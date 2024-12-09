namespace T2
{
    partial class MainMenu
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
            label1 = new Label();
            label2 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            buttonFetchData = new Button();
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            pingToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(657, 358);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "Start Date:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(657, 402);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 1;
            label2.Text = "End Date:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(657, 376);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(657, 420);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 3;
            // 
            // buttonFetchData
            // 
            buttonFetchData.Location = new Point(657, 454);
            buttonFetchData.Name = "buttonFetchData";
            buttonFetchData.Size = new Size(200, 23);
            buttonFetchData.TabIndex = 4;
            buttonFetchData.Text = "Fetch Data";
            buttonFetchData.UseVisualStyleBackColor = true;
            buttonFetchData.Click += buttonFetchData_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, pingToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(869, 24);
            menuStrip1.TabIndex = 7;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(38, 20);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // pingToolStripMenuItem
            // 
            pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            pingToolStripMenuItem.Size = new Size(43, 20);
            pingToolStripMenuItem.Text = "Ping";
            pingToolStripMenuItem.Click += pingToolStripMenuItem_Click;
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 489);
            Controls.Add(buttonFetchData);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainMenu";
            Text = "Bitcoin Analyzer";
            Load += MainMenu_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Button buttonFetchData;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem pingToolStripMenuItem;
    }
}