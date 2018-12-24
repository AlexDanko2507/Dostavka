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
    class LoginVM : INotifyPropertyChanged, IRequireViewIdentification
    {
        public DBConnection db = new DBConnection();
        public Guid ViewID { get; }
        public ObservableCollection<Operator> op { get; set; }
        public ObservableCollection<Courier> c { get; set; }

        public LoginVM()
        {
            ViewID = Guid.NewGuid();
            op = new ObservableCollection<Operator>(db.Operator);
            c = new ObservableCollection<Courier>(db.Courier);
        }

        private string login;
        public string Login
        {
            get { return login; }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }


        private RelayCommand password;
        public RelayCommand Password
        {
            get
            {
                return password ??
                    (password = new RelayCommand(obj =>
                    {
                        var passwordBox = obj as PasswordBox;
                        if (passwordBox != null)
                        {
                            var selectedOperator = op.Where(u => u.Login.TrimEnd() == Login && u.Password.Trim() == passwordBox.Password);
                            var selectedCourier = c.Where(u => u.Login.TrimEnd() == Login && u.Password.Trim() == passwordBox.Password);

                            if (selectedCourier.Count() > 0 || selectedOperator.Count() > 0 || (Login=="admin" && passwordBox.Password == "admin")) // если такая запись существует
                            {
                                if (Login == "admin" && passwordBox.Password == "admin")
                                {
                                    Zakaz main = new Zakaz();

                                    WindowMeneger.CloseWindow(ViewID);
                                    main.DataContext = new ZakazVM(db);
                                    main.Show();
                                }
                                else if (selectedOperator.Count() > 0)
                                {
                                    CourierWindow main = new CourierWindow();

                                    WindowMeneger.CloseWindow(ViewID);
                                    main.DataContext = new CourierVM(db, Login);
                                    main.Show();
                                }
                                else
                                {
                                    MainWindow main = new MainWindow();

                                    WindowMeneger.CloseWindow(ViewID);
                                    //main.DataContext = new MainViewModel1(db);
                                    main.Show();
                                }
                            }

                            else MessageBox.Show("Ошибка при входе! Повторите ввод"); // выводим ошибку
                        }
                    }, obj => (Login != null && (obj as PasswordBox).Password != null)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
