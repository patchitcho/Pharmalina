using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Pharmalina.Application.Exceptions;
using Pharmalina.Domain.Entities;
using Pharmalina.Persistence;

namespace Pharmalina.Application.Products.Commands.UpdateProduct
{
    class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly PharmalinaDbContext _context;

        public UpdateProductCommandHandler(PharmalinaDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Products.FindAsync(request.ProductId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Product), request.ProductId);
            }

            entity.ProductId = request.ProductId;
            entity.Code = request.Code;
            entity.Reference = request.Reference;
            entity.Designation = request.Designation;
            entity.Remarque = request.Remarque;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
