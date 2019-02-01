using MediatR;
using Pharmalina.Application.Exceptions;
using Pharmalina.Domain.Entities;
using Pharmalina.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Pharmalina.Application.Products.Commands.DeleteProduct
{
    class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly PharmalinaDbContext _context;

        public DeleteProductCommandHandler(PharmalinaDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.Id);
            }

            /* var hasOrders = _context.OrderDetails.Any(od => od.ProductId == entity.ProductId);
            if (hasOrders)
            {
                throw new DeleteFailureException(nameof(Product), request.Id, "There are existing orders associated with this product.");
            }*/

            _context.Products.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
