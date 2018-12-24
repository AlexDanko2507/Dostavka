using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel.Model
{
    class DostavkaModel : INotifyPropertyChanged
    {
        private int id { get; set; }
        private int courier { get; set; }
        private string courierName { get; set; }
        private DateTime data_viezda { get; set; }
        private int transport { get; set; }
        private string transportName { get; set; }
        private double oplataZaKm { get; set; }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int Courier
        {
            get { return courier; }
            set
            {
                courier = value;
                OnPropertyChanged("Courier");
            }
        }

        public string CourierName
        {
            get { return courierName; }
            set
            {
                courierName = value;
                OnPropertyChanged("CourierName");
            }
        }

        public DateTime Data_viezda
        {
            get { return data_viezda; }
            set
            {
                data_viezda = value;
                OnPropertyChanged("Data_viezda");
            }
        }

        public int Transport
        {
            get { return transport; }
            set
            {
                transport = value;
                OnPropertyChanged("Transport");
            }
        }

        public string TransportName
        {
            get { return transportName; }
            set
            {
                transportName = value;
                OnPropertyChanged("TransportName");
            }
        }

        public double OplataZaKm
        {
            get { return oplataZaKm; }
            set
            {
                oplataZaKm = value;
                OnPropertyChanged("OplataZaKm");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
