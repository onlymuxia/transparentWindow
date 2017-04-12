namespace LEDShowSerialPort
{
    partial class Main
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Sp = new System.IO.Ports.SerialPort(this.components);
            this.label_Font = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_ParaSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEIXT = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sp
            // 
            this.Sp.BaudRate = 115200;
            this.Sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // label_Font
            // 
            this.label_Font.AutoSize = true;
            this.label_Font.BackColor = System.Drawing.Color.Transparent;
            this.label_Font.ContextMenuStrip = this.contextMenuStrip1;
            this.label_Font.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Font.ForeColor = System.Drawing.Color.Firebrick;
            this.label_Font.Location = new System.Drawing.Point(49, 43);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(300, 245);
            this.label_Font.TabIndex = 1;
            this.label_Font.Text = "PM2.5:70.7ug/m3\r\nPM10 :86.1ug/m3\r\n噪声 :60.3dBA\r\n风速 :10m/s\r\n风向 :西北偏北\r\n温度 :28.1°C\r\n湿" +
    "度 :60.1%RH\r\n";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ParaSet,
            this.tsEIXT});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // ToolStripMenuItem_ParaSet
            // 
            this.ToolStripMenuItem_ParaSet.Name = "ToolStripMenuItem_ParaSet";
            this.ToolStripMenuItem_ParaSet.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_ParaSet.Text = "参数设置";
            this.ToolStripMenuItem_ParaSet.Click += new System.EventHandler(this.ToolStripMenuItem_ParaSet_Click);
            // 
            // tsEIXT
            // 
            this.tsEIXT.Name = "tsEIXT";
            this.tsEIXT.Size = new System.Drawing.Size(124, 22);
            this.tsEIXT.Text = "退出";
            this.tsEIXT.Click += new System.EventHandler(this.tsEIXT_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(423, 336);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.label_Font);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort Sp;
        private System.Windows.Forms.Label label_Font;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ParaSet;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem tsEIXT;
    }
}

