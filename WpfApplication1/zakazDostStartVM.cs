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
    class zakazDostStartVM : INotifyPropertyChanged
    {
        DBConnection db;
        public ObservableCollection<Model.Zakaz> mZakaz { get; set; }
        public List<Model.Zakaz> allZakazStart { get; set; }

        public zakazDostStartVM(DBConnection db, int id)
        {
            this.db = db;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            allZakazStart = mZakaz.Where(i => i.Status == 2).Where(j => j.Client == id).ToList();
            Count = Convert.ToString(allZakazStart.Count);
        }

        public zakazDostStartVM(DBConnection db, string login)
        {
            this.db = db;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            allZakazStart = mZakaz.Where(i => i.Status == 2).Where(j => j.Dostavka1.Courier1.Login == login).ToList();
            Count = Convert.ToString(allZakazStart.Count);
        }

        public zakazDostStartVM(DBConnection db)
        {
            this.db = db;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            allZakazStart = mZakaz.Where(i => i.Status == 2).ToList();
            Count = Convert.ToString(allZakazStart.Count);
        }

        private string count;
        public string Count
        {
            get { return count; }
            set
            {
                count = value;
                OnPropertyChanged("Count");
            }
        }

        public List<Model.Zakaz> MZakaz
        {
            get { return allZakazStart; }
            set
            {
                allZakazStart = value;
                OnPropertyChanged("MZakaz");
            }
        }

        public Model.Zakaz SelectedZakaz { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
