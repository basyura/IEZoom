using System.Collections.ObjectModel;
using Eleve;
using IEZoom.Models;

namespace IEZoom.ViewModels
{
    public class IEZoomViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        private int _Percent = 82;
        public int Percent
        {
            get { return _Percent; }
            set { _Percent = value;
                 RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
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
        private string _Filter = "";
        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Ie> InternetExplorers { get; } = new ObservableCollection<Ie>();
    }
}
