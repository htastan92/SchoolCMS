using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}