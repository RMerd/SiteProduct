using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace SiteProduct.Controllers
{
    [Route("{controller}/{action=index}/{id?}")]
    public class UserController : Controller
    {
        public string Index()
        {
            //var element = HttpContext.Request.Headers;
            //string result = string.Empty;
            //foreach (var item in element)
            //{
            //    result += $"{item.Key} = {item.Value}\n";
            //}
            //return result;

            //return Request.Method;

            string result = string.Empty;
            RouteData data = HttpContext.GetRouteData();
            foreach (var item in data.Values)
            {
                result += $"{item.Key} = {item.Value}\n";
            }
            return result;
        }
    }
}
