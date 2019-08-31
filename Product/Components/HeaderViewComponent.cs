using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Service;

namespace Product.Components
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly MenuService _menuService = new MenuService();

        public IViewComponentResult Invoke()
        {
            HeaderPartialViewModel viewModel = new HeaderPartialViewModel()
            {
                HeaderMenuElements = _menuService.GetAllHeader()
            };

            return View("~/Views/Shared/HeaderPartial.cshtml", viewModel);
        }
    }
}
