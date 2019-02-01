using MediatR;
using Pharmalina.Application.Products.Models;

namespace Pharmalina.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<ProductsListViewModel>
    {
    }
}
