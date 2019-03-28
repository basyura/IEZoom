using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using IEZoom.Models;
using SHDocVw;

namespace IEZoom.ViewModels
{
    public class IEZoomViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        private int _Percent = 80;
        public int Percent
        {
            get { return _Percent; }
            set { _Percent = value;
                 RaisePropertyChanged();
            }
        }


        /// <summary></summary>
        private Ie _SelectedItem;
        public Ie SelectedItem
        {
            get { return _SelectedItem; }
            set
            {
                _SelectedItem = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Ie> InternetExplorers { get; } = new ObservableCollection<Ie>();
    }
}
