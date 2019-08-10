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

        public IActionResult Index(AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            // Kill session and remove session from database.
            return RedirectToAction("Index", "Login");
        }
    }
}