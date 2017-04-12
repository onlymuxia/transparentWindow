namespace LEDShowSerialPort
{
    partial class ParameterSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParameterSet));
            this.button_Color_font = new System.Windows.Forms.Button();
            this.button_Color_Back = new System.Windows.Forms.Button();
            this.panel_Back = new System.Windows.Forms.Panel();
            this.panel_font = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panel_BackGround = new System.Windows.Forms.Panel();
            this.lable3 = new System.Windows.Forms.Label();
            this.label_Font = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbSpName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbSpBru = new System.Windows.Forms.ComboBox();
            this.btnSpOpen = new System.Windows.Forms.Button();
            this.panel_BackGround.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_Color_font
            // 
            this.button_Color_font.Location = new System.Drawing.Point(57, 284);
            this.button_Color_font.Name = "button_Color_font";
            this.button_Color_font.Size = new System.Drawing.Size(75, 23);
            this.button_Color_font.TabIndex = 26;
            this.button_Color_font.Text = "字体颜色";
            this.button_Color_font.UseVisualStyleBackColor = true;
            this.button_Color_font.Click += new System.EventHandler(this.button_Color_font_Click);
            // 
            // button_Color_Back
            // 
            this.button_Color_Back.Location = new System.Drawing.Point(57, 234);
            this.button_Color_Back.Name = "button_Color_Back";
            this.button_Color_Back.Size = new System.Drawing.Size(75, 23);
            this.button_Color_Back.TabIndex = 25;
            this.button_Color_Back.Text = "背景颜色";
            this.button_Color_Back.UseVisualStyleBackColor = true;
            this.button_Color_Back.Click += new System.EventHandler(this.button_Color_Back_Click);
            // 
            // panel_Back
            // 
            this.panel_Back.Location = new System.Drawing.Point(138, 234);
            this.panel_Back.Name = "panel_Back";
            this.panel_Back.Size = new System.Drawing.Size(75, 23);
            this.panel_Back.TabIndex = 27;
            // 
            // panel_font
            // 
            this.panel_font.Location = new System.Drawing.Point(138, 284);
            this.panel_font.Name = "panel_font";
            this.panel_font.Size = new System.Drawing.Size(75, 23);
            this.panel_font.TabIndex = 28;
            // 
            // panel_BackGround
            // 
            this.panel_BackGround.BackColor = System.Drawing.Color.Black;
            this.panel_BackGround.Controls.Add(this.label_Font);
            this.panel_BackGround.Location = new System.Drawing.Point(252, 44);
            this.panel_BackGround.Name = "panel_BackGround";
            this.panel_BackGround.Size = new System.Drawing.Size(374, 339);
            this.panel_BackGround.TabIndex = 29;
            // 
            // lable3
            // 
            this.lable3.AutoSize = true;
            this.lable3.Location = new System.Drawing.Point(597, 18);
            this.lable3.Name = "lable3";
            this.lable3.Size = new System.Drawing.Size(29, 12);
            this.lable3.TabIndex = 30;
            this.lable3.Text = "预览";
            // 
            // label_Font
            // 
            this.label_Font.AutoSize = true;
            this.label_Font.BackColor = System.Drawing.Color.Transparent;
            this.label_Font.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Font.ForeColor = System.Drawing.Color.Firebrick;
            this.label_Font.Location = new System.Drawing.Point(35, 44);
            this.label_Font.Name = "label_Font";
            this.label_Font.Size = new System.Drawing.Size(300, 245);
            this.label_Font.TabIndex = 2;
            this.label_Font.Text = "PM2.5:70.7ug/m3\r\nPM10 :86.1ug/m3\r\n噪声 :60.3dBA\r\n风速 :10m/s\r\n风向 :西北偏北\r\n温度 :28.1°C\r\n湿" +
    "度 :60.1%RH\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbSpName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbSpBru);
            this.groupBox1.Controls.Add(this.btnSpOpen);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(57, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(175, 159);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSearch.Location = new System.Drawing.Point(86, 132);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(18, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "波特率";
            // 
            // cmbSpName
            // 
            this.cmbSpName.FormattingEnabled = true;
            this.cmbSpName.Location = new System.Drawing.Point(65, 51);
            this.cmbSpName.Name = "cmbSpName";
            this.cmbSpName.Size = new System.Drawing.Size(96, 20);
            this.cmbSpName.TabIndex = 0;
            this.cmbSpName.Text = "COM1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(18, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "串口号";
            // 
            // cmbSpBru
            // 
            this.cmbSpBru.FormattingEnabled = true;
            this.cmbSpBru.Items.AddRange(new object[] {
            "9600",
            "11400",
            "19200",
            "38400",
            "56000",
            "57600",
            "115200"});
            this.cmbSpBru.Location = new System.Drawing.Point(65, 77);
            this.cmbSpBru.Name = "cmbSpBru";
            this.cmbSpBru.Size = new System.Drawing.Size(96, 20);
            this.cmbSpBru.TabIndex = 1;
            this.cmbSpBru.Text = "115200";
            // 
            // btnSpOpen
            // 
            this.btnSpOpen.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSpOpen.Location = new System.Drawing.Point(86, 103);
            this.btnSpOpen.Name = "btnSpOpen";
            this.btnSpOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSpOpen.TabIndex = 2;
            this.btnSpOpen.Text = "打开";
            this.btnSpOpen.UseVisualStyleBackColor = true;
            this.btnSpOpen.Click += new System.EventHandler(this.btnSpOpen_Click);
            // 
            // ParameterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(658, 416);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lable3);
            this.Controls.Add(this.panel_BackGround);
            this.Controls.Add(this.panel_font);
            this.Controls.Add(this.panel_Back);
            this.Controls.Add(this.button_Color_font);
            this.Controls.Add(this.button_Color_Back);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ParameterSet";
            this.Load += new System.EventHandler(this.ParameterSet_Load);
            this.panel_BackGround.ResumeLayout(false);
            this.panel_BackGround.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Color_font;
        private System.Windows.Forms.Button button_Color_Back;
        private System.Windows.Forms.Panel panel_Back;
        private System.Windows.Forms.Panel panel_font;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel panel_BackGround;
        private System.Windows.Forms.Label lable3;
        private System.Windows.Forms.Label label_Font;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbSpName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbSpBru;
        private System.Windows.Forms.Button btnSpOpen;
    }
}