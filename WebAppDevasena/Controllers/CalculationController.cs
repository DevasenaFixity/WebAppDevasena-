using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.BusinessLogic;
using WebAppDevasena.Models;

namespace WebAppDevasena.Controllers
{
    public class CalculationController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CalculationModel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = calc.insertcalculator(obj);
                if (res == true)
                {

                    return View();

                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

    }
}
