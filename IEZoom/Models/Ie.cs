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
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            get { return _ie.LocationURL; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="percent"></param>
        public void Zoom(int percent)
        {
            _ie.Document.body.runtimeStyle.Zoom = percent + "%";
        }
    }
}
