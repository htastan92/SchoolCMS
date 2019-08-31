using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.Models;
using Service;

namespace Product.Components
{
    public class CarouselViewComponent : ViewComponent
    {
        private readonly CarouselService _carouselService = new CarouselService();

         public IViewComponentResult Invoke()
        {
            CarouselViewModel viewModel = new CarouselViewModel()
            {
                Carousels = _carouselService.GetAllWeb()
            };

            return View("~/Views/Shared/CarouselPartial.cshtml", viewModel);
        }
    }
}
