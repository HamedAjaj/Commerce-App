using ECommerce.SharedKernel.Base;

namespace ECommerce.Catalog.Domain.Entity
{
    public class ProductReview : BaseEntity
    {
        public string ProductId { get; set; }
        public string CustomerId { get; set; }
        public int Rating { get; set; } // Assuming a rating scale of 1-5
        public string Comment { get; set; }
        public DateTime ReviewDate { get; set; }
        // Navigation properties
        public virtual Product Product { get; set; }
       // public virtual Customer Customer { get; set; } // Assuming a Customer entity exists
    } 
}