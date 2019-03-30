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
        private Settings _settings;
        /// <summary></summary>
        private DispatcherTimer _timer;
        /// <summary>
        /// 
        /// </summary>
        public IEZoomViewModel()
        {
            _settings = Settings.Load();

            _timer = new DispatcherTimer()
            {
                Interval = TimeSpan.FromSeconds(10)
            };
            _timer.Tick += (s, e) =>
            {
                if (IsAutoZoom)
                {
                    ExecuteCommand("AutoZoom");
                }
            };
            _timer.Start();
        }
        /// <summary>
        /// 
        /// </summary>
        public int Percent
        {
            get { return _settings.Percent; }
            set { SetProperty(ref _settings.Percent, value, () => { _settings.IsChanged = true; }); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Filter
        {
            get { return _settings.Filter; }
            set { SetProperty(ref _settings.Filter, value, () => { _settings.IsChanged = true; }); }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsAutoZoom
        {
            get { return _settings.IsAutoZoom; }
            set { SetProperty(ref _settings.IsAutoZoom, value, () => { _settings.IsChanged = true; }); }
        }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Ie> InternetExplorers { get; } = new ObservableCollection<Ie>();
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

            SaveSettings();
        }
        /// <summary>
        /// 
        /// </summary>
        public void SaveSettings()
        {
            if (_settings.IsChanged)
            {
                _settings.Save();
            }
        }
    }
}
