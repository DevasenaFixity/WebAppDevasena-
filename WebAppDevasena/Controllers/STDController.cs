using Microsoft.AspNetCore.Mvc;
using WebAppDevasena;
using System.Data;
using WebAppDevasena.BusinessLogic;
using WebAppDevasena.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;


namespace WebAppDevasena.Controllers
{
    public class STDController : Controller
    {
        [HttpGet]
        public IActionResult LOGIN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LOGIN(STDModellogin OBJ)
        {
            if (ModelState.IsValid)
            {
                DataTable dt = new DataTable();
                dt = STDLogics.login(OBJ);

                if (dt.Rows.Count > 0)
                {
                    HttpContext.Session.SetString("UserName", dt.Rows[0]["Name"].ToString());
                    HttpContext.Session.SetString("Time", System.DateTime.Now.ToShortTimeString());
                    if (dt.Rows[0]["Status"].ToString().ToLower() == "true")  // active
                    {
                        if (dt.Rows[0]["ROLE"].ToString() == "STUDENT")  // std
                        {
                            Random rand = new Random();
                            HttpContext.Session.SetString("OTP", rand.Next(1111, 9999).ToString());
                            bool result = SendEmail(OBJ.EMAILID);
                            if (result == true)
                            {
                                return RedirectToAction("VerifyOtp", "STD");
                            }
                            
                        }
                        else if (dt.Rows[0]["ROLE"].ToString() == "PRINCIPLE")  // staff 
                        {
                            return RedirectToAction("ADMIN", "STD");
                        }
                    }
                    else
                    {
                        return RedirectToAction("ADMIN", "STD");
                    }
                    return RedirectToAction("Home", "STD");
                }

                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
      
        public IActionResult REGISTER()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult REGISTER(STDModel OBJ)
        {
            ViewBag.Message = "formsubmitted";
            if (ModelState.IsValid)
            {
                bool res = STDLogics.Insertdata(OBJ);

                if (res == true)
                {

                    return View("LOGIN");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }
       
        [HttpGet]
        public IActionResult Forgetpassword()
        {
            return View();
        }
        public IActionResult Forgetpassword(STDModel OBJ)
        {
            Random rand = new Random();
            HttpContext.Session.SetString("OTP", rand.Next(1111, 9999).ToString());
            bool result = SendEmail(OBJ.EMAILID);
            if (result == true)
            {
               
                return RedirectToAction("FORGOTPASSWORDOtp", "STD");
            }
            return View();
        }
        [HttpGet]
        public IActionResult FORGOTPASSWORDOtp()
        {    
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FORGOTPASSWORDOtp(OtpModel obj)
        {
            
                if (obj.Otp.Equals(HttpContext.Session.GetString("OTP")))
                {
                    return RedirectToAction("SETTINGNEWPASSWORD", "STD");
                }
                else
                {
                    return View();
                }
                return View();
        }

       
        

        public IActionResult Homepage()
        {
            return View();
        }
        public IActionResult ADMIN()
        {
            return View();
        }

       
        public IActionResult Home()
        {
            ViewBag.Message = "Login Successful";

            return View();
        }
        public IActionResult LIBRARY()
        {
            return View();
        }
        public IActionResult CONTACT()
        {
            return View();
        }
        public IActionResult DisplayData()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            return View();
        }
        public IActionResult Alert()
        {
            return View();
        }

        [HttpGet]
     
        public bool SendEmail(string receiver)
        {
            bool chk = false;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("devasenalebaka111@gmail.com");
                mail.To.Add(receiver);
                mail.IsBodyHtml = true;
                mail.Subject = "OTP";
                mail.Body = "Your OTP is :" + HttpContext.Session.GetString("OTP");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.Credentials = new NetworkCredential("devasenalebaka111@gmail.com", "othaqxszodchvhrc");
                client.EnableSsl = true;
                client.Send(mail);
                chk = true;
            }
            catch (Exception)
            {
                throw;
            }
            return chk;
        }

    


        [HttpGet]
        public IActionResult VerifyOtp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult VerifyOtp(OtpModel obj)
        {
            if (obj.Otp.Equals(HttpContext.Session.GetString("OTP")))
            {
                return RedirectToAction("Home", "STD");
            }
            else
            {
                return View();
            }
        }
       
    }
}