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
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IStatusService _statusService;

        public NewsController(INewsService newsService, IHostingEnvironment hostingEnvironment, IStatusService statusService)
        {
            _newsService = newsService;
            _hostingEnvironment = hostingEnvironment;
            _statusService = statusService;
        }

        public IActionResult Index()
        {
            NewsListViewModel viewModel = new NewsListViewModel()
            {
                News = _newsService.GetAllAdmin(),
                Statuses = _statusService.GetAll()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NewsNewViewModel viewModel)
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
            News newNews = new News()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                EditorContent = viewModel.EditorContent,
                Slug = viewModel.Slug,
                CreationDate = DateTime.Now,
                ImageUrl = uniqueFileName,
                StatusId = viewModel.StatusId,
                CampusId = viewModel.CampusId
            };
            _newsService.New(newNews);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var findNews = _newsService.GetAdmin(id);

            if (findNews == null) 
                return RedirectToAction("Index");

            NewsEditViewModel viewModel = new NewsEditViewModel()
            {
                 Id = findNews.Id,
                 Name = findNews.Name,
                 Description = findNews.Description,
                 EditorContent = findNews.EditorContent,
                 Slug = findNews.Slug,
                 StatusId = findNews.StatusId,
                 CampusId = findNews.CampusId
                 
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(NewsEditViewModel viewModel)
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
            News editedNews = new News()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                EditorContent = viewModel.EditorContent,
                ImageUrl =uniqueFileName,
                StatusId = viewModel.StatusId,
                CampusId = viewModel.CampusId
            };
            _newsService.Edit(editedNews);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _newsService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _newsService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _newsService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}