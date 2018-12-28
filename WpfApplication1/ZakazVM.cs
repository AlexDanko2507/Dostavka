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
        public TransportTabVM tr { get; set; }
        public CourierTabVM cr { get; set; }
        public OperatorTabVM or { get; set; }
        public ZakazTabVM zr { get; set; }

        public ZakazVM(DBConnection db)
        {
            this.db = db;
            tr = new TransportTabVM(db);
            cr = new CourierTabVM(db);
            or = new OperatorTabVM(db);
            zr = new ZakazTabVM(db);
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

        private RelayCommand onOtchet;
        public RelayCommand OnOtchet
        {
            get
            {
                return onOtchet ??
                    (onOtchet = new RelayCommand(obj =>
                    {
                        otchetClient o = new otchetClient();
                        o.DataContext = new otchetClientVM(db, SelectedClient.Id);
                        o.ShowDialog();
                    }));
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
                        Client client = new Client();
                        cl.Insert(0, client);
                        SelectedClient = client;
                        SelectedClient.FirstName = "New";
                        SelectedClient.LastName = "New";
                        SelectedClient.MiddleName = "New";
                        SelectedClient.Phone = "New";
                        SelectedClient.Skidka = 0;
                        SelectedClient.HappyBirthday = DateTime.Today;
                        SelectedClient.Adress = "New";
                        db.Client.Add(SelectedClient);
                        db.SaveChanges();
                        MessageBox.Show("Добавлена новая запись! Заполните данные!");
                        //cl = new ObservableCollection<Client>(db.Client);
                    }));
            }
        }

        private RelayCommand saveClient;
        public RelayCommand SaveClient
        {
            get
            {
                return saveClient ??
                    (saveClient = new RelayCommand(obj =>
                    {
                        //db.Client.Add(SelectedClient);
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены");
                        //cl = new ObservableCollection<Client>(db.Client);
                    }));
            }
        }

        private RelayCommand delClient;
        public RelayCommand DelClient
        {
            get
            {
                return delClient ??
                    (delClient = new RelayCommand(obj =>
                    {
                        //Client client = new Client() { FirstName = "Новый Клиент" };
                        //cl.Insert(0, client);
                        //SelectedClient = client;
                        //MessageBox.Show("Новая услуга добавлена!");
                        db.Client.Local.Remove(SelectedClient);
                        cl.Remove(SelectedClient);
                        db.SaveChanges();
                        //cl = new ObservableCollection<Client>(db.Client);
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
