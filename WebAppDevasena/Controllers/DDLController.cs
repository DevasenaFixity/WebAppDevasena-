using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.Models;
using WebAppDevasena.BusinessLogic;


namespace WebAppDevasena.Controllers
{
    public class DDLController : Controller
    {
        [HttpGet]
        public IActionResult ViewDropDownVal()
        {
            ViewBag.data = ddl_blcs.PopulateData();
            return View();
        }
        [HttpPost]
        public IActionResult ViewDropDownVal(string x)
        {
            ViewBag.data = Request.Form["test"].ToString();
            return View();
        }

        [HttpGet]
        public IActionResult GetDataonDDL()
        {
            ViewBag.data = ddl_blcs.PopulateData();
            return View();
        }
        [HttpPost]
        public IActionResult GetDataonDDL(string customers)
        {
            ViewData["Val"] = ddl_blcs.GetOrdersByCust(Request.Form["test"].ToString());
            ViewBag.data = ddl_blcs.PopulateData();
            return View();
        }
    }
}