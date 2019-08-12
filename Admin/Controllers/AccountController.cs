using Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
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
            // Kill session and remove session from database.
            return RedirectToAction("Index", "Login");
        }
    }
}