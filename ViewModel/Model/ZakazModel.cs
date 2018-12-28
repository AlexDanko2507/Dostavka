using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel.Model
{
    class ZakazModel : INotifyPropertyChanged
    {
        private int id { get; set; }
        private int? dostavka { get; set; }
        private string dostavkaName { get; set; }
        private DateTime? dataVruchenia { get; set; }
        private int client { get; set; }
        private string clientName { get; set; }
        private double km { get; set; }                
        private string gruz { get; set; }    
        private int tip_gruza { get; set; }
        private string tip_gruzaName { get; set; }
        private double price_gruz { get; set; }
        private int status { get; set; }
        private string statusName { get; set; }
        private int Operatorr { get; set; }
        private string OperatorrName { get; set; }
        private string adressDostavki { get; set; }
        private DateTime dataOformleniya { get; set; }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public int? Dostavka
        {
            get { return dostavka; }
            set
            {
                dostavka = value;
                OnPropertyChanged("Dostavka");
            }
        }

        public string DostavkaName
        {
            get { return dostavkaName; }
            set
            {
                dostavkaName = value;
                OnPropertyChanged("DostavkaName");
            }
        }

        public DateTime? DataVruchenia
        {
            get { return dataVruchenia; }
            set
            {
                dataVruchenia = value;
                OnPropertyChanged("DataVruchenia");
            }
        }

        public DateTime DataOformleniya
        {
            get { return dataOformleniya; }
            set
            {
                dataOformleniya = value;
                OnPropertyChanged("DataOformleniya");
            }
        }

        public int Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged("Client");
            }
        }

        public string ClientName
        {
            get { return clientName; }
            set
            {
                clientName = value;
                OnPropertyChanged("ClientName");
            }
        }

        public double Km
        {
            get { return km; }
            set
            {
                km = value;
                OnPropertyChanged("Km");
            }
        }

        public string Gruz
        {
            get { return gruz; }
            set
            {
                gruz = value;
                OnPropertyChanged("Gruz");
            }
        }

        public string AdressDostavki
        {
            get { return adressDostavki; }
            set
            {
                adressDostavki = value;
                OnPropertyChanged("AdressDostavki");
            }
        }

        public int Tip_gruza
        {
            get { return tip_gruza; }
            set
            {
                tip_gruza = value;
                OnPropertyChanged("Tip_gruza");
            }
        }

        public string Tip_gruzaName
        {
            get { return tip_gruzaName; }
            set
            {
                tip_gruzaName = value;
                OnPropertyChanged("Tip_gruzaName");
            }
        }

        public double Price_gruz
        {
            get { return price_gruz; }
            set
            {
                price_gruz = value;
                OnPropertyChanged("Price_gruz");
            }
        }

        public int Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }

        public string StatusName
        {
            get { return statusName; }
            set
            {
                statusName = value;
                OnPropertyChanged("StatusName");
            }
        }

        public int Operator
        {
            get { return Operatorr; }
            set
            {
                Operatorr = value;
                OnPropertyChanged("Operator");
            }
        }

        public string OperatorName
        {
            get { return OperatorrName; }
            set
            {
                OperatorrName = value;
                OnPropertyChanged("OperatorName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
