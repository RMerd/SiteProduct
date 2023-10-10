using Microsoft.AspNetCore.Mvc;

namespace SiteProduct.ViewComponents
{
    public class ContentFooter : ViewComponent
    {
        private readonly IConfiguration configuration;

        public ContentFooter(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IViewComponentResult Invoke()
        {
            var model = configuration.GetSection("About")["Production"];
            return View("Default", model);
        }
    }
}
