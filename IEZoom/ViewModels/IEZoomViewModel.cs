using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows.Threading;
using Eleve;
using IEZoom.Models;
using mshtml;
using SHDocVw;

namespace IEZoom.ViewModels
{
    public class IEZoomViewModel : ViewModelBase
    {
        /// <summary></summary>
        private DispatcherTimer _timer = null;
        /// <summary>
        /// 
        /// </summary>
        public IEZoomViewModel()
        {
            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            _timer.Tick += (s, e) =>
            {
                if (!IsAutoZoom)
                {
                    return;
                }

                ExecuteCommand("AutoZoom");
            };
            _timer.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Ie> InternetExplorers { get; } = new ObservableCollection<Ie>();
        /// <summary>
        /// 
        /// </summary>
        private int _Percent = 82;
        public int Percent
        {
            get { return _Percent; }
            set { SetProperty(ref _Percent, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private Ie _SelectedItem;
        public Ie SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(ref _SelectedItem, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Filter = "";
        public string Filter
        {
            get { return _Filter; }
            set { SetProperty(ref _Filter, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private bool _IsAutoZoom = false;
        public bool IsAutoZoom
        {
            get { return _IsAutoZoom; }
            set { SetProperty(ref _IsAutoZoom, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public void Refresh()
        {
            InternetExplorers.Clear();

            Regex filter = null;
            if (!string.IsNullOrEmpty(Filter))
            {
                filter = new Regex(Filter);
            }

            foreach (object window in new ShellWindows())
            {
                try
                {
                    if (!(window is InternetExplorer ie))
                    {
                        continue;
                    }

                    if (!(ie.Document is HTMLDocument doc))
                    {
                        continue;
                    }

                    if (filter != null && !filter.IsMatch(ie.LocationURL))
                    {
                        continue;
                    }

                    InternetExplorers.Add(new Ie(ie));
                }
                catch
                {
                    // 起動中にぶつかると COM エラーが出る
                }
            }
        }
    }
}
