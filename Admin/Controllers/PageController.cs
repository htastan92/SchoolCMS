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
    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IHostingEnvironment _hostingEnvironment;

        public PageController(IPageService pageService, IHostingEnvironment hostingEnvironment)
        {
            _pageService = pageService;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(PageNewViewModel viewModel)
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
            var newPage = new Page()
            {
                Name = viewModel.Name,
                ImageUrl = uniqueFileName,
                StatusId = viewModel.StatusId,
                CreationDate = DateTime.Now,
                CreatorMemberId = 1,
                Description = viewModel.Description,
                EditorContent = viewModel.EditorContent,
                Slug = viewModel.Slug
                
            };

            _pageService.New(newPage);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");

            var findPage = _pageService.GetAdmin(id);

            var viewModel = new PageEditViewModel()
            {
                
                Name = findPage.Name,
                StatusId = findPage.StatusId,
                EditorContent = findPage.EditorContent,
                Slug = findPage.Slug,
                Description = findPage.Description,
                Id = findPage.Id
            };
           
            return View();
        }
        [HttpPost]
        public IActionResult Edit(PageEditViewModel viewModel)
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
            var editedPage = new Page()
            {
                ImageUrl = uniqueFileName,
                Name = viewModel.Name,
                StatusId = viewModel.StatusId,
                EditorContent = viewModel.EditorContent,
                Slug = viewModel.Slug,
                Description = viewModel.Description
            };
            _pageService.Edit(editedPage);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _pageService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _pageService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            _pageService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}