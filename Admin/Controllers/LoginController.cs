﻿using Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMemberService _memberService;

        public LoginController(IMemberService memberService)
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
                var findUser = _memberService.GetLoginedMember(viewModel.Username, viewModel.Password);
                if (findUser == null) return RedirectToAction("Index");
                HttpContext.Session.SetInt32("userId", findUser.Id);
                return RedirectToAction("Index", "Dashboard");
            }

            //ViewData["LoginStatus"] = "Giriş başarısız, kullanıcı adı veya şifre hatalı.";
            return RedirectToAction("Index");
        }
    }
}