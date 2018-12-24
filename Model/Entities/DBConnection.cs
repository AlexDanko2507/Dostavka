namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBConnection : DbContext
    {
        public DBConnection()
            : base("name=DBConnection")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Courier> Courier { get; set; }
        public virtual DbSet<Dostavka> Dostavka { get; set; }
        public virtual DbSet<Operator> Operator { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tip_gruza> Tip_gruza { get; set; }
        public virtual DbSet<Transport> Transport { get; set; }
        public virtual DbSet<Zakaz> Zakaz { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Client1)
                .HasForeignKey(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Courier>()
                .HasMany(e => e.Dostavka)
                .WithRequired(e => e.Courier1)
                .HasForeignKey(e => e.Courier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dostavka>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Dostavka1)
                .HasForeignKey(e => e.Dostavka)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Operator>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Operator1)
                .HasForeignKey(e => e.Operator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Status1)
                .HasForeignKey(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tip_gruza>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Tip_gruza>()
                .HasMany(e => e.Zakaz)
                .WithRequired(e => e.Tip_gruza1)
                .HasForeignKey(e => e.Tip_gruza)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Transport>()
                .Property(e => e.Mark)
                .IsUnicode(false);

            modelBuilder.Entity<Transport>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<Transport>()
                .HasMany(e => e.Dostavka)
                .WithRequired(e => e.Transport1)
                .HasForeignKey(e => e.Transport)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Zakaz>()
                .Property(e => e.Gruz)
                .IsUnicode(false);

            modelBuilder.Entity<Zakaz>()
            .Property(e => e.AdressDostavki)
            .IsUnicode(false);
        }
    }
}
