﻿using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}