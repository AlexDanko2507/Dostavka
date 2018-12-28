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
    class DostavkaVM : INotifyPropertyChanged
    {
        DBConnection db;
        public ObservableCollection<Model.Zakaz> mZakaz { get; set; }
        public List<Model.Zakaz> userZakaz { get; set; }
        public List<Model.Zakaz> allFreeZakaz { get; set; }

        public DostavkaVM(DBConnection db, string user)
        {
            this.db = db;
            UserName = user;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            //userZakaz = mZakaz.Where(i => i.Dostavka1 == db.Courier.Where(j => j.Login == UserName).FirstOrDefault().Dostavka.FirstOrDefault()).ToList();
            userZakaz = mZakaz.Where(i => i.Dostavka1 != null).ToList().Where(j => j.Dostavka1.Courier1.Login == UserName).ToList().Where(k => k.Status == 2).ToList(); 
            allFreeZakaz = mZakaz.Where(i => i.Status == 1).ToList();
        }

        public List<Model.Zakaz> MZakaz
        {
            get { return allFreeZakaz; }
            set
            {
                allFreeZakaz = value;
                OnPropertyChanged("MZakaz");
            }
        }

        public List<Model.Zakaz> MZakaz2
        {
            get { return userZakaz; }
            set
            {
                userZakaz = value;
                OnPropertyChanged("MZakaz2");
            }
        }

        public Model.Zakaz SelectedZakaz { get; set; }
        public Model.Zakaz SelectedZakaz2 { get; set; }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged("userName");
            }
        }

        private RelayCommand doneMeZakaz;
        public RelayCommand DoneMeZakaz
        {
            get
            {
                return doneMeZakaz ??
                    (doneMeZakaz = new RelayCommand(obj =>
                    {
                        db.Zakaz.Find(SelectedZakaz2.Id).Status = 3;
                        db.Zakaz.Find(SelectedZakaz2.Id).DataVruchenia = DateTime.Now;
                        db.SaveChanges();
                        //MZakaz = new List<Model.Zakaz>(db.Zakaz);
                        MZakaz2 = new List<Model.Zakaz>(mZakaz.Where(i => i.Dostavka1 != null).ToList().Where(j => j.Dostavka1.Courier1.Login == UserName).ToList().Where(k => k.Status == 2).ToList());
                    }, obj => (SelectedZakaz2 != null)));
            }
        }
        private RelayCommand addMeZakaz;
        public RelayCommand AddMeZakaz
        {
            get
            {
                return addMeZakaz ??
                    (addMeZakaz = new RelayCommand(obj =>
                    {
                        Dostavka d = new Dostavka();
                        d.Courier = db.Courier.Where(i => i.Login == UserName).FirstOrDefault().Id;
                        d.Data_viezda = DateTime.Now;
                        d.Transport = 1;
                        d.OplataZaKm = 100;
                        db.Dostavka.Add(d);
                        db.SaveChanges();
                        db.Zakaz.Find(SelectedZakaz.Id).Status = 2;
                        db.Zakaz.Find(SelectedZakaz.Id).Dostavka = d.Id;
                        db.SaveChanges();
                        //MZakaz = new List<Model.Zakaz>(db.Zakaz);
                        MZakaz = new List<Model.Zakaz>(db.Zakaz.Where(i => i.Status == 1).ToList());
                        MZakaz2 = new List<Model.Zakaz>(mZakaz.Where(i => i.Dostavka1 != null).ToList().Where(j => j.Dostavka1.Courier1.Login == UserName).ToList().Where(k => k.Status == 2).ToList());
                    }, obj => (SelectedZakaz != null)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
}
