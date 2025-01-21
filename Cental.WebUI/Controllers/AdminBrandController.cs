using Cental.BusinessLayer.Abstract;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Cental.WebUI.Controllers
{
    public class AdminBrandController(IBrandService _brandService) : Controller
    {
        public IActionResult Index()
        {
            var values = _brandService.TGetAll();
            return View(values);
        }

        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBrand(Brand model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _brandService.TCreate(model);
            return RedirectToAction("Index");
        }


    }
}
