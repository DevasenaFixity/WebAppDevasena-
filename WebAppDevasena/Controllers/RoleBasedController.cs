using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using WebAppDevasena.Models;
using WebAppDevasena.BusinessLogic;

namespace WebAppDevasena.Controllers
{
    public class RoleBasedController : Controller
    {
        public IActionResult Access()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Access(RoleBaseLoginModel obj)
        {

            if (string.IsNullOrEmpty(obj.EMAILID) && string.IsNullOrEmpty(obj.PASSWORD))
            {
                return RedirectToAction("Login");
            }
            ClaimsIdentity identity = null;
            bool isAuthentic = false;
            if (obj.EMAILID == "admin@yahoo.com" && obj.PASSWORD == "Admin@123")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.EMAILID),
                    new Claim(ClaimTypes.Role,"Admin")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (obj.EMAILID == "user@yahoo.com" && obj.PASSWORD == "User@123")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.EMAILID),
                    new Claim(ClaimTypes.Role,"User")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (isAuthentic)
            {
                var principals = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principals);
                return RedirectToAction("Display", "RoleBased");
            }
            return View();
        }
        
        public IActionResult Display()
        {
            return View();
        }
    }
}

