using ECommerce.Catalog.Application.Commands.Products.Model;
using ECommerce.Catalog.Domain.Entity;
using ECommerce.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Commands.Products.Handler
{
    public class CreateProductCommandHandler(IRepository<Product> productRepository) : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IRepository<Product> _productRepository = productRepository;


        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                CategoryId = request.CategoryId,
                BrandId = request.BrandId,
                ImageUrl = request.ImageUrl,
                StockQuantity = request.StockQuantity,
                IsDeleted = false,
                Reviews = []
            };

            await _productRepository.AddAsync(product);
            _productRepository.SaveChangesAsync();
            return product.Id;
        }
    }
}
