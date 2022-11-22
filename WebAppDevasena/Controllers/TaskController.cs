using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Data.SqlClient;
using WebAppDevasena.Models;
using System.Data;
using WebAppDevasena.BusinessLogic;
namespace WebAppDevasena.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            dynamic model = new ExpandoObject();
            model.Customers = GetCustomers();
            model.Employees = GetEmployees();
            return View(model);
        }

        private static List<DEVAADDRESS> GetCustomers()
        {
            List<DEVAADDRESS> customers = new List<DEVAADDRESS>();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_DISPLAYADDRESS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        customers.Add(new DEVAADDRESS
                        {
                            HOMEID = Convert.ToInt32(sdr["HOMEID"].ToString()),
                            STREET = sdr["STREET"].ToString(),
                            MANDAL = sdr["MANDAL"].ToString(),
                            DIST = sdr["DIST"].ToString(),
                            STATE = sdr["STATE"].ToString(),
                            PINCODE = Convert.ToInt32(sdr["PINCODE"].ToString())
                        });
                    }
                }
                con.Close();
                return customers;
            }
        }
        private static List<DEVAFAMILY> GetEmployees()
        {
            List<DEVAFAMILY> Employees = new List<DEVAFAMILY>();
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_DISPLAYFAMILY", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Employees.Add(new DEVAFAMILY
                        {

                            HOMEID = Convert.ToInt32(sdr["HOMEID"].ToString()),
                            SURNAME = sdr["SURNAME"].ToString(),
                            MEMBERS = Convert.ToInt32(sdr["MEMBERS"].ToString()),

                        });
                    }
                    con.Close();
                    return Employees;
                }
            }          
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Insert(DEVAADDRESS OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = TASKLOGIC.Insertdata(OBJ);
                if (res == true)
                {

                    return View();
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
        public IActionResult InsertFamily()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertFamily(DEVAFAMILY OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = TASKLOGIC.Insertdata1(OBJ);
                if (res == true)
                {

                    return View();
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

    }


}
    




           
    





                

           
      
    
    

