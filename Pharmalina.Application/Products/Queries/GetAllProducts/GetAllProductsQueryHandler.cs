using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Application.Products.Models;
using Microsoft.EntityFrameworkCore;
using Pharmalina.Persistence;

namespace Pharmalina.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, ProductsListViewModel>
    {
        private readonly PharmalinaDbContext _context;

        public GetAllProductsQueryHandler(PharmalinaDbContext context)
        {
            _context = context;
        }

        public async Task<ProductsListViewModel> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            // TODO: Set view model state based on user permissions.
            var model = new ProductsListViewModel
            {
                Products = await _context.Products
                    .Select(ProductDto.Projection)
                    .OrderBy(p => p.Reference)
                    .ToListAsync(cancellationToken),
                // CreateEnabled = true
            };

            return model;
        }
    }
}
