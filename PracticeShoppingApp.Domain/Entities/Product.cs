using PracticeShoppingApp.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace PracticeShoppingApp.Domain.Entities
{
    public class Product : AuditableEntity
    {
        [Key]
        public Guid ProdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
        public int StockQuantity { get; set; }
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }  
    }
}
