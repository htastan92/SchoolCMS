using Microsoft.AspNetCore.Mvc;

namespace Product.Controllers
{
    public class HomeController : Controller
    {
        private readonly CampusService _campusService = new CampusService();
        private readonly PageService _pageService = new PageService();
        private readonly EventService _eventService = new EventService();
        private readonly NewsService _newsService = new NewsService();

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
            // Find Campus
            // If null Error 404
            // Else create viewModel via campus and return view with viewModel
            return View();
        }

        [Route("{pageSlug}")]
        public IActionResult PageDetail(string pageSlug)
        {
            // Find Page
            // If null Error 404
            // Else create viewModel via page and return view with viewModel
            return View();
        }

        [Route("etkinlikler")]
        public IActionResult EventList()
        {
            // GetAll in viewModel and return viewmodel in View
            return View();
        }

        [Route("etkinlikler/{eventSlug}")]
        public IActionResult EventDetail(string eventSlug)
        {
            // Find Event
            // If null Error 404
            // Else create viewModel via event and return view with viewModel
            return View();
        }

        [Route("haberler")]
        public IActionResult NewsList()
        {
            // GetAll in viewModel and return viewmodel in View
            return View();
        }

        [Route("haberler/{newsSlug}")]
        public IActionResult NewsDetail(string newsSlug)
        {
            // Find News
            // If null Error 404
            // Else create viewModel via news and return view with viewModel
            return View();
        }
    }
}
