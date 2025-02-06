using Cental.BusinessLayer.Abstract;
using Cental.DtoLayer.Enums;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cental.WebUI.ViewComponents.Cars
{
    public class _CarFilterCars(ICarService _carService): ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cars = _carService.TGetAll();

            ViewBag.cars = (from x in cars
                            select new SelectListItem
                            {
                                Text = x.Brand.BrandName + " " + x.ModelName,
                                Value = x.Brand.BrandName + " " + x.ModelName
                            }).ToList();


            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();
            return View();
        }
    }
}
