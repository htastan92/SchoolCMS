using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class CampusController : Controller
    {
        private readonly CampusService _campusService;

        public CampusController(CampusService campusService)
        {
            _campusService = campusService;
        }

        public IActionResult Index()
        {
            CampusListViewModel viewModel = new CampusListViewModel()
            {
                Campuses = _campusService.GetAllAdmin()
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult New(CampusNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Campus newCampus = new Campus()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                EditorContent = viewModel.EditorContent,
                Image = null,
                Status = null,
                Address = viewModel.Address,
                Telephone = viewModel.Telephone,
                EmailAddress = viewModel.EmailAddress,
                Fax = viewModel.Fax

            };
           _campusService.New(newCampus);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var findCampus = _campusService.GetAdmin(id);
            if (findCampus == null)
                return RedirectToAction("Index");

            CampusEditViewModel viewModel = new CampusEditViewModel()
            {
                Id = findCampus.Id,
                Name = findCampus.Name,
                Description = findCampus.Description,
                Slug = findCampus.Slug,
                EditorContent = findCampus.EditorContent,
                ImageUrl = null,
                Address = findCampus.Address,
                Telephone = findCampus.Telephone,
                EmailAddress = findCampus.EmailAddress,
                Fax = findCampus.Fax
            };
            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Edit(CampusEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            Campus editedcampus = new Campus()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                EditorContent = viewModel.EditorContent,
                Image = null,
                Status = null,
                Address = viewModel.Address,
                Telephone = viewModel.Telephone,
                EmailAddress = viewModel.EmailAddress,
                Fax = viewModel.Fax
            };
            _campusService.Edit(editedcampus);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _campusService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _campusService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _campusService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
