using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfApplication1;
using Model;

namespace WpfApplication1
{
    class CourierTabVM : INotifyPropertyChanged
    {
        DBConnection db;
        private Courier selectedCourier;
        public ObservableCollection<Courier> courier { get; set; }

        public CourierTabVM(DBConnection db)
        {
            this.db = db;
            courier = new ObservableCollection<Courier>(db.Courier);
            SelectedCourier = db.Courier.FirstOrDefault();
        }

        public Courier SelectedCourier
        {
            get { return selectedCourier; }
            set
            {
                selectedCourier = value;
                OnPropertyChanged("SelectedTransport");
            }
        }

        private RelayCommand onOtchet;
        public RelayCommand OnOtchet
        {
            get
            {
                return onOtchet ??
                    (onOtchet = new RelayCommand(obj =>
                    {
                        otchetCourier o = new otchetCourier();
                        o.DataContext = new otchetCourierVM(db, SelectedCourier.Login);
                        o.ShowDialog();
                    }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
