using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace LEDShowSerialPort
{
    public partial class ParameterSet : Form
    {
        public ParameterSet()
        {
            InitializeComponent();
        }
        Color BackGroundColor = new Color();
        Color FontColor = new Color();
        private void ParameterSet_Load(object sender, EventArgs e)
        {
            InitserialPortData();
            InitBackColor();
            InitFontColor();
            GetSpNameList();
        }
        private void InitBackColor()
        {
            using (Main main = new Main())
            {
                panel_Back.BackColor = BackGroundColor = main.InitBackGround(true);
                panel_BackGround.BackColor = BackGroundColor;
            }
        }
        //获取串口名称
        private void GetSpNameList()
        {
            try
            {
                cmbSpName.Items.Clear();
                foreach (string SpName in SerialPort.GetPortNames())
                {
                    cmbSpName.Items.Add(SpName);
                    cmbSpName.Text = SpName;
                }
            }
            catch
            {

            }
        }
        private void InitFontColor()
        {
            using (Main main = new Main())
            {
                panel_font.BackColor = FontColor = main.InitFontColor(true);
                label_Font.ForeColor = FontColor;
            }
        }
        private void InitserialPortData()
        {
            using (Main main = new Main())
            {
                cmbSpName.Text = main.InitserialPortData(true);
            }
        }
        private void button_Color_Back_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color col = colorDialog1.Color;
                FileStream tempStream = new FileStream("BackColor.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(tempStream);
                writer.WriteLine(col.R);
                writer.WriteLine(col.G);
                writer.WriteLine(col.B);
                writer.Close();
                tempStream.Close();  
                InitBackColor();
            }
        }

        private void button_Color_font_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color col = colorDialog1.Color;
                FileStream tempStream = new FileStream("FontColor.txt", FileMode.Create);
                StreamWriter writer = new StreamWriter(tempStream);
                writer.WriteLine(col.R);
                writer.WriteLine(col.G);
                writer.WriteLine(col.B);
                writer.Close();
                tempStream.Close();
                InitFontColor();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSpOpen_Click(object sender, EventArgs e)
        {
            FileStream tempStream = new FileStream("DK.txt", FileMode.Create);
            StreamWriter writer = new StreamWriter(tempStream);
            writer.WriteLine(cmbSpName.Text.ToString());
            writer.WriteLine(cmbSpBru.Text.ToString());
            writer.Close();
            tempStream.Close();
            //
            Main.PortName = cmbSpName.Text.ToString();
            Main.Brulate = cmbSpBru.Text.ToString();
            Main.isOpensp = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetSpNameList();
        }
    }
}
