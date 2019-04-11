using System;
using System.Runtime.InteropServices;
using SHDocVw;

namespace IEZoom.Models
{
    public class Ie : Eleve.NotificationObject
    {
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        /// <summary></summary>
        private InternetExplorer _ie;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ie"></param>
        public Ie(InternetExplorer ie)
        {
            _ie = ie;
        }
        /// <summary></summary>
        public string Url { get { return _ie.LocationURL; } }
        /// <summary></summary>
        public int HWND
        {
            get
            {
                try
                {
                    return _ie.HWND;
                }
                catch
                {
                    return -1;
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="percent"></param>
        public void Zoom(int percent)
        {
            Object pvaIn = percent;
            Object pvaOut = null;
            _ie.ExecWB((SHDocVw.OLECMDID)63, SHDocVw.OLECMDEXECOPT.OLECMDEXECOPT_DODEFAULT, ref pvaIn, ref pvaOut);

            // 最小化
            if (_ie.Top < 100 && _ie.Left < 100)
            {
                return;
            }

            int h = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            int w = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;

            if (w >= _ie.Width || h >= _ie.Height)
            {
                ShowWindow((IntPtr)HWND, 3);
            }
        }
    }
}
