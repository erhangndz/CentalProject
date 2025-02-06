using Cental.BusinessLayer.Abstract;
using Cental.DataAccessLayer.Context;
using Cental.DtoLayer.Enums;
using Cental.EntityLayer.Entities;
using Cental.WebUI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class CarsController(ICarService _carService, IBrandService _brandService,CentalContext _context) : Controller
    {
        public IActionResult Index()
        {

            if (TempData["filterCars"] != null)
            {
                var data = TempData["filterCars"].ToString();
                if (data != null)
                {

                    var filterCars = JsonSerializer.Deserialize<List<Car>>(data, new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.IgnoreCycles
                    });



                    return View(filterCars);
                    
                }
            }

            var values = _carService.TGetAll();
            return View(values);




        }

        public PartialViewResult FilterCars()
        {

            var cars = _carService.TGetAll();

            ViewBag.cars = (from x in cars
                              select new SelectListItem
                              {
                                  Text = x.Brand.BrandName+ " "+ x.ModelName,
                                  Value = x.Brand.BrandName + " " + x.ModelName
                              }).ToList();


            ViewBag.gasTypes = GetEnumValues.GetEnums<GasTypes>();
            ViewBag.gearTypes = GetEnumValues.GetEnums<GearTypes>();


            return PartialView();
        }

        [HttpPost]
        public IActionResult FilterCars(string car,string gear, string gas)
        {
            if(!string.IsNullOrEmpty(car) || !string.IsNullOrEmpty(gear) || !string.IsNullOrEmpty(gas))
            {
                var values = _context.Cars.Where(x => x.Brand.BrandName + " " + x.ModelName == car
                                                    && x.GearType == gear
                                                    && x.GasType == gas
                                                    ).ToList();

                TempData["filterCars"] = JsonSerializer.Serialize(values, new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                });

 
            }
            return RedirectToAction("Index");
        }
    }
}
