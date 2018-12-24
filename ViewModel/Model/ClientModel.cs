using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModel.Model
{
    class ClientModel : INotifyPropertyChanged
    {
        private int id { get; set; }
        private string firstName { get; set; }
        private string lastName { get; set; }
        private string middleName { get; set; }
        private string adress { get; set; }
        private DateTime happyBirthday { get; set; }
        private string phone { get; set; }
        private double? skidka { get; set; }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {
                middleName = value;
                OnPropertyChanged("MiddleName");
            }
        }

        public string Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }

        public DateTime HappyBirthday
        {
            get { return happyBirthday; }
            set
            {
                happyBirthday = value;
                OnPropertyChanged("HappyBirthday");
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        public double? Skidka
        {
            get { return skidka; }
            set
            {
                skidka = value;
                OnPropertyChanged("Skidka");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
