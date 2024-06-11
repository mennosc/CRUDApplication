using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPP.Controllers
{
    public class ProductDashboardController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductRepository.getProducts();
            return View(products);
        }

        public IActionResult Edit(int id)
        {
            Product? product = ProductRepository.getProductById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            ProductRepository.updateProduct(product.Id, product);
            return RedirectToAction("Index");
        }

        public IActionResult Add()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            ProductRepository.addProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            ProductRepository.removeProduct(id);
            return RedirectToAction("Index");
        }
    }
}
