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
    class zakazVobrabotkeVM : INotifyPropertyChanged
    {
        DBConnection db;
        public ObservableCollection<Model.Zakaz> mZakaz { get; set; }
        public List<Model.Zakaz> allZakazVobrabotke { get; set; }

        public zakazVobrabotkeVM(DBConnection db)
        {
            this.db = db;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            allZakazVobrabotke = mZakaz.Where(i => i.Status == 1).ToList();
            Count = Convert.ToString(allZakazVobrabotke.Count);
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
            get { return allZakazVobrabotke; }
            set
            {
                allZakazVobrabotke = value;
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
