using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}