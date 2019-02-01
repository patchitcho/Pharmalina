using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Domain.Entities;
using Pharmalina.Persistence;

namespace Pharmalina.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly PharmalinaDbContext _context;

        public CreateProductCommandHandler(PharmalinaDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = new Product
            {
                Code = request.Code,
                Reference = request.Reference,
                Designation = request.Designation,
                Remarque = request.Remarque,
            };

            _context.Products.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.ProductId;
        }
    }
}
