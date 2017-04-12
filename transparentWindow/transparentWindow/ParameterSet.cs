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

            panel_font.BackColor = SystemManager.GetInstance().FontColor;
            TransparentcheckBox.Checked = SystemManager.GetInstance().Transparent ;
            panel_Back.BackColor =SystemManager.GetInstance().BackGroundColor;
        }
        Color BackGroundColor = new Color();
        Color FontColor = new Color();
        private void ParameterSet_Load(object sender, EventArgs e)
        {
            InitserialPortData();
            InitColor();
            GetSpNameList();
        }
        private void InitColor()
        {
            using (Main main = new Main())
            {
                panel_font.BackColor = label_Font.ForeColor = SystemManager.GetInstance().FontColor;
                panel_Back.BackColor = panel_BackGround.BackColor = SystemManager.GetInstance().BackGroundColor;
            }
            SystemManager.GetInstance().SaveConfig();
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
      
        private void InitserialPortData()
        {
            using (Main main = new Main())
            {
                cmbSpName.Text = main.InitserialPortData(true);
            }
        }
        private void button_Color_Back_Click(object sender, EventArgs e)
        {
            if (backgroudcolorDialog.ShowDialog() == DialogResult.OK)
            {
                SystemManager.GetInstance().BackGroundColor = backgroudcolorDialog.Color;
				InitColor();
            }
        }
        private void button_Color_font_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                SystemManager.GetInstance().FontColor = colorDialog.Color; 
				InitColor();
            }
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

        private void TransparentcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SystemManager.GetInstance().Transparent = TransparentcheckBox.Checked;
            SystemManager.GetInstance().SaveConfig();
        }


    }
}
