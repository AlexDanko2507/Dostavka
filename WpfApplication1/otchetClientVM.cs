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
    class otchetClientVM : INotifyPropertyChanged
    {
        DBConnection db;
        public zakazDostStartVM z2 { get; set; }
        public zakazDostEndVM z3 { get; set; }

        public otchetClientVM(DBConnection db, int id)
        {
            this.db = db;
            z2 = new zakazDostStartVM(db, id);
            z3 = new zakazDostEndVM(db, id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
