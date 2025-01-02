using Cental.BusinessLayer.Abstract;
using Cental.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    public class AdminAboutController : Controller
    {
        private readonly IAboutService _aboutService;


        public AdminAboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult Index()
        {   
           var values = _aboutService.TGetAll();
           return View(values);
        }
    }
}
