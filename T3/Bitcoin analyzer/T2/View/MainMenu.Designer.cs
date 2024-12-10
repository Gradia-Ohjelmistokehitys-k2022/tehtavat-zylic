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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            label1 = new Label();
            label2 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            buttonFetchData = new Button();
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            pingToolStripMenuItem = new ToolStripMenuItem();
            labelPrice = new Label();
            labelPHighest = new Label();
            labelPLowest = new Label();
            labelVolume = new Label();
            labelVHighest = new Label();
            labelVLowest = new Label();
            labelTrend = new Label();
            labelBearish = new Label();
            labelBullish = new Label();
            labelTM = new Label();
            labelBTS = new Label();
            labelSTB = new Label();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
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
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(12, 38);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(33, 15);
            labelPrice.TabIndex = 8;
            labelPrice.Text = "Price";
            // 
            // labelPHighest
            // 
            labelPHighest.AutoSize = true;
            labelPHighest.Location = new Point(12, 65);
            labelPHighest.Name = "labelPHighest";
            labelPHighest.Size = new Size(51, 15);
            labelPHighest.TabIndex = 9;
            labelPHighest.Text = "Highest:";
            // 
            // labelPLowest
            // 
            labelPLowest.AutoSize = true;
            labelPLowest.Location = new Point(12, 80);
            labelPLowest.Name = "labelPLowest";
            labelPLowest.Size = new Size(47, 15);
            labelPLowest.TabIndex = 10;
            labelPLowest.Text = "Lowest:";
            // 
            // labelVolume
            // 
            labelVolume.AutoSize = true;
            labelVolume.Location = new Point(12, 124);
            labelVolume.Name = "labelVolume";
            labelVolume.Size = new Size(89, 15);
            labelVolume.TabIndex = 11;
            labelVolume.Text = "Trading Volume";
            // 
            // labelVHighest
            // 
            labelVHighest.AutoSize = true;
            labelVHighest.Location = new Point(12, 151);
            labelVHighest.Name = "labelVHighest";
            labelVHighest.Size = new Size(51, 15);
            labelVHighest.TabIndex = 12;
            labelVHighest.Text = "Highest:";
            // 
            // labelVLowest
            // 
            labelVLowest.AutoSize = true;
            labelVLowest.Location = new Point(12, 166);
            labelVLowest.Name = "labelVLowest";
            labelVLowest.Size = new Size(47, 15);
            labelVLowest.TabIndex = 13;
            labelVLowest.Text = "Lowest:";
            // 
            // labelTrend
            // 
            labelTrend.AutoSize = true;
            labelTrend.Location = new Point(337, 124);
            labelTrend.Name = "labelTrend";
            labelTrend.Size = new Size(41, 15);
            labelTrend.TabIndex = 14;
            labelTrend.Text = "Trends";
            // 
            // labelBearish
            // 
            labelBearish.AutoSize = true;
            labelBearish.Location = new Point(337, 151);
            labelBearish.Name = "labelBearish";
            labelBearish.Size = new Size(125, 15);
            labelBearish.TabIndex = 15;
            labelBearish.Text = "Longest Bearish Trend:";
            // 
            // labelBullish
            // 
            labelBullish.AutoSize = true;
            labelBullish.Location = new Point(337, 166);
            labelBullish.Name = "labelBullish";
            labelBullish.Size = new Size(122, 15);
            labelBullish.TabIndex = 16;
            labelBullish.Text = "Longest Bullish Trend:";
            // 
            // labelTM
            // 
            labelTM.AutoSize = true;
            labelTM.Location = new Point(337, 38);
            labelTM.Name = "labelTM";
            labelTM.Size = new Size(82, 15);
            labelTM.TabIndex = 17;
            labelTM.Text = "Time Machine";
            // 
            // labelBTS
            // 
            labelBTS.AutoSize = true;
            labelBTS.Location = new Point(337, 65);
            labelBTS.Name = "labelBTS";
            labelBTS.Size = new Size(154, 15);
            labelBTS.TabIndex = 18;
            labelBTS.Text = "Buy on ____ first, Sell on ____";
            // 
            // labelSTB
            // 
            labelSTB.AutoSize = true;
            labelSTB.Location = new Point(337, 80);
            labelSTB.Name = "labelSTB";
            labelSTB.Size = new Size(154, 15);
            labelSTB.TabIndex = 19;
            labelSTB.Text = "Sell on ____ first, Buy on ____";
            // 
            // chart1
            // 
            chartArea1.AxisX.LabelStyle.Format = "dd/mm/yyyy";
            chartArea1.AxisX.LabelStyle.Interval = 1D;
            chartArea1.AxisX.LabelStyle.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Days;
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisY.Title = "Price (€)";
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chart1.Legends.Add(legend1);
            chart1.Location = new Point(12, 195);
            chart1.Name = "chart1";
            chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(639, 282);
            chart1.TabIndex = 20;
            chart1.Text = "chart1";
            // 
            // MainMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(869, 489);
            Controls.Add(chart1);
            Controls.Add(labelSTB);
            Controls.Add(labelBTS);
            Controls.Add(labelTM);
            Controls.Add(labelBullish);
            Controls.Add(labelBearish);
            Controls.Add(labelTrend);
            Controls.Add(labelVLowest);
            Controls.Add(labelVHighest);
            Controls.Add(labelVolume);
            Controls.Add(labelPLowest);
            Controls.Add(labelPHighest);
            Controls.Add(labelPrice);
            Controls.Add(buttonFetchData);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainMenu";
            Text = "Bitcoin Analyzer";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
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
        private Label labelPrice;
        private Label labelPHighest;
        private Label labelPLowest;
        private Label labelVolume;
        private Label labelVHighest;
        private Label labelVLowest;
        private Label labelTrend;
        private Label labelBearish;
        private Label labelBullish;
        private Label labelTM;
        private Label labelBTS;
        private Label labelSTB;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}