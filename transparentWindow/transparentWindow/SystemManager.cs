using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using transparentWindow.Properties;

namespace LEDShowSerialPort
{
    class SystemManager
    {
        private volatile static SystemManager _instance = null;
        private static readonly object lockHelper = new object();
        private SystemManager() {
            //初始化数据
            try
            {
                transparent = Settings.Default.transparent;
                fontColor = Settings.Default.fontColor;
                backGroundColor = Settings.Default.backGroundColor;
            }
            catch (Exception)
            {
                
               //Do noting :就当不存在配置;
            }
        }
        public static SystemManager GetInstance()
        {
            if(_instance == null)
            {
                lock(lockHelper)
                {
                    if(_instance == null)
                        _instance = new SystemManager();
                }
            }
            return _instance;
        }

        private Color fontColor;
        private Color backGroundColor;
        private bool transparent;

        public bool Transparent
        {
            get { return transparent; }
            set { transparent = value; }
        }

        public Color FontColor
        {
          get { return fontColor; }
          set { fontColor = value; }
        }

        public Color BackGroundColor
        {
          get { return backGroundColor; }
          set { backGroundColor = value; }
        }


        internal void SaveConfig()
        {
            Settings.Default.Save();
        }
    }
}
