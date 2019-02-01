using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmalina.Application.Products.Commands.CreateProduct;
using Pharmalina.Application.Products.Models;
//using Pharmalina.Application.Products.Commands.DeleteProduct;
//using Pharmalina.Application.Products.Commands.UpdateProduct;
using Pharmalina.Application.Products.Queries.GetAllProducts;
using Pharmalina.Application.Products.Queries.GetProduct;

namespace Pharmalina.WebUI.Controllers
{
    public class ProductsController : BaseController
    {
        [Authorize]
        // GET: api/Products
        [HttpGet]
        public Task<ProductsListViewModel> GetAll()
        {
            return Mediator.Send(new GetAllProductsQuery());
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductQuery { Id = id }));
        }

        // POST: api/Products
        [HttpPost]
        [ProducesResponseType(typeof(ProductViewModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            var productId = await Mediator.Send(command);

            return CreatedAtAction("GetProduct", new { id = productId });
        }

        /*// PUT: api/Products/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(
            [FromRoute] int id,
            [FromBody] UpdateProductCommand command)
        {
            if (id != command.ProductId)
            {
                return BadRequest();
            }

            return Ok(await Mediator.Send(command));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProductCommand { Id = id });

            return NoContent();
        }*/
    }
}