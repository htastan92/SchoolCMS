﻿using Microsoft.AspNetCore.Mvc;

namespace Admin.Controllers
{
    public class PageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}