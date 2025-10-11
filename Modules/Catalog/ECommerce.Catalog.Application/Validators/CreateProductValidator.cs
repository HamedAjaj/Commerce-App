using ECommerce.Catalog.Application.Commands.Products.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Application.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
            RuleFor(p=> p.Description).MaximumLength(1000).WithMessage("Product description must not exceed 1000 characters.");
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Price must be greater than zero."); 
            RuleFor(p => p.StockQuantity).NotEmpty().WithMessage("Stock quantity is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("Category ID is required.");
            RuleFor(p => p.BrandId).NotEmpty().WithMessage("Brand ID is required.");
            RuleFor(p => p.ImageUrl).MaximumLength(200).WithMessage("Image URL must not exceed 200 characters.");


        }
    }
}
