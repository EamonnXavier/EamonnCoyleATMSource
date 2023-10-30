using EamonnCoyleATM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EamonnCoyleATM.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //login button clicked
        public IActionResult Login()
        {
            //go to logincontroller and index method
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Dump()
        {
            //go to logincontroller and index method
            return RedirectToAction("Index", "Dump");
        }

    }
}