using Pharmalina.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Pharmalina.Application.Products.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        public string Code { get; set; }

        public string Reference { get; set; }

        public string Designation { get; set; }

        public string Remarque { get; set; }

        public bool EditEnabled { get; set; }

        public bool DeleteEnabled { get; set; }

        public static Expression<Func<Product, ProductViewModel>> Projection
        {
            get
            {
                return p => new ProductViewModel
                {
                    ProductId = p.ProductId,
                    Code = p.Code,
                    Reference = p.Reference,
                    Designation = p.Designation,
                    Remarque = p.Remarque,
                };
            }
        }
    }
}
