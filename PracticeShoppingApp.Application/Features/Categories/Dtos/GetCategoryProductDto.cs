namespace PracticeShoppingApp.Application.Features.Categories.Dtos
{
    public class GetCategoryProductDto
    {
        public Guid ProdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
