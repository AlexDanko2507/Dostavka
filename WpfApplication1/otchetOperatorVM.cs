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
    class otchetOperatorVM : INotifyPropertyChanged
    {
        DBConnection db;
        public ObservableCollection<Model.Zakaz> mZakaz { get; set; }
        public List<Model.Zakaz> operatorZakaz { get; set; }

        public otchetOperatorVM(DBConnection db, string login)
        {
            this.db = db;
            mZakaz = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            operatorZakaz = mZakaz.Where(i => i.Operator1.Login == login).ToList();
            Count = Convert.ToString(operatorZakaz.Count);
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
            get { return operatorZakaz; }
            set
            {
                operatorZakaz = value;
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
