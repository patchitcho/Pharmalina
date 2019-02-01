using MediatR;

namespace Pharmalina.Application.Products.Commands.DeleteProduct
{
    class DeleteProductCommand : IRequest
    {
        public int Id { get; set; }
    }
}
