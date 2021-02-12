using Microsoft.AspNetCore.Mvc;

namespace ConfigurableRedirects.AspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
