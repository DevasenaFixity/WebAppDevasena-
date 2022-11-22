using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.BusinessLogic;
using WebAppDevasena.Models;
using System.Data.SqlClient;
using System.Data;

namespace WebAppDevasena.Controllers
{
    public class CheckboxController : Controller
    {
        [HttpGet]
        public IActionResult DESIGN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DESIGN(CheckboxModel OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = Checkbox_bl.Insertdata(OBJ);
                if (res == true)
                {

                    return View("Login");
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

