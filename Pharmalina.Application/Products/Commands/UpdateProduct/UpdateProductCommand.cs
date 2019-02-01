using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Pharmalina.Application.Products.Commands.UpdateProduct
{
    class UpdateProductCommand : IRequest
    {
        public int ProductId { get; set; }

        public string Code { get; set; }

        public string Reference { get; set; }

        public string Designation { get; set; }

        public string Remarque { get; set; }

    }
}
