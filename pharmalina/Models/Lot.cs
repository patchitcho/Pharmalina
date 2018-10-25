using System;
using System.Collections.Generic;

namespace pharmalina.Models
{
    public partial class Lot
    {
        public int Clelot { get; set; }
        public int Cleproduit { get; set; }
        public string Codelot { get; set; }
        public string Nlot { get; set; }
        public DateTime Dateexp { get; set; }
        public int Quantite { get; set; }
        public decimal Prixdachat { get; set; }
        public decimal Prixvente { get; set; }
        public decimal Prixgros { get; set; }
        public decimal Ppa { get; set; }
        public decimal Shp { get; set; }

        public Produit CleproduitNavigation { get; set; }
    }
}
