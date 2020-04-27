namespace ShortestPath
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSigStart = new System.Windows.Forms.ToolStripButton();
            this.tsbMulStart = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.lstQueries = new System.Windows.Forms.ListView();
            this.Start = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.End = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstThread = new System.Windows.Forms.ListView();
            this.Threads = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstResult = new System.Windows.Forms.ListView();
            this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Path = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsbSetting = new System.Windows.Forms.ToolStripButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lbNumThread = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbBufferSize = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSigStart,
            this.tsbMulStart,
            this.tsbSetting});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(711, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSigStart
            // 
            this.tsbSigStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSigStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbSigStart.Image")));
            this.tsbSigStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSigStart.Name = "tsbSigStart";
            this.tsbSigStart.Size = new System.Drawing.Size(107, 24);
            this.tsbSigStart.Text = "单线程启动(&S)";
            this.tsbSigStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbMulStart
            // 
            this.tsbMulStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbMulStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbMulStart.Image")));
            this.tsbMulStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMulStart.Name = "tsbMulStart";
            this.tsbMulStart.Size = new System.Drawing.Size(113, 28);
            this.tsbMulStart.Text = "多线程启动(&M)";
            this.tsbMulStart.Click += new System.EventHandler(this.tsbMulStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(423, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "最短路径运行时间:";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(564, 0);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(31, 15);
            this.lbTime.TabIndex = 5;
            this.lbTime.Text = "0ms";
            // 
            // lstQueries
            // 
            this.lstQueries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Start,
            this.End});
            this.lstQueries.GridLines = true;
            this.lstQueries.HideSelection = false;
            this.lstQueries.Location = new System.Drawing.Point(28, 62);
            this.lstQueries.Name = "lstQueries";
            this.lstQueries.Scrollable = false;
            this.lstQueries.Size = new System.Drawing.Size(137, 454);
            this.lstQueries.TabIndex = 6;
            this.lstQueries.UseCompatibleStateImageBehavior = false;
            this.lstQueries.View = System.Windows.Forms.View.Details;
            // 
            // Start
            // 
            this.Start.Text = "Start";
            this.Start.Width = 50;
            // 
            // End
            // 
            this.End.Text = "End";
            // 
            // lstThread
            // 
            this.lstThread.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Threads});
            this.lstThread.GridLines = true;
            this.lstThread.HideSelection = false;
            this.lstThread.Location = new System.Drawing.Point(196, 62);
            this.lstThread.Name = "lstThread";
            this.lstThread.Scrollable = false;
            this.lstThread.Size = new System.Drawing.Size(108, 454);
            this.lstThread.TabIndex = 7;
            this.lstThread.UseCompatibleStateImageBehavior = false;
            this.lstThread.View = System.Windows.Forms.View.Details;
            // 
            // Threads
            // 
            this.Threads.Text = "Threads";
            this.Threads.Width = 80;
            // 
            // lstResult
            // 
            this.lstResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Cost,
            this.Path});
            this.lstResult.GridLines = true;
            this.lstResult.HideSelection = false;
            this.lstResult.Location = new System.Drawing.Point(352, 62);
            this.lstResult.Name = "lstResult";
            this.lstResult.Scrollable = false;
            this.lstResult.Size = new System.Drawing.Size(316, 454);
            this.lstResult.TabIndex = 8;
            this.lstResult.UseCompatibleStateImageBehavior = false;
            this.lstResult.View = System.Windows.Forms.View.Details;
            // 
            // Cost
            // 
            this.Cost.Text = "Cost";
            this.Cost.Width = 40;
            // 
            // Path
            // 
            this.Path.Text = "Path";
            this.Path.Width = 200;
            // 
            // tsbSetting
            // 
            this.tsbSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsbSetting.Image")));
            this.tsbSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSetting.Name = "tsbSetting";
            this.tsbSetting.Size = new System.Drawing.Size(62, 28);
            this.tsbSetting.Text = "设置(&T)";
            this.tsbSetting.Click += new System.EventHandler(this.tsbSetting_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(400, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "线程数:";
            // 
            // lbNumThread
            // 
            this.lbNumThread.AutoSize = true;
            this.lbNumThread.Location = new System.Drawing.Point(457, 31);
            this.lbNumThread.Name = "lbNumThread";
            this.lbNumThread.Size = new System.Drawing.Size(15, 15);
            this.lbNumThread.TabIndex = 10;
            this.lbNumThread.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(533, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "缓冲区大小:";
            // 
            // lbBufferSize
            // 
            this.lbBufferSize.AutoSize = true;
            this.lbBufferSize.Location = new System.Drawing.Point(621, 31);
            this.lbBufferSize.Name = "lbBufferSize";
            this.lbBufferSize.Size = new System.Drawing.Size(15, 15);
            this.lbBufferSize.TabIndex = 12;
            this.lbBufferSize.Text = "1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 554);
            this.Controls.Add(this.lbBufferSize);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbNumThread);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstResult);
            this.Controls.Add(this.lstThread);
            this.Controls.Add(this.lstQueries);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "多线程最短路径";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSigStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.ToolStripButton tsbMulStart;
        private System.Windows.Forms.ListView lstQueries;
        private System.Windows.Forms.ColumnHeader Start;
        private System.Windows.Forms.ColumnHeader End;
        private System.Windows.Forms.ListView lstThread;
        private System.Windows.Forms.ColumnHeader Threads;
        private System.Windows.Forms.ListView lstResult;
        private System.Windows.Forms.ColumnHeader Cost;
        private System.Windows.Forms.ColumnHeader Path;
        private System.Windows.Forms.ToolStripButton tsbSetting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbNumThread;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbBufferSize;
    }
}

