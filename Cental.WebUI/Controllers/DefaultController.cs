using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
