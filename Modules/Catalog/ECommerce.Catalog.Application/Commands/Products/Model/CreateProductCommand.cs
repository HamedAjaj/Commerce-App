using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Commands.Products.Model
{
    using MediatR;

    public record CreateProductCommand(
        string Name,
        string Description,
        decimal Price,
        Guid CategoryId,
        Guid BrandId,
        string ImageUrl,
        int StockQuantity
    ) : IRequest<Guid>;
}
