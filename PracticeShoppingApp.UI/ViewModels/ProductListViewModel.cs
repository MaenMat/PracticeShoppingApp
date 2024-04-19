namespace PracticeShoppingApp.UI.ViewModels
{
    public class ProductListViewModel
    {
        public Guid ProdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string? ImageUrl { get; set; }
    }
}
