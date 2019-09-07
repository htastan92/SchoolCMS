using System;
using System.IO;
using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class CarouselController : Controller
    {
        private readonly ICarouselService _carouselService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IStatusService _statusService;
        public CarouselController(ICarouselService carouselService, IHostingEnvironment hostingEnvironment, IStatusService statusService)
        {
            _carouselService = carouselService;
            _hostingEnvironment = hostingEnvironment;
            _statusService = statusService;
        }

        public IActionResult Index()
        {
            var viewModel = new CarouselListViewModel()
            {
                Carousels = _carouselService.GetAllAdmin()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult New()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult New(CarouselNewViewModel viewModel)
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
            var newCarousel = new Carousel()
            {
                Title = viewModel.Title,
                SubTitle = viewModel.SubTitle,
                ImageUrl = uniqueFileName,
                Url = viewModel.Url,
                StatusId = viewModel.StatusId
            };

            _carouselService.New(newCarousel);
            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id)
        {
            if (!ModelState.IsValid)
                return View("Index");

            var findCarousel = _carouselService.GetAdmin(id);

            var viewModel = new CarouselEditViewModel()
            {
                Title = findCarousel.Title,
                SubTitle = findCarousel.SubTitle,
                Url = findCarousel.ImageUrl,
                StatusId = findCarousel.StatusId,
                Id = findCarousel.Id
            };
            return View(viewModel);
        }

        public IActionResult Edit(CarouselEditViewModel viewModel)
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
            var editedCarousel = new Carousel()
            {
                Title = viewModel.Title,
                SubTitle = viewModel.SubTitle,
                ImageUrl = uniqueFileName,
                Url = viewModel.Url,
                StatusId = viewModel.StatusId,
                Id = viewModel.Id
            };

            _carouselService.Edit(editedCarousel);
            return RedirectToAction("Index");
        }

        public IActionResult Publish(int id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _carouselService.Publish(id);
            return RedirectToAction("Index");
        }

        public IActionResult Draft(int id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _carouselService.Draft(id);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            _carouselService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}