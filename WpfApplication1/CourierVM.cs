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
    class CourierVM : INotifyPropertyChanged
    {
        DBConnection db;
        public ObservableCollection<Model.Zakaz> mZakaz { get; set; }
        //public List<Model.Zakaz> userZakaz { get; set; }
            
        public CourierVM(DBConnection db, string user)
        {
            this.db = db;
            UserName = user;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            //userZakaz = mZakaz.Where(i => i.Operator1.Login == UserName).ToList();
        }

        public ObservableCollection<Model.Zakaz> MZakaz
        {
            get { return mZakaz; }
            set
            {
                mZakaz = value;
                OnPropertyChanged("MZakaz");
            }
        }

        public Model.Zakaz SelectedZakaz { get; set; }

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

        private RelayCommand addZakaz;
        public RelayCommand AddZakaz
        {
            get
            {
                return addZakaz ??
                    (addZakaz = new RelayCommand(obj =>
                    {
                        AddZakaz c = new AddZakaz();
                        c.DataContext = new AddZakazVM(db, UserName);
                        c.ShowDialog();
                        db.SaveChanges();
                        //MZakaz = new List<Model.Zakaz>(db.Zakaz);
                        MZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
                    }));
            }
        }

        private RelayCommand updateZakaz;
        public RelayCommand UpdateZakaz
        {
            get
            {
                return updateZakaz ??
                    (updateZakaz = new RelayCommand(obj =>
                    {
                        AddZakaz c = new AddZakaz();
                        c.DataContext = new AddZakazVM(db, UserName, SelectedZakaz);
                        c.ShowDialog();
                        db.SaveChanges();
                        //MZakaz = new List<Model.Zakaz>(db.Zakaz);
                        MZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
                    }));
            }
        }

        private RelayCommand cancelZakaz;
        public RelayCommand CancelZakaz
        {
            get
            {
                return cancelZakaz ??
                    (cancelZakaz = new RelayCommand(obj =>
                    {
                        db.Zakaz.Find(SelectedZakaz.Id).Status = 4;
                        db.SaveChanges();
                        //MZakaz = new List<Model.Zakaz>(db.Zakaz);
                        MZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
                    }));
            }
        }

        private RelayCommand delZakaz;
        public RelayCommand DelZakaz
        {
            get
            {
                return delZakaz ??
                    (delZakaz = new RelayCommand(obj =>
                    {
                        db.Zakaz.Local.Remove(SelectedZakaz);
                        mZakaz.Remove(SelectedZakaz);
                        db.SaveChanges();
                        //MZakaz = new List<Model.Zakaz>(db.Zakaz);
                        MZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
                    }, obj => (SelectedZakaz != null)));
            }
        }

        public bool CanExecute(object parameter)
        {
            return SelectedZakaz != null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
