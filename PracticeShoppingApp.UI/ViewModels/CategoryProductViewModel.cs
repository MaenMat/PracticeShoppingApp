namespace PracticeShoppingApp.UI.ViewModels
{
    public class CategoryProductViewModel
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public IEnumerable<ProductNestedViewModel>? Products { get; set; }
    }
}
