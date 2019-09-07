using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models
{
    public class CarouselListViewModel
    {
        public IList<Carousel> Carousels { get; set; }
    }
}
