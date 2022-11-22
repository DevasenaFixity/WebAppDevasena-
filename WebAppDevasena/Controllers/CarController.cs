using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.BusinessLogic;
using WebAppDevasena.Models;

namespace WebAppDevasena.Controllers
{
    public class CarController : Controller
    {
        [HttpGet]
        public IActionResult InsertCar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertCar(CarModelcs obj)
        {
            ViewBag.Message = "formsubmitted";
            if (ModelState.IsValid)
            {
                bool res = InsertCarData.Insertdata(obj);

                if (res == true)
                {

                    return View();
                }
                else
                {
                    return View(obj);
                }
            }
            else
            {
                return View(obj);
            }
        }

        [HttpGet]

        public IActionResult Displaycar()
        {
            return View(InsertCarData.GetAllData());
        }
    }
}
