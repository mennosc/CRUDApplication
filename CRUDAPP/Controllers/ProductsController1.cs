using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPP.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = ProductRepository.getProducts();
            return View(products);
        }
    }
}
