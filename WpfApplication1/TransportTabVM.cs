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
    class TransportTabVM : INotifyPropertyChanged
    {
        DBConnection db;
        private Tip_gruza selectedTipGruza;
        private Transport selectedTransort;
        public ObservableCollection<Transport> transport { get; set; }
        public ObservableCollection<Tip_gruza> tipgruza { get; set; }

        public TransportTabVM(DBConnection db)
        {
            this.db = db;
            transport = new ObservableCollection<Transport>(db.Transport);
            tipgruza = new ObservableCollection<Tip_gruza>(db.Tip_gruza);
            SelectedTransport = db.Transport.FirstOrDefault();
        }

        public Transport SelectedTransport
        {
            get { return selectedTransort; }
            set
            {
                selectedTransort = value;
                OnPropertyChanged("SelectedTransport");
            }
        }

        private RelayCommand addTransport;
        public RelayCommand AddTransport
        {
            get
            {
                return addTransport ??
                    (addTransport = new RelayCommand(obj =>
                    {
                        Transport tran = new Transport();
                        transport.Insert(0, tran);
                        SelectedTransport = tran;
                        SelectedTransport.Mark = "New";
                        SelectedTransport.Number = "New";
                        db.Transport.Add(SelectedTransport);
                        db.SaveChanges();
                        MessageBox.Show("Добавлена новая запись! Заполните данные!");
                    }));
            }
        }

        private RelayCommand saveTransport;
        public RelayCommand SaveTransport
        {
            get
            {
                return saveTransport ??
                    (saveTransport = new RelayCommand(obj =>
                    {
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены");
                    }));
            }
        }

        private RelayCommand delTransport;
        public RelayCommand DelTransport
        {
            get
            {
                return delTransport ??
                    (delTransport = new RelayCommand(obj =>
                    {
                        db.Transport.Local.Remove(SelectedTransport);
                        transport.Remove(SelectedTransport);
                        db.SaveChanges();
                    }));
            }
        }

        public Tip_gruza SelectedTipGruza
        {
            get { return selectedTipGruza; }
            set
            {
                selectedTipGruza = value;
                OnPropertyChanged("SelectedTipGruza");
            }
        }

        private RelayCommand addTipGruza;
        public RelayCommand AddTipGruza
        {
            get
            {
                return addTipGruza ??
                    (addTipGruza = new RelayCommand(obj =>
                    {
                        Tip_gruza tp = new Tip_gruza();
                        tipgruza.Insert(0, tp);
                        SelectedTipGruza = tp;
                        SelectedTipGruza.Name = "New";
                        SelectedTipGruza.K = 0;
                        db.Tip_gruza.Add(SelectedTipGruza);
                        db.SaveChanges();
                        MessageBox.Show("Добавлена новая запись! Заполните данные!");
                    }));
            }
        }

        private RelayCommand saveTipGruza;
        public RelayCommand SaveTipGruza
        {
            get
            {
                return saveTipGruza ??
                    (saveTipGruza = new RelayCommand(obj =>
                    {
                        db.SaveChanges();
                        MessageBox.Show("Изменения сохранены");
                    }));
            }
        }

        private RelayCommand delTipGruza;
        public RelayCommand DelTipGruza
        {
            get
            {
                return delTipGruza ??
                    (delTipGruza = new RelayCommand(obj =>
                    {
                        db.Tip_gruza.Local.Remove(SelectedTipGruza);
                        tipgruza.Remove(SelectedTipGruza);
                        db.SaveChanges();
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
