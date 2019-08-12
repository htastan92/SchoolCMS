using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly MemberService _memberService;

        public LoginController(MemberService memberService)
        {
            _memberService = memberService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            if (_memberService.CheckLogin(viewModel.Username, viewModel.Password))
            {
                // Create Session
                return RedirectToAction("Index", "Dashboard");
            }

            //ViewData["LoginStatus"] = "Giriş başarısız, kullanıcı adı veya şifre hatalı.";
            return RedirectToAction("Index");
        }
    }
}