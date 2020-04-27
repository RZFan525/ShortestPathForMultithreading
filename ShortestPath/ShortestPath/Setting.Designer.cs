namespace ShortestPath
{
    partial class Setting
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbNumThread = new System.Windows.Forms.TextBox();
            this.tbBufferSize = new System.Windows.Forms.TextBox();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入线程数:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "请输入缓冲区大小:";
            // 
            // tbNumThread
            // 
            this.tbNumThread.Location = new System.Drawing.Point(179, 22);
            this.tbNumThread.MaxLength = 3;
            this.tbNumThread.Name = "tbNumThread";
            this.tbNumThread.Size = new System.Drawing.Size(100, 25);
            this.tbNumThread.TabIndex = 2;
            this.tbNumThread.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumThread_KeyPress);
            // 
            // tbBufferSize
            // 
            this.tbBufferSize.Location = new System.Drawing.Point(179, 60);
            this.tbBufferSize.MaxLength = 3;
            this.tbBufferSize.Name = "tbBufferSize";
            this.tbBufferSize.Size = new System.Drawing.Size(100, 25);
            this.tbBufferSize.TabIndex = 3;
            this.tbBufferSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbBufferSize_KeyPress);
            // 
            // btConfirm
            // 
            this.btConfirm.Location = new System.Drawing.Point(54, 106);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(75, 32);
            this.btConfirm.TabIndex = 4;
            this.btConfirm.Text = "确定";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(191, 106);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 32);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 150);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.tbBufferSize);
            this.Controls.Add(this.tbNumThread);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Setting";
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNumThread;
        private System.Windows.Forms.TextBox tbBufferSize;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btCancel;
    }
}