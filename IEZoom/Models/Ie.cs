using System;
using SHDocVw;

namespace IEZoom.Models
{
    public class Ie : Eleve.NotificationObject
    {
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
        }
    }
}
