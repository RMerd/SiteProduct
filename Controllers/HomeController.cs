using Microsoft.AspNetCore.Mvc;
using SiteProduct.Models;
using SiteProduct.Services;
using SiteProduct.ViewModels;

namespace SiteProduct.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductData _products;
        private readonly ITypeProductData _category;

        public HomeController(IProductData product, ITypeProductData category)
        {
            _products = product;
            _category = category;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product model)
        {
            if(ModelState.IsValid)
            {
                var newId = _products.Add(model);
                return RedirectToAction("Details", new { id = newId });
            }
            return View();
        }

        public ViewResult Index()
        {
            var model = _products.GetAll().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                ProductionDate = p.ProductionDate,
                Category = _category.GetCategory().Where(c => c.Id == p.CategoryId).FirstOrDefault()?.TypeName ?? string.Empty,
            });
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _products.Get(id);
            if (model.Id == -1) return RedirectToAction("Index");
            var productViewModel = new ProductViewModel
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                ProductionDate = model.ProductionDate,
                Category = _category.GetCategory().Where(c => c.Id == model.CategoryId).FirstOrDefault()?.TypeName ?? string.Empty,
            };
            return View(productViewModel);
        }
        
        public IActionResult Delete(int id)
        {
            _products.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
