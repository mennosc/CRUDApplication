namespace CRUDAPP.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category{Id = 1, Name="Vlees", Description="Vlees"},
            new Category{Id = 2, Name="Vegetarisch", Description="Vegetarisch" },
            new Category{Id = 3, Name="Wild & Gevogelte", Description="Wild & Gevogelte" },
            new Category{Id = 4, Name="Vis", Description="Vis" },
            new Category{Id = 5, Name="Kaas ZB", Description="Kaas ZB" },
            new Category{Id = 6, Name="Salades", Description="Salades" },
            new Category{Id = 7, Name="Plantaardig", Description="Plantaardig" }
        };

        public static void AddCategory(Category category)
        {
            if (_categories.Count() > 0)
            {
                category.Id = _categories.Max(x => x.Id) + 1;
            } else { 
                category.Id = 1;
            }
            category.products.Add(new Product { Id = 5, Name = "Melk", Description = "Melk", ImagePath = "Test", Category = category.Name, Price = 1.50F, Quantity = 5 });
            
        _categories.Add(category);
        }

        public static List<Category> GetCategories()
        {
            return _categories;
        }

        public static Category? GetCategoryById(int categoryId)
        {
            var category = _categories.FirstOrDefault(x => x.Id == categoryId);
            if(category != null)
            {
                return new Category
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                };
            }

            return null;
        }
        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.Id) return;

            var categoryToUpdate = _categories.FirstOrDefault(x => x.Id == categoryId);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name;
                categoryToUpdate.Description = category.Description;
            }

            foreach(Product p in categoryToUpdate.products) {
                p.Category = categoryToUpdate.Name;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var categoryToDelete = _categories.FirstOrDefault(x => x.Id == categoryId);
            var index = _categories.IndexOf(categoryToDelete);
            if (categoryToDelete != null)
            {
                _categories.Remove(categoryToDelete);
            }

            for (int i = index; i < _categories.Count; i++)
            {
                var category = _categories[i];
                category.Id = category.Id - 1;
            }
        }

        public static List<string> getCategoryNames()
        {
            List<string> names = new List<string>();
            foreach (Category category in _categories)
            {
                names.Add(category.Name);
            }

            return names;
        }

        public static Category? getCategoryByName(string name)
        {
            Category? category = _categories.FirstOrDefault(x => x.Name == name);
            if(category != null)
            {
                return category;
            }

            return null;
        }

        public static void addProductToCategory(Category category, Product product)
        {
            category.products.Add(product);
        }
    }
}
