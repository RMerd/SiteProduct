using Microsoft.AspNetCore.Mvc;

namespace SiteProduct.Controllers
{
	public class ProductController : Controller
	{
		public ContentResult Name()
		{
			return Content("Шилдт Г. С# 4.0: Полное руководство");
		}

		[HttpPost]
		public IActionResult Index()
		{
			return Content("Привет из /Product/Index");
		}
	}
}
