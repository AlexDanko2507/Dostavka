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
    class ZakazVM : INotifyPropertyChanged
    {
        DBConnection db;
        private Client selectedClient;
        public ObservableCollection<Client> cl { get; set; }

        public ZakazVM(DBConnection db)
        {
            this.db = db;
            cl = new ObservableCollection<Client>(db.Client);
            SelectedClient = db.Client.FirstOrDefault();
        }

        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        private RelayCommand addClient;
        public RelayCommand AddClient
        {
            get
            {
                return addClient ??
                    (addClient = new RelayCommand(obj =>
                    {
                        Client client = new Client() { FirstName = "Новый Клиент" };
                        cl.Insert(0, client);
                        SelectedClient = client;
                        MessageBox.Show("Новая услуга добавлена!");
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
