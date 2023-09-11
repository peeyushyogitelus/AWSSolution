using AWS_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AWS_app.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TempData["controller"] = "Home";
            TempData["action"] = "Index";
            return View();
        }

        public IActionResult Privacy()
        {
            //Read Query Data 

            string strCode = HttpContext.Request.Query["code"].ToString();
            if (!string.IsNullOrEmpty(strCode))
            {
                ViewBag.Code = strCode;
            }
            else {
                ViewBag.Code = "";
            }



            ViewBag.Controller = TempData["controller"];
            ViewBag.Action = TempData["action"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}