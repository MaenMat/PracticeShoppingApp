namespace PracticeShoppingApp.UI.ViewModels
{
    public class ProductNestedViewModel
    {
        public Guid ProdId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
