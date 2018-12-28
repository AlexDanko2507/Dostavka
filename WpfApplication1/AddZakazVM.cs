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
    class AddZakazVM : INotifyPropertyChanged, IRequireViewIdentification
    {
        DBConnection db;
        public Guid ViewID { get; }
        bool check = false;
        private string user;
        private Model.Zakaz selectedZakaz;
        private Model.Zakaz checkZ;
        private Tip_gruza tipgruza;
        public ObservableCollection<Model.Zakaz> cl { get; set; }
        public ObservableCollection<Tip_gruza> tipg { get; set; }
        public ObservableCollection<Client> clients { get; set; }
        public ObservableCollection<Operator> op { get; set; }

        public AddZakazVM(DBConnection db, string login)
        {
            this.db = db;
            user = login;
            cl = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            tipg = new ObservableCollection<Tip_gruza>(db.Tip_gruza);
            clients = new ObservableCollection<Client>(db.Client);
            SelectedZakaz = db.Zakaz.FirstOrDefault();
        }

        public AddZakazVM(DBConnection db, string login, Model.Zakaz z)
        {
            this.db = db;
            user = login;
            checkZ = z;
            cl = new ObservableCollection<Model.Zakaz>(db.Zakaz);
            tipg = new ObservableCollection<Tip_gruza>(db.Tip_gruza);
            clients = new ObservableCollection<Client>(db.Client);
            SelectedZakaz = db.Zakaz.FirstOrDefault();
            FirstName = z.Client1.FirstName;
            LastName = z.Client1.LastName;
            MiddleName = z.Client1.MiddleName;
            Phone = z.Client1.Phone;
            Adress = z.Client1.Adress;
            Date = z.Client1.HappyBirthday;
            AdressDostavki = z.AdressDostavki;
            SelectedTipGruza = z.Tip_gruza1;
            Gruz = z.Gruz;
            Km = Convert.ToString(z.Km);
            //PriceGruz = Convert.ToString(z.Price_gruz);
        }

        public Tip_gruza SelectedTipGruza
        {
            get { return tipgruza; }
            set
            {
                tipgruza = value;
                OnPropertyChanged("SelectedTipGruza");
            }
        }

        public Model.Zakaz SelectedZakaz
        {
            get { return selectedZakaz; }
            set
            {
                selectedZakaz = value;
                OnPropertyChanged("SelectedZakaz");
            }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string middleName;
        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }
        private string adress;
        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }

        private string adressDostavki;
        public string AdressDostavki
        {
            get { return adressDostavki; }
            set
            {
                adressDostavki = value;
                OnPropertyChanged("AdressDostavki");
            }
        }

        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private string gruz;
        public string Gruz
        {
            get { return gruz; }
            set
            {
                gruz = value;
                OnPropertyChanged("Gruz");
            }
        }

        private string km;
        public string Km
        {
            get { return km; }
            set
            {
                km = value;
                OnPropertyChanged("Km");
            }
        }

        private string priceGruz;
        public string PriceGruz
        {
            get { return priceGruz; }
            set
            {
                priceGruz = value;
                OnPropertyChanged("PriceGruz");
            }
        }


        private RelayCommand checkClient;
        public RelayCommand CheckClient
        {
            get
            {
                return checkClient ??
                    (checkClient = new RelayCommand(obj =>
                    {
                        var cll = db.Client.Where(i => i.Phone == Phone).FirstOrDefault();
                        if(cll != null)
                        {
                            check = true;
                            FirstName = cll.FirstName;
                            LastName = cll.LastName;
                            MiddleName = cll.MiddleName;
                            Adress = cll.Adress;
                            Date = cll.HappyBirthday;
                        }
                        else
                        {
                            MessageBox.Show("Клиент не найден!");
                        }
                    }));
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
                    if (AdressDostavki != null && SelectedTipGruza != null && FirstName != null && LastName != null && Phone != null && Date != null && Adress != null && Gruz != null && Km != null)
                    {
                        if (checkZ == null)
                        {
                            var tp = db.Tip_gruza.Find(SelectedTipGruza.Id);
                            var o = db.Operator.Where(i => i.Login == user).FirstOrDefault().Id;
                            Model.Zakaz z = new Model.Zakaz();
                            if (!check)
                            {
                                Client c = new Client();
                                c.FirstName = FirstName;
                                c.LastName = LastName;
                                c.MiddleName = middleName;
                                c.Phone = Phone;
                                c.HappyBirthday = Date;
                                c.Adress = Adress;
                                c.Skidka = 5;
                                db.Client.Add(c);
                                db.SaveChanges();
                                z.Client = c.Id;
                            }
                            else
                            {
                                var ck = db.Client.Where(i => i.Phone == Phone).FirstOrDefault();
                                z.Client = ck.Id;
                            }

                            z.Gruz = Gruz;
                            z.Tip_gruza = tp.Id;
                            z.Km = Convert.ToInt32(Km);
                            z.Price_gruz = tp.K * z.Km;
                            z.Status = 1;
                            z.Operator = o;
                            z.AdressDostavki = AdressDostavki;
                            z.DataOformleniya = DateTime.Now;
                            db.Zakaz.Add(z);
                            db.SaveChanges();
                            WindowMeneger.CloseWindow(ViewID);
                        }
                        else
                        {
                            db.Zakaz.Find(checkZ.Id).Client1.FirstName = FirstName;
                            db.Zakaz.Find(checkZ.Id).Client1.LastName = LastName;
                            db.Zakaz.Find(checkZ.Id).Client1.MiddleName = MiddleName;
                            db.Zakaz.Find(checkZ.Id).Client1.Adress = Adress;
                            db.Zakaz.Find(checkZ.Id).Gruz = Gruz;
                            db.Zakaz.Find(checkZ.Id).Tip_gruza = db.Tip_gruza.Find(SelectedTipGruza.Id).Id;
                            db.Zakaz.Find(checkZ.Id).Km = Convert.ToInt32(Km);
                            db.Zakaz.Find(checkZ.Id).Price_gruz = Convert.ToDouble(PriceGruz);
                            db.Zakaz.Find(checkZ.Id).AdressDostavki = AdressDostavki;
                            db.SaveChanges();
                            WindowMeneger.CloseWindow(ViewID);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля! Отмеченные *");
                    }
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
