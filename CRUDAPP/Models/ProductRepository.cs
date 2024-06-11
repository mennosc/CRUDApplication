namespace CRUDAPP.Models
{
    public static class ProductRepository
    {
        private static List<Product> _products = new List<Product>();

        public static List<Product> getProducts()
        {
            return _products;
        }

        public static Product? getProductById(int? id)
        {
            Product? product = _products.FirstOrDefault(x => x.Id == id);
            if(product != null)
            {
                return product;
            }
            return null;
        }

        public static void updateProduct(int id, Product product)
        {
            Product? productToUpdate = _products.FirstOrDefault(x=>x.Id == id);
            if (productToUpdate != null)
            {
                productToUpdate.Id = id;
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                productToUpdate.Quantity = product.Quantity;
                productToUpdate.ImagePath = product.ImagePath;
                productToUpdate.Category = product.Category;

                CategoriesRepository.addProductToCategory(CategoriesRepository.getCategoryByName(product.Category), product);
            }
        }

        public static void addProduct(Product product)
        {
            if(_products.Count() > 0)
            {
                product.Id = _products.Max(x => x.Id);
            } else
            {
                product.Id = 1;
            }
            
            _products.Add(product);
            CategoriesRepository.addProductToCategory(CategoriesRepository.getCategoryByName(product.Category), product);
        }

        public static void removeProduct(int id)
        {
            Product? product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                int productIndex = _products.IndexOf(product);
                _products.Remove(product);


                for (int i = productIndex; i < _products.Count(); i++)
                {
                    _products[i].Id--;
                }
            }
        }
    }
}
