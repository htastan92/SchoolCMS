using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class StaffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}