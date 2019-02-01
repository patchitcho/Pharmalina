using Pharmalina.Application.Products.Queries.GetAllProducts;
using Pharmalina.Application.Products.Models;
using Pharmalina.Application.Tests.Infrastructure;
using Pharmalina.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pharmalina.Application.Tests.Products.Queries
{
    [Collection("QueryCollection")]
    public class GetAllProductsQueryHandlerTests
    {
        private readonly PharmalinaDbContext _context;

        public GetAllProductsQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetCustomersTest()
        {
            var sut = new GetAllProductsQueryHandler(_context);

            var result = await sut.Handle(new GetAllProductsQuery(), CancellationToken.None);

            result.ShouldBeOfType<ProductsListViewModel>();

            result.Products.Count.ShouldBe(3);
        }
    }
}
