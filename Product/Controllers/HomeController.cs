using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Service;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        private readonly CampusService _campusService;
        private readonly PageService _pageService;
        private readonly EventService _eventService;
        private readonly NewsService _newsService;

        public HomeController(NewsService newsService, EventService eventService, PageService pageService, CampusService campusService)
        {
            _newsService = newsService;
            _eventService = eventService;
            _pageService = pageService;
            _campusService = campusService;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("404")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("sitemap")]
        public IActionResult Sitemap()
        {
            return View();
        }

        [Route("kampus/{campusSlug}")]
        public IActionResult CampusDetail(string campusSlug)
        {
            if (campusSlug == null)
                return RedirectToAction("Error");

            var findCampus = _campusService.GetWeb(campusSlug);
            if (findCampus == null)
                return RedirectToAction("Error");

            CampusDetailViewModel viewModel = new CampusDetailViewModel
            {
                Name = findCampus.Name,
                Address = findCampus.Address,
                Description = findCampus.Description,
                EditorContent = findCampus.EditorContent,
                EmailAddress = findCampus.EmailAddress,
                Fax = findCampus.Fax,
                ImageUrl = findCampus.Image.Url,
                Telephone = findCampus.Telephone,
                Events = findCampus.Events.ToList(),
                News = findCampus.News.ToList(),
                Staff = findCampus.Staff.ToList()
            };

            return View(viewModel);
        }

        [Route("{pageSlug}")]
        public IActionResult PageDetail(string pageSlug)
        {
            if (pageSlug == null)
                return RedirectToAction("Error");

            var findPage = _pageService.GetWeb(pageSlug);
            if (findPage == null)
                return RedirectToAction("Error");

            PageDetailViewModel viewModel = new PageDetailViewModel
            {
                Name = findPage.Name,
                EditorContent = findPage.EditorContent,
                Description = findPage.Description,
                ImageUrl = findPage.Image.Url
            };

            return View(viewModel);
        }

        [Route("etkinlikler")]
        public IActionResult EventList()
        {
            EventListViewModel viewModel = new EventListViewModel
            {
                Events = _eventService.GetAllWeb()
            };

            return View(viewModel);
        }

        [Route("etkinlikler/{eventSlug}")]
        public IActionResult EventDetail(string eventSlug)
        {
            if (eventSlug == null)
                return RedirectToAction("Error");

            var findEvent = _eventService.GetWeb(eventSlug);
            if (findEvent == null)
                return RedirectToAction("Error");

            var findCategoriesOfEvent = _eventService.GetEventCategories(findEvent.Id);

            EventDetailViewModel viewModel = new EventDetailViewModel
            {
                EditorContent = findEvent.EditorContent,
                Description = findEvent.Description,
                ImageUrl = findEvent.Image.Url,
                Name = findEvent.Name,
                Categories = findCategoriesOfEvent,
                CampusId = findEvent.Campus.Id,
                StartDate = findEvent.StartDate,
                EndDate = findEvent.EndDate,
                Location = findEvent.Location,
            };

            return View(viewModel);
        }

        [Route("haberler")]
        public IActionResult NewsList()
        {
            NewsListViewModel viewModel = new NewsListViewModel
            {
                News = _newsService.GetAllWeb()
            };

            return View(viewModel);
        }

        [Route("haberler/{newsSlug}")]
        public IActionResult NewsDetail(string newsSlug)
        {
            if (newsSlug == null)
                return RedirectToAction("Error");

            var findNews = _newsService.GetWeb(newsSlug);
            if (findNews == null)
                return RedirectToAction("Error");

            var findCategoriesOfNews = _newsService.GetNewsCategories(findNews.Id);

            NewsDetailViewModel viewModel = new NewsDetailViewModel
            {
                Name = findNews.Name,
                Description = findNews.Description,
                ImageUrl = findNews.Image.Url,
                EditorContent = findNews.EditorContent,
                Categories = findCategoriesOfNews
            };

            return View(viewModel);
        }
    }
}
