namespace PracticeShoppingApp.Application.Features.Categories.Dtos
{
    public class GetCategoryProductListDto
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<GetCategoryProductDto>? Products { get; set; }
    }
}
