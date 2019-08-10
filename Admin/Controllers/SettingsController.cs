using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}