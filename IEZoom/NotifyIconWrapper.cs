using System;
using System.ComponentModel;
using System.Windows;

namespace IEZoom
{
    public partial class NotifyIconWrapper : Component
    {
        /// <summary></summary>
        private IEZoomView View { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public NotifyIconWrapper()
        {
            InitializeComponent();

            View = new IEZoomView();
            View.Show();

            notifyIcon1.Click += NotifyIcon1_Click;
            // コンテキストメニューのイベントを設定
            this.menuItem_Open.Click += this.menuItem_Open_Click;
            this.menuItem_Exit.Click += this.menuItem_Exit_Click;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="container"></param>
        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);
 
            this.InitializeComponent();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            menuItem_Open_Click(sender, e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Open_Click(object sender, EventArgs e)
        {
            var ev = e as System.Windows.Forms.MouseEventArgs;
            if (ev != null && ev.Button == System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }

            View.Visibility = Visibility.Visible;
            View.Topmost = true;
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { View.Topmost = false; }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
