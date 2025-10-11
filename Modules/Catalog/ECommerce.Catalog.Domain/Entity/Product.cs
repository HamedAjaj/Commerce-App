using ECommerce.SharedKernel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Domain.Entity
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public Guid BrandId { get; set; }
    
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual ICollection<ProductReview>? Reviews { get; set; } = new List<ProductReview>();
    } 
}
