using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Layout()
        {
            return View();
        }
    }
}
