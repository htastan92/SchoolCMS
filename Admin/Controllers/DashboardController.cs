using Admin.Helper;
using Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Admin.Controllers
{
    [SessionFilter]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService)
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