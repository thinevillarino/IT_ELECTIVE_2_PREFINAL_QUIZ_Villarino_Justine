using System.Diagnostics;
using IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Models;
using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
     
            string? username =
                HttpContext.Session.GetString("Username");

        
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction(
                    "Index",
                    "Login"
                );
            }

            return View();
        }

        public IActionResult Privacy()
        {
            string? username =
                HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction(
                    "Index",
                    "Login"
                );
            }

            return View();
        }
        [ResponseCache(
            Duration = 0,
            Location = ResponseCacheLocation.None,
            NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId =
                        Activity.Current?.Id ??
                        HttpContext.TraceIdentifier
                }
            );
        }
    }
}