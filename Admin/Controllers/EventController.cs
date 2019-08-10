using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}