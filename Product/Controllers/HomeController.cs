using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Service;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICampusService _campusService;
        private readonly IPageService _pageService;
        private readonly IEventService _eventService;
        private readonly INewsService _newsService;
        private readonly ICarouselService _carouselService;
        private readonly IReviewService _reviewService;
        private readonly IFormService _formService;

        public HomeController(INewsService newsService, IEventService eventService,
            IPageService pageService, ICampusService campusService,
            ICarouselService carouselService, IReviewService reviewService,IFormService formService)
        {
            _newsService = newsService;
            _eventService = eventService;
            _pageService = pageService;
            _campusService = campusService;
            _carouselService = carouselService;
            _reviewService = reviewService;
            _formService = formService;
        }

        [Route("")]
        public IActionResult Index()
        {
            HomepageViewModel viewModel = new HomepageViewModel
            {
                Carousels = _carouselService.GetAllWeb(),
                UpcomingEvents = _eventService.UpcomingEvents(),
                Reviews = _reviewService.GetAllWeb(),
                LastNews = _newsService.LastNewsHomepage()
            };

            return View(viewModel);
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
                ImageUrl = findCampus.ImageUrl,
                Telephone = findCampus.Telephone,
                Events = findCampus.Events.ToList(),
                News = findCampus.News.OrderByDescending(n => n.CreationDate).Take(5).ToList(),
                Staff = findCampus.Staff.ToList()
            };

            return View(viewModel);
        }

        public IActionResult About()
        {
            return View();
        }
        [Route("sayfa/{pageSlug}")]
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
                ImageUrl = findPage.ImageUrl
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
                Slug = findEvent.Slug,
                EditorContent = findEvent.EditorContent,
                Description = findEvent.Description,
                ImageUrl = findEvent.ImageUrl,
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
                ImageUrl = findNews.ImageUrl,
                EditorContent = findNews.EditorContent,
                Categories = findCategoriesOfNews
            };

            return View(viewModel);
        }

        [Route("iletisim")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var newForm = new Form()
            {
                ParentFullName = viewModel.ParentFullName,
                StudentFullName = viewModel.StudentFullName,
                EmailAddress = viewModel.EmailAddress,
                TelephoneNumber = viewModel.TelephoneNumber,
                CampusId = viewModel.CampusId,
                SentDate = DateTime.Now
            };
            _formService.New(newForm);
            return RedirectToAction("Index");
        }
        public PartialViewResult HeaderPartial()
        {
            HeaderPartialViewModel viewModel = new HeaderPartialViewModel
            {
                HeaderMenuElements = new List<MenuElement>
                {
                    new MenuElement{Id = 1, Name = "Üst Menü 01", Url = "/ustmenu01"},
                    new MenuElement{Id = 2, Name = "Üst Menü 02", Url = "/ustmenu02" },
                    new MenuElement{Id = 3, Name = "Üst Menü 03", Url = "/ustmenu03" }
                }
            };

            return PartialView("HeaderPartial", viewModel);
        }
    }
}
