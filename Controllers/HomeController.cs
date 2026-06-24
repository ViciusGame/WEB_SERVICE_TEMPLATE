using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using WEB_SERVICE_TEMPLATE.Models;

namespace WEB_SERVICE_TEMPLATE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DataTable dt = DBConnect.GetData();
            return View(dt);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
