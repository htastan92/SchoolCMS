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
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EventController(IEventService eventService, IHostingEnvironment hostingEnvironment)
        {
            _eventService = eventService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            EventListViewModel viewModel = new EventListViewModel()
            {
                Events = _eventService.GetAllAdmin()
            };

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(EventNewViewModel viewModel)   
        {
            if (!ModelState.IsValid)
                return View(viewModel);

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
            Event newEvent = new Event()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                EditorContent = viewModel.EditorContent,
                ImageUrl =uniqueFileName,
                StatusId = viewModel.StatusId,
                Location = viewModel.Location,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                CampusId = viewModel.CampusId
            };
            _eventService.New(newEvent);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            var findEvent = _eventService.GetAdmin(id);
            if (findEvent == null)
                return RedirectToAction("Index");

            EventEditViewModel viewModel = new EventEditViewModel()
            {
                Id = findEvent.Id,
                Name = findEvent.Name,
                Description = findEvent.Description,
                EditorContent = findEvent.EditorContent,
                Slug = findEvent.Slug,
                StatusId = findEvent.StatusId,
                Location = findEvent.Slug,
                StartDate = findEvent.StartDate,
                EndDate = findEvent.EndDate,
                CampusId = findEvent.CampusId
                
            };
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Edit(EventEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

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
            Event editedEvent = new Event()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                EditorContent = viewModel.EditorContent,
                Slug = viewModel.Slug,
                ImageUrl = uniqueFileName,
                StatusId = viewModel.StatusId,
                Location = viewModel.Location,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                CampusId = viewModel.CampusId
                
            };
            _eventService.Edit(editedEvent);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _eventService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}