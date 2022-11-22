using Microsoft.AspNetCore.Mvc;
using WebAppDevasena.BusinessLogic;
using WebAppDevasena.Models;
using System.Data;
using WebAppDevasena.encrypteddata;


namespace WebAppDevasena.Controllers
{
    public class RegEncryptedController : Controller
    {
        [HttpGet]
        public IActionResult AddData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddData(EncryptedModel obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Encrypted_bl.Insertdata(obj);
                if (res == true)
                {
                    return RedirectToAction("Encryptlogin", "RegEncrypted");
                }
                else
                {
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult Encryptlogin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Encryptlogin(EncryptedModel obj)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt = Encrypted_bl.ReadData(obj);
                if (dt.Rows.Count > 0)
                {
                    ViewData["EMAILID"] = EncryptionLibrary.DecryptText(dt.Rows[0]["EMAILID"].ToString());
                    ViewData["PASSWORD"] = EncryptionLibrary.DecryptText(dt.Rows[0]["PASSWORD"].ToString());
                }
            }
            return View();
        }

    }
}

