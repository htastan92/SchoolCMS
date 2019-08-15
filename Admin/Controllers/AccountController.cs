using Admin.Helper;
using Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    [SessionFilter]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            // Change password, mail etc.

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("userId");
            return RedirectToAction("Index", "Login");
        }
    }
}