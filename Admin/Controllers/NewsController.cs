using Admin.Helper;
using Admin.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    [SessionFilter]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public IActionResult Index()
        {
            NewsListViewModel viewModel = new NewsListViewModel()
            {
                News = _newsService.GetAllAdmin()
            };
            return View(viewModel);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(NewsNewViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            News newNews = new News()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                EditorContent = viewModel.EditorContent,
                Slug = viewModel.Slug,
                ImageId = viewModel.ImageId,
                StatusId = viewModel.StatusId
            };
            _newsService.New(newNews);
            return RedirectToAction("Index");
        }

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
                 ImageId = findNews.ImageId,
                 StatusId = findNews.StatusId
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(NewsEditViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            News editedNews = new News()
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Description = viewModel.Description,
                Slug = viewModel.Slug,
                EditorContent = viewModel.EditorContent,
                ImageId = viewModel.ImageId,
                StatusId = viewModel.StatusId
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