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
            this.popMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_ParaSet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsEIXT = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.windowsTimer = new System.Windows.Forms.Timer(this.components);
            this.popMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Sp
            // 
            this.Sp.BaudRate = 115200;
            this.Sp.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // label_Font
            // 
            this.label_Font.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Font.AutoSize = true;
            this.label_Font.BackColor = System.Drawing.Color.Transparent;
            this.label_Font.ContextMenuStrip = this.popMenu;
            this.label_Font.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Font.ForeColor = System.Drawing.Color.Firebrick;
            this.label_Font.Location = new System.Drawing.Point(18, 21);
            this.label_Font.Margin = new System.Windows.Forms.Padding(9, 0, 9, 0);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(120, 48);
            this.label_Font.TabIndex = 1;
            this.label_Font.Text = "TEST";
            this.label_Font.Click += new System.EventHandler(this.Main_MouseClickEnter);
            this.label_Font.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMainMouseDown);
            this.label_Font.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMainMouseMove);
            // 
            // popMenu
            // 
            this.popMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ParaSet,
            this.tsEIXT});
            this.popMenu.Name = "contextMenuStrip1";
            this.popMenu.Size = new System.Drawing.Size(125, 48);
            // 
            // ToolStripMenuItem_ParaSet
            // 
            this.ToolStripMenuItem_ParaSet.Name = "ToolStripMenuItem_ParaSet";
            this.ToolStripMenuItem_ParaSet.Size = new System.Drawing.Size(124, 22);
            this.ToolStripMenuItem_ParaSet.Text = "参数设置";
            this.ToolStripMenuItem_ParaSet.Click += new System.EventHandler(this.SetParameter_Click);
            // 
            // tsEIXT
            // 
            this.tsEIXT.Name = "tsEIXT";
            this.tsEIXT.Size = new System.Drawing.Size(124, 22);
            this.tsEIXT.Text = "退出";
            this.tsEIXT.Click += new System.EventHandler(this.Main_Exit_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // windowsTimer
            // 
            this.windowsTimer.Interval = 300;
            this.windowsTimer.Tick += new System.EventHandler(this.windowsTimer_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(593, 400);
            this.ContextMenuStrip = this.popMenu;
            this.ControlBox = false;
            this.Controls.Add(this.label_Font);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResizeBegin += new System.EventHandler(this.Main_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.Main_ResizeEnd);
            this.Click += new System.EventHandler(this.Main_MouseClickEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMainMouseDown);
            this.MouseLeave += new System.EventHandler(this.Main_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMainMouseMove);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.popMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort Sp;
        private System.Windows.Forms.Label label_Font;
        private System.Windows.Forms.ContextMenuStrip popMenu;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ParaSet;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem tsEIXT;
        private System.Windows.Forms.Timer windowsTimer;
    }
}

