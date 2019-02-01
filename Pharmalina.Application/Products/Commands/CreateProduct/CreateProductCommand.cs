using MediatR;

namespace Pharmalina.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Code { get; set; }

        public string Reference { get; set; }

        public string Designation { get; set; }

        public string Remarque { get; set; }
    }
}
