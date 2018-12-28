namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Zakaz")]
    public partial class Zakaz
    {
        public int Id { get; set; }

        public int? Dostavka { get; set; }

        public DateTime? DataVruchenia { get; set; }

        public int Client { get; set; }

        public double Km { get; set; }

        [Required]
        [StringLength(70)]
        public string Gruz { get; set; }

        public int Tip_gruza { get; set; }

        public double Price_gruz { get; set; }

        public int Status { get; set; }

        public int Operator { get; set; }

        public virtual Client Client1 { get; set; }

        public virtual Dostavka Dostavka1 { get; set; }

        public virtual Operator Operator1 { get; set; }

        public virtual Status Status1 { get; set; }

        public virtual Tip_gruza Tip_gruza1 { get; set; }

        [Required]
        [StringLength(150)]
        public string AdressDostavki { get; set; }

        public DateTime DataOformleniya { get; set; }
    }
}
