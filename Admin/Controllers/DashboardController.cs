using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DashboardService _dashboardService;

        public DashboardController(DashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            DashboardViewModel viewModel = new DashboardViewModel()
            {
                CampusCount = _dashboardService.CampusCount(),
                EventCount = _dashboardService.EventCount(),
                FormCount = _dashboardService.FormCount(),
                MemberCount = _dashboardService.MemberCount(),
                MenuElementCount = _dashboardService.MenuElementCount(),
                NewsCount = _dashboardService.NewsCount(),
                PageCount = _dashboardService.PageCount(),
                StaffCount = _dashboardService.StaffCount()
            };
            return View(viewModel);
        }
    }
}