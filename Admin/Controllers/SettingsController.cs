﻿using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class SettingsController : Controller
    {
        private readonly SettingsService _settingsService;

        public SettingsController(SettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(SettingsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Settings editedSettings = new Settings
            {
                Id = viewModel.Id
            };

            _settingsService.Edit(editedSettings);

            return RedirectToAction("Index");
        }
    }
}