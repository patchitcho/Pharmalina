using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pharmalina.Application.Exceptions;
using Pharmalina.Application.Products.Models;
using Pharmalina.Domain.Entities;
using Pharmalina.Persistence;

namespace Pharmalina.Application.Products.Queries.GetProduct
{
    public class GetProductQueryHandler : MediatR.IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly PharmalinaDbContext _context;

        public GetProductQueryHandler(PharmalinaDbContext context)
        {
            _context = context;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == request.Id)
                .Select(ProductViewModel.Projection)
                .SingleOrDefaultAsync(cancellationToken);

            if (product == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            // TODO: Set view model state based on user permissions.
            product.EditEnabled = true;
            product.DeleteEnabled = false;

            return product;
        }
    }
}
