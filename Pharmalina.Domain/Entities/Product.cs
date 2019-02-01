using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pharmalina.Domain.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Reference { get; set; }
        public string Designation { get; set; }
        public string Remarque { get; set; }
        public string Fulldesignation { get; set; }
        public double Quantitealerte { get; set; }
        public double Quantitemax { get; set; }
        public string Unite { get; set; }
        public decimal Pmp { get; set; }
        public decimal Dernierprixdachat { get; set; }
        public decimal Prixdachatmin { get; set; }
        public decimal Prixdachatmax { get; set; }
        public decimal Prixdevente { get; set; }
        public decimal Prixdeventemin { get; set; }
        public decimal Prixdeventemax { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public User ModifiesBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public ICollection<Lot> Lot { get; set; }
    }
}
