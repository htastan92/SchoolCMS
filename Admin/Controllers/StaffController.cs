﻿using Admin.Helper;
using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    [SessionFilter]
    public class StaffController : Controller
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }
        public IActionResult Index()
        {
            StaffListViewModel viewModel = new StaffListViewModel()
            {
                Staff = _staffService.GetAllAdmin()
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(StaffNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Staff newStaff = new Staff()
            {
                FullName = viewModel.FullName,
                BioText = viewModel.BioText,
                Sector = viewModel.Sector,
                CampusId = viewModel.CampusId,
                StatusId = viewModel.StatusId
            };
            _staffService.New(newStaff);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var findStaff = _staffService.GetAdmin(id);

            StaffEditViewModel viewModel = new StaffEditViewModel()
            {
                Id = findStaff.Id,
                FullName = findStaff.FullName,
                BioText = findStaff.BioText,
                Sector = findStaff.Sector,
                StatusId = findStaff.StatusId,
                CampusId = findStaff.CampusId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(StaffEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            Staff editedStaff = new Staff()
            {
                Id = viewModel.Id,
                FullName = viewModel.FullName,
                Sector = viewModel.Sector,
                BioText = viewModel.BioText,
                StatusId = viewModel.StatusId,
                CampusId = viewModel.CampusId
            };
            _staffService.Edit(editedStaff);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _staffService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _staffService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _staffService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}