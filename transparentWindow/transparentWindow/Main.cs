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
        private float X;//当前窗体的宽度
        private float Y;//当前窗体的高度

        public Main()
        {
            InitializeComponent();
        }

        #region 属性
        public Color FontColor = new Color();
        public static string PortName = "COM1";
        public static string Brulate = "115200";
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
                            "温度  :   ℃\r\n" +
                            "湿度  :   %RH\r\n";

        private bool SpOpenFlag = false;
        #endregion

        #region 窗口初始化
        /*
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
        */
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

           if (SystemManager.GetInstance().Transparent)
           {
               if (DwmIsCompositionEnabled())
                {
                    e.Graphics.Clear(Color.Transparent); //将窗体用黑色填充（Dwm 会把黑色视为透明区域）
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitserialPortData();
            InitColor();

            Forth_labe =
                    "AAAAAAAAAAAAAAAAAAAAAAAAAAAAA\r\n" +
                    "BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB\r\n" +
                    "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX" +
                    "CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC\r\n" +
                    "VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV\r\n";
            label_Font.Text = Forth_labe;

            X = this.Width;//获取窗体的宽度
            Y = this.Height;//获取窗体的高度
            setTag(this);//调用方法
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

        public void InitColor()
        {
          
            this.FontColor = SystemManager.GetInstance().FontColor;
            this.label_Font.ForeColor = this.FontColor;
            this.BackColor = SystemManager.GetInstance().BackGroundColor;
            if (SystemManager.GetInstance().Transparent)
            {
                //如果启用Aero
                if (DwmIsCompositionEnabled())
                {
                    MARGINS m = new MARGINS();
                    m.Right = -1; //设为负数,则全窗体透明
                    DwmExtendFrameIntoClientArea(this.Handle, ref m); //开启全窗体透明效果
                }
            }

        }
        #endregion
        #region 设置串口
        /// <summary>
        /// 串口数据设置
        /// </summary>
        /// <param name="readOnly">是否只是读取文件数据</param>
        /// <returns></returns>
        public string InitserialPortData(bool readOnly = false)
        {
            //try
            //{
            //    StreamReader Read3 = new StreamReader("DK.txt", Encoding.UTF8);
            //    PortName = Read3.ReadLine();
            //    Brulate = Read3.ReadLine();
            //    Read3.Close();
            //    if (!readOnly) Sp.PortName = PortName;
            //    return PortName;
            //}
            //catch (Exception ex)
            //{
            // //   MessageBox.Show(ex.ToString());
               return "COM1";
            //}
        }

        //public byte getLrc(byte[] revbytes, int len)
        //{
        //    //
        //    byte lrcbyte = revbytes[0];
        //    for (int i = 1; i < len; i++)
        //    {
        //        lrcbyte ^= revbytes[i];
        //    }
        //    return lrcbyte;
        //}
        /// <summary>
        /// 数据处理
        /// </summary>
        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("数据处理");
        }
        #endregion

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isOpensp)
            {
                isOpensp = false;
                OpenSp(PortName, Brulate);
            }
        }
        
        #region 右键菜单
        private void Main_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// 右键菜单 参数设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetParameter_Click(object sender, EventArgs e)
        {
            using (ParameterSet ps = new ParameterSet())
            {
                ps.ShowDialog();
                InitColor();
            }
        }
        #endregion

        #region 窗口大小

        private void Main_MouseLeave(object sender, EventArgs e)
        {
            windowsTimer.Enabled = true;
            windowsTimerCount = 0;
        }


        /// <summary>
        /// 窗体事件计时：当鼠标离开窗体后一段时间，显示边框
        /// </summary>
        private int windowsTimerCount;
        private void windowsTimer_Tick(object sender, EventArgs e)
        {
            if (windowsTimerCount > 2)
            {
                windowsTimerCount = 0;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                windowsTimer.Enabled = false;
            }
            else
            {
                windowsTimerCount++;
            }
        }

        private void Main_MouseClickEnter(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            windowsTimer.Enabled = false;
        }

        private void Main_ResizeBegin(object sender, EventArgs e)
        {
            windowsTimerCount = 0;
            windowsTimer.Enabled = false;
        }

        private void Main_ResizeEnd(object sender, EventArgs e)
        {
            windowsTimer.Enabled = true;
        }
       
        private void Main_Resize(object sender, EventArgs e)
        {
            float newx = (this.Width) / X; //窗体宽度缩放比例
            float newy = (this.Height) / Y;//窗体高度缩放比例
            setControls(newx, newy, this);//随窗体改变控件大小
        }

        /// <summary>
        /// 将控件的宽，高，左边距，顶边距和字体大小暂存到tag属性中
        /// </summary>
        /// <param name="cons">递归控件中的控件</param>
        private void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    setTag(con);
            }
        }
        //根据窗体大小调整控件大小
        private void setControls(float newx, float newy, Control cons)
        {
            if (cons == null || cons.Controls == null) return;
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                if (con.Tag == null) continue;
                string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//获取控件的Tag属性值，并分割后存储字符串数组
                float a = System.Convert.ToSingle(mytag[0]) * newx;//根据窗体缩放比例确定控件的值，宽度
                con.Width = (int)a;//宽度
                a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                con.Height = (int)(a);
                a = System.Convert.ToSingle(mytag[2]) * newx;//左边距离
                con.Left = (int)(a);
                a = System.Convert.ToSingle(mytag[3]) * newy;//上边缘距离
                con.Top = (int)(a);
                Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字体大小
                con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                if (con.Controls.Count > 0)
                {
                    setControls(newx, newy, con);
                }
            }
        }

        #endregion

        #region 窗口移动
         int x, y;
        void FormMainMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }
 
        void FormMainMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
         #endregion

       

       
    }
}
