using System;
using System.Collections.Generic;

namespace Pharmalina.Domain.Entities
{
    public class Lot
    {

        public int lotId { get; set; }
        public int ProductId { get; set; }
        public string Codelot { get; set; }
        public string Nlot { get; set; }
        public DateTime Dateexp { get; set; }
        public int Quantite { get; set; }
        public decimal Prixdachat { get; set; }
        public decimal Prixvente { get; set; }
        public decimal Prixgros { get; set; }
        public decimal Ppa { get; set; }
        public decimal Shp { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public User ModifiesBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public Product CleproduitNavigation { get; set; }
    }
}
