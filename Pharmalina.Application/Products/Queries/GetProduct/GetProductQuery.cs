using MediatR;
using Pharmalina.Application.Products.Models;

namespace Pharmalina.Application.Products.Queries.GetProduct
{
    public class GetProductQuery : IRequest<ProductViewModel>
    {
        public int Id { get; set; }
    }
}
