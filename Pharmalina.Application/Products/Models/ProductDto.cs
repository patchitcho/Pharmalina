using System;
using System.Linq.Expressions;
using Pharmalina.Domain.Entities;

namespace Pharmalina.Application.Products.Models
{
    public class ProductDto
    {
        public int ProductId { get; set; }

        public string Code { get; set; }

        public string Reference { get; set; }

        public string Designation { get; set; }

        public string Remarque { get; set; }

        public static Expression<Func<Product, ProductDto>> Projection
        {
            get
            {
                return p => new ProductDto
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
