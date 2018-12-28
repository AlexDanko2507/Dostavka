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
    class OperatorTabVM : INotifyPropertyChanged
    {
        DBConnection db;
        private Operator selectedOperator;
        public ObservableCollection<Operator> operat { get; set; }

        public OperatorTabVM(DBConnection db)
        {
            this.db = db;
            operat = new ObservableCollection<Operator>(db.Operator);
            SelectedOperator = db.Operator.FirstOrDefault();
        }

        public Operator SelectedOperator
        {
            get { return selectedOperator; }
            set
            {
                selectedOperator = value;
                OnPropertyChanged("SelectedOperator");
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
                        otchetOperator o = new otchetOperator();
                        o.DataContext = new otchetOperatorVM(db, SelectedOperator.Login);
                        o.ShowDialog();
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
