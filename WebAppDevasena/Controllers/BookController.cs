using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.BusinessLogic;
using WebAppDevasena.Models;
namespace WebAppDevasena.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(BOOKDETAILSModel obj)
        {
            ViewBag.Message = "formsubmitted";
            if (ModelState.IsValid)
            {
                bool res = BookLogics.Insertdata(obj);

                if (res == true)
                {

                    return RedirectToAction("DisplayBook");
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

        public IActionResult DisplayBook()
        {
            return View(BookLogics.GetAllData());
        }
    }
}

