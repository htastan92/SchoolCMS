using System;
using System.IO;
using Admin.Helper;
using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    [SessionFilter]
    public class CampusController : Controller
    {
        private readonly ICampusService _campusService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CampusController(ICampusService campusService, IHostingEnvironment hostingEnvironment)
        {
            _campusService = campusService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            CampusListViewModel viewModel = new CampusListViewModel()
            {
                Campuses = _campusService.GetAllAdmin()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(CampusNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                string uniqueFileName = null;
                if (viewModel.Photos != null && viewModel.Photos.Count > 0)
                {
                    foreach (IFormFile photo in viewModel.Photos)
                    {
                        var extension = Path.GetExtension(photo.FileName).ToLower();
                        if (extension==".jpg" || extension==".jpeg" || extension==".png")
                        {
                             string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        }
                        else
                        {
                            throw new Exception("Dosya türü .JPG , .JPEG veya .PNG olmalıdır..");
                        }
                       
                    }
                }
                Campus newCampus = new Campus()
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    Slug = viewModel.Slug,
                    EditorContent = viewModel.EditorContent,
                    ImageUrl = uniqueFileName,
                    StatusId = viewModel.StatusId,
                    Address = viewModel.Address,
                    Telephone = viewModel.Telephone,
                    EmailAddress = viewModel.EmailAddress,
                    Fax = viewModel.Fax,
                    CreationDate = DateTime.Now,
                    CreatorMemberId = 1,
                    EditDate = null,
                    EditorMemberId = null
                };
                _campusService.New(newCampus);
                return RedirectToAction("Index");
            }
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
                StatusId = findCampus.Status.Id,
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
            {
                return View(viewModel);
            }
            else
            {
                string uniqueFileName = null;
                if (viewModel.Photos != null && viewModel.Photos.Count > 0)
                {
                    foreach (IFormFile photo in viewModel.Photos)
                    {
                        var extension = Path.GetExtension(photo.FileName).ToLower();
                        if (extension == ".jpg" || extension == ".jpeg" || extension == ".png")
                        {
                            string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                            uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        }
                        else
                        {
                            throw new Exception("Dosya türü .JPG , .JPEG veya .PNG olmalıdır..");
                        }

                    }
                }
                Campus editedCampus = new Campus()
                {
                    Id = viewModel.Id,
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    EditorContent = viewModel.EditorContent,
                    ImageUrl = uniqueFileName,
                    StatusId = viewModel.StatusId,
                    Address = viewModel.Address,
                    Telephone = viewModel.Telephone,
                    EmailAddress = viewModel.EmailAddress,
                    Fax = viewModel.Fax,
                    EditDate = DateTime.Now,
                    EditorMemberId = 1
                };
                _campusService.Edit(editedCampus);
                return RedirectToAction("Index");
            }
            
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
