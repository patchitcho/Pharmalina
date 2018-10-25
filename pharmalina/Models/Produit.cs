using System;
using System.Collections.Generic;

namespace pharmalina.Models
{
    public partial class Produit
    {
        public Produit()
        {
            Lot = new HashSet<Lot>();
        }

        public int Cleproduit { get; set; }
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

        public ICollection<Lot> Lot { get; set; }
    }
}
