using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ViewModel.Model;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace ViewModel
{
    class DBOperation
    {
        DBConnection db;
        public DBOperation()
        {
            db = new DBConnection();
            db.Client.Load();
            db.Courier.Load();
            db.Dostavka.Load();
            db.Operator.Load();
            db.Status.Load();
            db.Tip_gruza.Load();
            db.Transport.Load();
            db.Zakaz.Load();
        }

        public List<ClientModel> GetAllClient()
        {
            return db.Client.Local.Select(i => toClientModel(i)).ToList();
        }

        public ClientModel toClientModel(Client i)
        {
            return new ClientModel
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                MiddleName = i.MiddleName,
                Adress = i.Adress,
                HappyBirthday = i.HappyBirthday,
                Phone = i.Phone,
                Skidka = i.Skidka,
            };
        }

        public List<CourierModel> GetAllCourier()
        {
            return db.Courier.Local.Select(i => toCouriertModel(i)).ToList();
        }

        private CourierModel toCouriertModel(Courier i)
        {
            return new CourierModel
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                MiddleName = i.MiddleName,
                Phone = i.Phone,
                Login = i.Login,
                Password = i.Password
            };
        }

        public List<OperatorModel> GetAllOperator()
        {
            return db.Operator.Local.Select(i => toOperatorModel(i)).ToList();
        }

        private OperatorModel toOperatorModel(Operator i)
        {
            return new OperatorModel
            {
                Id = i.Id,
                FirstName = i.FirstName,
                LastName = i.LastName,
                MiddleName = i.MiddleName,
                Login = i.Login,
                Password = i.Password
            };
        }

        public List<StatusModel> GetAllStatus()
        {
            return db.Status.Local.Select(i => toStatusModel(i)).ToList();
        }

        private StatusModel toStatusModel(Status i)
        {
            return new StatusModel
            {
                Id = i.Id,
                Name = i.Name
            };
        }

        public List<TipGruzaModel> GetAllTipGruza()
        {
            return db.Tip_gruza.Local.Select(i => toTipGruzatModel(i)).ToList();
        }

        private TipGruzaModel toTipGruzatModel(Tip_gruza i)
        {
            return new TipGruzaModel
            {
                Id = i.Id,
                Name = i.Name,
                K = i.K,
            };
        }

        public List<TransportModel> GetAllTransport()
        {
            return db.Transport.Local.Select(i => toTransportModel(i)).ToList();
        }

        private TransportModel toTransportModel(Transport i)
        {
            return new TransportModel
            {
                Id = i.Id,
                Mark = i.Mark,
                Number = i.Number
            };
        }

        public List<DostavkaModel> GetAllDostavka()
        {
            return db.Dostavka.Local.Select(i => toDostavkaModel(i)).ToList();
        }

        private DostavkaModel toDostavkaModel(Dostavka i)
        {
            return new DostavkaModel
            {
                Id = i.Id,
                Courier = i.Courier,
                CourierName = db.Courier.Where(y => y.Id == i.Courier).FirstOrDefault().FirstName + ' ' + db.Courier.Where(y => y.Id == i.Courier).FirstOrDefault().LastName + ' ' + db.Courier.Where(y => y.Id == i.Courier).FirstOrDefault().MiddleName,
                Data_viezda = i.Data_viezda,
                OplataZaKm = i.OplataZaKm,
                Transport = i.Transport,
                TransportName = db.Transport.Where(y => y.Id == i.Transport).FirstOrDefault().Mark + ' ' + db.Transport.Where(y => y.Id == i.Transport).FirstOrDefault().Number
            };
        }

        public List<ZakazModel> GetAllZakaz()
        {
            return db.Zakaz.Local.Select(i => toZakazModel(i)).ToList();
        }

        private ZakazModel toZakazModel(Zakaz i)
        {
            return new ZakazModel
            {
                Id = i.Id,
                Client = i.Client,
                ClientName = db.Client.Where(y => y.Id == i.Client).FirstOrDefault().FirstName + ' ' + db.Client.Where(y => y.Id == i.Client).FirstOrDefault().LastName + ' ' + db.Client.Where(y => y.Id == i.Client).FirstOrDefault().MiddleName,
                DataVruchenia = i.DataVruchenia,
                Dostavka = i.Dostavka,
                DostavkaName = db.Dostavka.Where(y => y.Id == i.Dostavka).FirstOrDefault().Data_viezda.ToString(),
                Gruz = i.Gruz,
                Km = i.Km,
                Operator = i.Operator,
                OperatorName = db.Operator.Where(y => y.Id == i.Operator).FirstOrDefault().FirstName + ' ' + db.Operator.Where(y => y.Id == i.Operator).FirstOrDefault().LastName + ' ' + db.Operator.Where(y => y.Id == i.Operator).FirstOrDefault().MiddleName,
                Price_gruz = i.Price_gruz,
                Status = i.Status,
                StatusName = db.Status.Where(y => y.Id == i.Status).FirstOrDefault().Name,
                Tip_gruza = i.Tip_gruza,
                Tip_gruzaName = db.Tip_gruza.Where(y => y.Id == i.Tip_gruza).FirstOrDefault().Name
            };
        }

        public Client toClient(Client c, ClientModel c1)
        {
            c.Id = c1.Id;
            c.FirstName = c1.FirstName;
            c.LastName = c1.LastName;
            c.MiddleName = c1.MiddleName;
            c.Phone = c1.Phone;
            c.HappyBirthday = c1.HappyBirthday;
            c.Adress = c1.Adress;
            c.Skidka = c1.Skidka;
            return c;
        }

        public Transport toTransport(Transport t, TransportModel t1)
        {
            t.Id = t1.Id;
            t.Mark = t1.Mark;
            t.Number = t1.Number;
            return t;
        }

        public Zakaz toZakaz(Zakaz z, ZakazModel z1)
        {
            z.Id = z1.Id;
            z.Km = z1.Km;
            z.Gruz = z1.Gruz;
            z.Operator = z1.Operator;
            z.Price_gruz = z1.Price_gruz;
            z.Status = z1.Status;
            z.Tip_gruza = z1.Tip_gruza;
            z.Dostavka = z1.Dostavka;
            z.DataVruchenia = z1.DataVruchenia;
            z.Client = z1.Client;
            return z;
        }

        public Dostavka toDostavka(Dostavka d, DostavkaModel d1)
        {
            d.Courier = d1.Courier;
            d.Data_viezda = d1.Data_viezda;
            d.Id = d1.Id;
            d.OplataZaKm = d1.OplataZaKm;
            d.Transport = d1.Transport;
            return d;
        }

        public Courier toCourier(Courier c, CourierModel c1)
        {
            c.Id = c1.Id;
            c.LastName = c1.LastName;
            c.MiddleName = c1.MiddleName;
            c.FirstName = c1.FirstName;
            c.Phone = c1.Phone;
            c.Login = c1.Login;
            c.Password = c1.Password;
            return c;
        }

        public Operator toOperator(Operator o, OperatorModel o1)
        {
            o.Id = o1.Id;
            o.FirstName = o1.FirstName;
            o.LastName = o1.LastName;
            o.MiddleName = o1.MiddleName;
            o.Login = o1.Login;
            o.Password = o1.Password;
            return o;
        }

        public void addZakaz(ZakazModel z)
        {
            db.Zakaz.Add(toZakaz(new Zakaz(), z));
        }

        public void DeleteZakaz(ZakazModel s)
        {
            db.Zakaz.Remove(db.Zakaz.Find(s.Id));
        }

        public void UpdateZakaz(ZakazModel c)
        {
            Zakaz c1 = db.Zakaz.Where(i => i.Id == c.Id).FirstOrDefault();
            db.Entry(toZakaz(c1, c)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void addDostavka(DostavkaModel d)
        {
            db.Dostavka.Add(toDostavka(new Dostavka(), d));
        }

        public void DeleteDostavka(DostavkaModel s)
        {
            db.Dostavka.Remove(db.Dostavka.Find(s.Id));
        }

        public void UpdateDostavka(DostavkaModel c)
        {
            Dostavka c1 = db.Dostavka.Where(i => i.Id == c.Id).FirstOrDefault();
            db.Entry(toDostavka(c1, c)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void addClient(ClientModel z)
        {
            db.Client.Add(toClient(new Client(), z));
        }

        public void DeleteClient(ClientModel s)
        {
            db.Client.Remove(db.Client.Find(s.Id));
        }

        public void UpdateClient(ClientModel c)
        {
            Client c1 = db.Client.Where(i => i.Id == c.Id).FirstOrDefault();
            db.Entry(toClient(c1, c)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void addCourier(CourierModel z)
        {
            db.Courier.Add(toCourier(new Courier(), z));
        }

        public void DeleteCourier(CourierModel s)
        {
            db.Courier.Remove(db.Courier.Find(s.Id));
        }

        public void UpdateCourier(CourierModel c)
        {
            Courier c1 = db.Courier.Where(i => i.Id == c.Id).FirstOrDefault();
            db.Entry(toCourier(c1, c)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void addOperator(OperatorModel z)
        {
            db.Operator.Add(toOperator(new Operator(), z));
        }

        public void DeleteOperator(OperatorModel s)
        {
            db.Operator.Remove(db.Operator.Find(s.Id));
        }

        public void UpdateOperator(OperatorModel c)
        {
            Operator c1 = db.Operator.Where(i => i.Id == c.Id).FirstOrDefault();
            db.Entry(toOperator(c1, c)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void addTransport(TransportModel z)
        {
            db.Transport.Add(toTransport(new Transport(), z));
        }

        public void DeleteTransport(TransportModel s)
        {
            db.Transport.Remove(db.Transport.Find(s.Id));
        }

        public void UpdateTransport(TransportModel c)
        {
            Transport c1 = db.Transport.Where(i => i.Id == c.Id).FirstOrDefault();
            db.Entry(toTransport(c1, c)).State = EntityState.Modified;
            db.SaveChanges();
        }

        public ZakazModel GetZakaz(int Id)
        {
            return toZakazModel(db.Zakaz.Find(Id));
        }

        public DostavkaModel GetDostavka(int Id)
        {
            return toDostavkaModel(db.Dostavka.Find(Id));
        }

        public TransportModel GetTransport(int Id)
        {
            return toTransportModel(db.Transport.Find(Id));
        }

        public CourierModel GetCourier(int Id)
        {
            return toCouriertModel(db.Courier.Find(Id));
        }

        public OperatorModel GetOperator(int Id)
        {
            return toOperatorModel(db.Operator.Find(Id));
        }

        public ClientModel GetClient(int Id)
        {
            return toClientModel(db.Client.Find(Id));
        }

        public StatusModel GetStatus(int Id)
        {
            return toStatusModel(db.Status.Find(Id));
        }

        public TipGruzaModel GetTipGruza(int Id)
        {
            return toTipGruzatModel(db.Tip_gruza.Find(Id));
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
