using Admin.Helper;
using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    [SessionFilter]
    public class AccountController : Controller
    {
        private readonly IMemberService _memberService;

        public AccountController(IMemberService memberService)
        {
            _memberService = memberService;
        }

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
            var findUser = _memberService.GetLoginedMember(viewModel.UserName, viewModel.Password);
            int memberId =(int)HttpContext.Session.GetInt32("userId");
            if (viewModel.Password!=viewModel.ConfirmPassword)
            {
                ViewData["PasswordChangeStatus"] = "Girdiğiniz şifreler uyuşmuyor.";
            }
            else
            {
                if (_memberService.ChangePassword(viewModel.OldPassword,viewModel.Password,memberId))
                {
                    ViewData["PasswordChangeStatus"] = "Şifre değiştirme işlemi başarılı";
                }
                else
                {
                    ViewData["PasswordChangeStatus"] = "Şifre değiştirme işlemi başarısız";
                }
            }
          
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