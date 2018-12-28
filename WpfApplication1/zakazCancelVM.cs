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
    class zakazCancelVM : INotifyPropertyChanged
    {
        DBConnection db;
        public ObservableCollection<Model.Zakaz> mZakaz { get; set; }
        public List<Model.Zakaz> allZakazCancel { get; set; }

        public zakazCancelVM(DBConnection db)
        {
            this.db = db;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            allZakazCancel = mZakaz.Where(i => i.Status == 4).ToList();
            Count = Convert.ToString(allZakazCancel.Count);
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
            get { return allZakazCancel; }
            set
            {
                allZakazCancel = value;
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
