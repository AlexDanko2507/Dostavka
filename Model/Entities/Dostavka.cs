namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dostavka")]
    public partial class Dostavka
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dostavka()
        {
            Zakaz = new HashSet<Zakaz>();
        }

        public int Id { get; set; }

        public int Courier { get; set; }

        public DateTime Data_viezda { get; set; }

        public int Transport { get; set; }

        public double OplataZaKm { get; set; }

        public virtual Courier Courier1 { get; set; }

        public virtual Transport Transport1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Zakaz> Zakaz { get; set; }
    }
}
