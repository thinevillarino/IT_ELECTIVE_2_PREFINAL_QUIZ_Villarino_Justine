using Microsoft.AspNetCore.Mvc;

namespace IT_ELECTIVE_2_PREFINAL_QUIZ_Villarino_Justine.Controllers
{
    public class LoginController : Controller
    {
        // LOGIN PAGE
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        // CHECK LOGIN
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string username, string password)
        {
            string correctUsername = "justine";
            string correctPassword = "justine1234";

            if (username == correctUsername &&
                password == correctPassword)
            {
                HttpContext.Session.SetString(
                    "Username",
                    username
                );

                return RedirectToAction(
                    "Index",
                    "Home"
                );
            }

            ViewBag.Error =
                "Incorrect username or password.";

            return View();
        }


        // LOGOUT
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction(
                "Index",
                "Login"
            );
        }
    }
}