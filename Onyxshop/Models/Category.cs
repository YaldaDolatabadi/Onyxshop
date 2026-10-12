namespace Onyxshop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string decription { get; set; }

        public ICollection<CategoryToProduct> categoryToProducts { get; set; }
    }
}
