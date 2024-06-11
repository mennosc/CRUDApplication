using CRUDAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPP.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            CategoriesRepository.UpdateCategory(category.Id, category);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var category = CategoriesRepository.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ViewProducts(string name)
        {
            Category? category = CategoriesRepository.getCategoryByName(name);
            return View(category.products);
        }
    }
}

