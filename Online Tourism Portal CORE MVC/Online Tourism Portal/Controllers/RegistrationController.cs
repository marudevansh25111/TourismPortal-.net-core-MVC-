using Microsoft.AspNetCore.Mvc;
using Online_Tourism_Portal.Data;
using System.Collections.Generic;
using System.Linq;
using Online_Tourism_Portal.Models;
using Microsoft.Data.SqlClient;

namespace Online_Tourism_Portal.Controllers
{
    public class RegistrationController : Controller
    {
        Registration obj;
        private readonly ApplicationDbContext _db;

        public RegistrationController(ApplicationDbContext db)
        {
            _db = db;

        }
        public IActionResult Index()
        {
            IEnumerable<Registration> objList = _db.Registration;
            return View(objList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Taj()
        {
            return View();
        }
        public IActionResult Khajuraho()
        {
            return View();
        }
        
        public IActionResult Jaipur()
        {
            return View();
        }
        public IActionResult Goa()
        {
            return View();
        }
        public IActionResult NorthEastIndia()
        {
            return View();
        }
        public IActionResult Kerela()
        {
            return View();
        }
        public IActionResult LehLadakh()
        {
            return View();
        }
        public IActionResult SasanGir()
        {
            return View();
        }
        public IActionResult StatueOfUnity()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Registration obj)
        {
            if (ModelState.IsValid)
            {
                _db.Registration.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(obj);

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Registration obj1)
        {
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT Name, Password FROM Registration";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            if (obj1.Name.ToString() == sdr["Name"].ToString() && obj1.Password.ToString() == sdr["Password"].ToString())
                                return RedirectToAction("AboutIndia");
                        }
                    }
                    con.Close();
                }
            }



            return View(obj1);

        }
        public IActionResult AboutIndia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Validate(string destination)
        {
          
            string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True";
            ViewData["Destinations"] = destination;
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "SELECT destination FROM Destinations";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            
                               
                            if (destination != null && destination.ToLower() == sdr["destination"].ToString().ToLower()  )
                                      return RedirectToAction(destination);
                            
                            

                        }
                    }
                    con.Close();
                }
            }
            return Validate("Index");
        }

        public JsonResult AutoComplete(string prefix)
        {
            var customers = (from customer in this._db.Destinations
                             where customer.destination.StartsWith(prefix)
                             select new
                             {
                                 label = customer.destination,
                                 val = customer.Id
                             }).ToList();

            return Json(customers);
        }

       

    }
}
