using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using pcf.Models;

namespace pcf.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult About() {
            ViewData["Message"] = "Your application description page.";

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "ad_8db3f085ffef489";
            var user = new UserModel();
            if (dbCon.IsConnect()) {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM users";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    user.FirstName = reader.GetString(1);
                    user.LastName = reader.GetString(2);
                    
                }
                dbCon.Close();
            }
            return View(user);
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
