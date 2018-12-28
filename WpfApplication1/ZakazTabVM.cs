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
    class ZakazTabVM : INotifyPropertyChanged
    {
        DBConnection db;
        public zakazVobrabotkeVM z1 { get; set; }
        public zakazDostStartVM z2 { get; set; }
        public zakazDostEndVM z3 { get; set; }
        public zakazCancelVM z4 { get; set; }

        public ZakazTabVM(DBConnection db)
        {
            this.db = db;
            z1 = new zakazVobrabotkeVM(db);
            z2 = new zakazDostStartVM(db);
            z3 = new zakazDostEndVM(db);
            z4 = new zakazCancelVM(db);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
