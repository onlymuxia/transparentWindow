using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace LEDShowSerialPort
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        #region 属性
        Color FontColor = new Color();
        public static string PortName = "COM1";
        public static string Brulate = "115200";
        float X = 0;
        float Y = 0;
        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int Left;
            public int Right;
            public int Top;
            public int Bottom;
        }
        //
        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern void DwmExtendFrameIntoClientArea(IntPtr hwnd, ref MARGINS margins);

        [DllImport("dwmapi.dll", PreserveSig = false)]
        static extern bool DwmIsCompositionEnabled(); //Dll 导入 DwmApi
        //
        public static bool isOpensp = true;

        string PM25_str = "     ";
        string PM10_str = "     ";
        string Noise_str = "     ";
        string WindSpeed = "     ";
        string WindDirc = "       ";
        string Temp = "     ";
        string Humi = "     ";
        string Nxion = "     ";

        string Forth_labe = "负离子:    个\r\n" +
                            "PM2.5 :   μg/m³\r\n" +
            // "PM10  :   μg/m³\r\n" +
                            "温度  :   ℃\r\n" +
                            "湿度  :   %RH\r\n";

        private bool SpOpenFlag = false;


        const int Guying_HTLEFT = 10;
        const int Guying_HTRIGHT = 11;
        const int Guying_HTTOP = 12;
        const int Guying_HTTOPLEFT = 13;
        const int Guying_HTTOPRIGHT = 14;
        const int Guying_HTBOTTOM = 15;
        const int Guying_HTBOTTOMLEFT = 0x10;
        const int Guying_HTBOTTOMRIGHT = 17;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x0084:
                    base.WndProc(ref m);
                    Point vPoint = new Point((int)m.LParam & 0xFFFF,
                        (int)m.LParam >> 16 & 0xFFFF);
                    vPoint = PointToClient(vPoint);
                    if (vPoint.X <= 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPLEFT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMLEFT;
                        else m.Result = (IntPtr)Guying_HTLEFT;
                    else if (vPoint.X >= ClientSize.Width - 5)
                        if (vPoint.Y <= 5)
                            m.Result = (IntPtr)Guying_HTTOPRIGHT;
                        else if (vPoint.Y >= ClientSize.Height - 5)
                            m.Result = (IntPtr)Guying_HTBOTTOMRIGHT;
                        else m.Result = (IntPtr)Guying_HTRIGHT;
                    else if (vPoint.Y <= 5)
                        m.Result = (IntPtr)Guying_HTTOP;
                    else if (vPoint.Y >= ClientSize.Height - 5)
                        m.Result = (IntPtr)Guying_HTBOTTOM;
                    break;
                case 0x0201:                //鼠标左键按下的消息 
                    m.Msg = 0x00A1;         //更改消息为非客户区按下鼠标 
                    m.LParam = IntPtr.Zero; //默认值 
                    m.WParam = new IntPtr(2);//鼠标放在标题栏内 
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (DwmIsCompositionEnabled())
            {
                e.Graphics.Clear(Color.Transparent); //将窗体用黑色填充（Dwm 会把黑色视为透明区域）
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            //如果启用Aero
            if (DwmIsCompositionEnabled())
            {
                MARGINS m = new MARGINS();
                m.Right = -1; //设为负数,则全窗体透明
                DwmExtendFrameIntoClientArea(this.Handle, ref m); //开启全窗体透明效果
            }
            base.OnLoad(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            //
            X = this.Width;
            Y = this.Height;
            //setTag(this);  
            InitAll();
            timer1.Enabled = true;

            Forth_labe =
                    "负离子:" + Nxion + " 个\r\n" +
                    "PM2.5 :" + PM25_str + " μg/m³\r\n" +
                //"PM10  :" + PM10_str + " μg/m³\r\n" +
                    "温度  :" + Temp + " ℃\r\n" +
                    "湿度  :" + Humi + " %RH\r\n";
            label_Font.Text = Forth_labe;
            //
            //label_Font.Location = new Point((this.Width-label_Font.Width)/2, (this.Height-label_Font.Width)/2);

            //label_Font.Top = (this.ClientRectangle.Height - label_Font.Height) / 2;
        }


        public void OpenSp(string cmName, string brulate)
        {
            try
            {
                if (Sp.IsOpen)
                {
                    Sp.Close();
                    Sp.BaudRate = int.Parse(brulate);
                    Sp.PortName = cmName;
                    Sp.DataBits = 8;
                    Sp.Parity = System.IO.Ports.Parity.None;
                    Sp.StopBits = System.IO.Ports.StopBits.One;
                    Sp.WriteTimeout = 50;
                    Sp.ReadBufferSize = 2048;
                    Sp.WriteBufferSize = 2048;
                    Sp.Open();
                    MessageBox.Show("串口打开成功，端口号：" + cmName + " 波特率：" + brulate);
                }
                else
                {
                    Sp.BaudRate = int.Parse(brulate);
                    Sp.PortName = cmName;
                    Sp.DataBits = 8;
                    Sp.Parity = System.IO.Ports.Parity.None;
                    Sp.StopBits = System.IO.Ports.StopBits.One;
                    Sp.WriteTimeout = 50;
                    Sp.ReadBufferSize = 2048;
                    Sp.WriteBufferSize = 2048;
                    Sp.Open();
                    MessageBox.Show("串口打开成功，端口号：" + cmName + " 波特率：" + brulate);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("串口打开失败" + ex.Message);
            }
        }

        #region 字体大小随之变化
        //private void Main_Resize(object sender, EventArgs e)
        //{
        //    // throw new Exception("The method or operation is not implemented.");  
        //    float newx = (this.Width) / X;
        //    //  float newy = (this.Height - this.statusStrip1.Height) / (Y - y);  
        //    float newy = this.Height / Y;
        //    //setControls(newx, newy, this);
        //    //this.Text = this.Width.ToString() +" "+ this.Height.ToString();  
        //    //labe随着窗体居中
        //    //label_Font.Left = (this.ClientRectangle.Width - label_Font.Width) / 2;
        //    //label_Font.Top = (this.ClientRectangle.Height - label_Font.Height) / 2;
        //    //label_Font.BringToFront();
        //    //panel_Back.Left = (this.ClientRectangle.Width - label_Font.Width) / 2;
        //    //panel_Back.BringToFront();
        //    //label_Font.Font=

        //}
        //private void setTag(Control cons)
        //{
        //    foreach (Control con in cons.Controls)
        //    {
        //        con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
        //        if (con.Controls.Count > 0)
        //            setTag(con);
        //    }
        //}  
        //private void setControls(float newx, float newy, Control cons)
        //{
        //    foreach (Control con in cons.Controls)
        //    {
        //        if (con is Panel || con is Label)
        //        {
        //            string[] mytag = con.Tag.ToString().Split(new char[] { ':' });
        //            float a = Convert.ToSingle(mytag[0]) * newx;
        //            con.Width = (int)a;
        //            a = Convert.ToSingle(mytag[1]) * newy;
        //            con.Height = (int)(a);
        //            a = Convert.ToSingle(mytag[2]) * newx;
        //            con.Left = (int)(a);
        //            a = Convert.ToSingle(mytag[3]) * newy;
        //            con.Top = (int)(a);
        //            Single currentSize = Convert.ToSingle(mytag[4]) * newy;
        //            con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
        //            if (con.Controls.Count > 0)
        //            {
        //                setControls(newx, newy, con);
        //            }
        //        }
        //    }  
        //}
        #endregion

        public void InitAll()
        {
            InitserialPortData();
            InitBackGround();
            InitFontColor();
        }
        #region 设置颜色及串口号
        /// <summary>
        /// 串口数据设置
        /// </summary>
        /// <param name="readOnly">是否只是读取文件数据</param>
        /// <returns></returns>
        public string InitserialPortData(bool readOnly = false)
        {
            try
            {
                StreamReader Read3 = new StreamReader("DK.txt", Encoding.UTF8);
                PortName = Read3.ReadLine();
                Brulate = Read3.ReadLine();
                Read3.Close();
                if (!readOnly) Sp.PortName = PortName;
                return PortName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return "COM1";
            }
        }
        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="BackColor"></param>
        public Color InitBackGround(bool readOnly = false)
        {
            Color BackGroundColor = new Color();
            try
            {
                int[] color_background = new int[3];
                StreamReader Read = new StreamReader("BackColor.txt", Encoding.Default);
                color_background[0] = Convert.ToInt32(Read.ReadLine());
                color_background[1] = Convert.ToInt32(Read.ReadLine());
                color_background[2] = Convert.ToInt32(Read.ReadLine());
                Read.Close();
                BackGroundColor = Color.FromArgb(color_background[0], color_background[1], color_background[2]);
                if (!readOnly)
                {
                    this.BackColor = BackGroundColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return BackGroundColor;
        }

        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <param name="BackColor"></param>
        public Color InitFontColor(bool readOnly = false)
        {
            try
            {
                int[] color_font = new int[3] { 35, 58, 180 };
                StreamReader Read1 = new StreamReader("FontColor.txt", Encoding.Default);
                color_font[0] = Convert.ToInt32(Read1.ReadLine());
                color_font[1] = Convert.ToInt32(Read1.ReadLine());
                color_font[2] = Convert.ToInt32(Read1.ReadLine());
                Read1.Close();
                FontColor = Color.FromArgb(color_font[0], color_font[1], color_font[2]);
                if (!readOnly) SetAllLableFontColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return FontColor;
        }

        private void SetAllLableFontColor()
        {
            label_Font.ForeColor = FontColor;
        }
        #endregion

        /// <summary>
        /// 右键菜单 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_ParaSet_Click(object sender, EventArgs e)
        {
            using (ParameterSet ps = new ParameterSet())
            {
                ps.ShowDialog();
                InitBackGround();
                InitFontColor();
            }
        }

        #region 串口接收数据

        public byte getLrc(byte[] revbytes, int len)
        {
            //
            byte lrcbyte = revbytes[0];
            for (int i = 1; i < len; i++)
            {
                lrcbyte ^= revbytes[i];
            }
            return lrcbyte;
        }
        /// <summary>
        /// 串口接收数据
        /// </summary>
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                Thread.Sleep(300);
                string str = Sp.ReadLine();//读取数据
                string[] revStrarr = str.Split(new char[2] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < revStrarr.Length; j++)
                {

                    byte[] read = Convert.FromBase64String(revStrarr[j]);

                    if (read[0] == 0xD0)
                    {
                        int len = read[2] + read[3] * 256;
                        if (read[len - 19] == getLrc(read, len - 19))
                        {
                            string EndDevID = Encoding.ASCII.GetString(read, len - 18, 16);
                            if (read[1] == 0x02)
                            {
                                this.Invoke((EventHandler)(delegate
                                {
                                    int sensorNum = read[4];
                                    int index = 6;
                                    double[] sensorData = new double[sensorNum];
                                    for (int i = 0; i < 20; i++)
                                        sensorData[i] = -1000;
                                    for (int i = 0; i < sensorNum; i++)
                                    {
                                        sensorData[i] = BitConverter.ToSingle(read, index);
                                        index += 5;
                                    }

                                    if (sensorData[0] == -1000)//pm25
                                    {
                                        PM25_str = "     ";
                                    }
                                    else
                                    {
                                        PM25_str = sensorData[0].ToString("F1");
                                    }

                                    if (sensorData[1] == -1000)//pm10
                                    {
                                        PM10_str = "     ";
                                    }
                                    else
                                    {
                                        PM10_str = sensorData[1].ToString("F1");
                                    }

                                    if (sensorData[3] == -1000)//NOISE
                                    {
                                        Noise_str = "     ";
                                    }
                                    else
                                    {
                                        Noise_str = sensorData[3].ToString("F1");
                                    }

                                    if (sensorData[4] == -1000)//风速
                                    {
                                        WindSpeed = "     ";
                                    }
                                    else
                                    {
                                        WindSpeed = sensorData[4].ToString("F1");
                                    }


                                    if (sensorData[5] == -1000)//风向
                                    {
                                        WindDirc = "     ";
                                    }
                                    else
                                    {
                                        if (sensorData[5] == 0)
                                        {
                                            WindDirc = "东北偏北";
                                        }
                                        else if (sensorData[5] == 1)
                                        {
                                            WindDirc = "东北";
                                        }
                                        else if (sensorData[5] == 2)
                                        {
                                            WindDirc = "东北偏东";
                                        }

                                        else if (sensorData[5] == 3)
                                        {
                                            WindDirc = "正东";
                                        }
                                        else if (sensorData[5] == 4)
                                        {
                                            WindDirc = "东南偏东";
                                        }

                                        else if (sensorData[5] == 5)
                                        {
                                            WindDirc = " 东南";
                                        }
                                        else if (sensorData[5] == 6)
                                        {
                                            WindDirc = "东南偏南";
                                        }

                                        else if (sensorData[5] == 7)
                                        {
                                            WindDirc = "正南";
                                        }
                                        else if (sensorData[5] == 8)
                                        {
                                            WindDirc = "西南偏南";
                                        }
                                        else if (sensorData[5] == 9)
                                        {
                                            WindDirc = "西南";
                                        }
                                        else if (sensorData[5] == 10)
                                        {
                                            WindDirc = "西南偏西";
                                        }
                                        else if (sensorData[5] == 11)
                                        {
                                            WindDirc = "正西";
                                        }
                                        else if (sensorData[5] == 12)
                                        {
                                            WindDirc = "西北偏西";
                                        }
                                        else if (sensorData[5] == 13)
                                        {
                                            WindDirc = "西北";
                                        }

                                        else if (sensorData[5] == 14)
                                        {
                                            WindDirc = "西北偏北";
                                        }
                                        else if (sensorData[5] == 15)
                                        {
                                            WindDirc = "正北";
                                        }
                                    }

                                    if (sensorData[6] == -1000)//温度
                                    {
                                        Temp = "     ";
                                    }
                                    else
                                    {
                                        Temp = sensorData[6].ToString("F1");
                                    }
                                    if (sensorData[8] == -1000)//风速
                                    {
                                        Humi = "     ";
                                    }
                                    else
                                    {
                                        Humi = sensorData[8].ToString("F1");
                                    }
                                    if (sensorData[9] == -1000)//负离子
                                    {
                                        Nxion = "     ";
                                    }
                                    else
                                    {
                                        Nxion = sensorData[9].ToString("F1");
                                    }
                                    Forth_labe =
                                        "负离子:" + Nxion + " 个\r\n" +
                                        "PM2.5:" + PM25_str + " μg/m³\r\n" +
                                        //"PM10  :" + PM10_str + " μg/m³\r\n" +
                                        "温度 :" + Temp + " ℃\r\n" +
                                        "湿度 :" + Humi + " %RH\r\n";
                                    label_Font.Text = Forth_labe;
                                }));
                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isOpensp)
            {
                isOpensp = false;
                OpenSp(PortName, Brulate);
            }
            //            ss += 1;
            //            int len = ss.ToString("F1").Length;
            //            PM25_str = ss.ToString("F1");
            //            PM10_str = ss.ToString("F1");
            //            Noise_str = ss.ToString("F1");
            //            WindSpeed = ss.ToString("F1");
            //            WindDirc = ss.ToString("F1");
            //            Temp = ss.ToString("F1");
            //            Humi=ss.ToString("F1");

            //            string Forth_labe = "PM2.5:" + PM25_str + "μg/m³\r\n" +
            //"PM10 :" + PM10_str + "μg/m³\r\n" +
            //"噪声 :" + Noise_str + "dBA\r\n" +
            //"风速 :" + WindSpeed + "m/s\r\n" +
            //"风向 :" + WindDirc + "\r\n" +
            //"温度 :" + Temp + "℃\r\n" +
            //"湿度 :" + Humi + "%RH\r\n";


            //            label_Font.Text = Forth_labe;
        }

        private void tsEIXT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private Size beforeResizeSize = Size.Empty;

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            beforeResizeSize = this.Size;

        }
        protected override void OnResizeEnd(EventArgs e)
        {
            base.OnResizeEnd(e);
            //窗口resize之后的大小
            Size endResizeSize = this.Size;
            //获得变化比例
            float percentWidth = (float)endResizeSize.Width / beforeResizeSize.Width;
            float percentHeight = (float)endResizeSize.Height / beforeResizeSize.Height;
            foreach (Control control in this.Controls)
            {
                //按比例改变控件大小
                control.Width = (int)(control.Width * percentWidth);
                control.Height = (int)(control.Height * percentHeight);
                //为了不使控件之间覆盖 位置也要按比例变化
                control.Left = (int)(control.Left * percentWidth);
                control.Top = (int)(control.Top * percentHeight);

                //label_Font.Left = (this.ClientRectangle.Width - label_Font.Width) / 2;
                //label_Font.Top = (this.ClientRectangle.Height - label_Font.Height) / 2;
                label_Font.BringToFront();
                Font font = new Font("宋体", label_Font.Font.Size * percentHeight);
                label_Font.Font = font;
            }

        }
    }
}
