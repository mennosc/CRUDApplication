using System.ComponentModel.DataAnnotations;

namespace CRUDAPP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;

        public List<string> getCategoryNames()
        {
            return CategoriesRepository.getCategoryNames();
        }
    }
}
