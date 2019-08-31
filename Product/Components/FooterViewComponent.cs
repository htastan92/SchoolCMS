using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Service;

namespace Product.Components
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly SettingsService _settingsService = new SettingsService();
        private readonly MenuService _menuService = new MenuService();


        public IViewComponentResult Invoke()
        {
            FooterViewModel viewModel = new FooterViewModel
            {
                Settings = _settingsService.Get(),
                FooterMenu = _menuService.GetAllFooter()
            };

            return View("~/Views/Shared/FooterPartial.cshtml", viewModel);
        }
    }
}
