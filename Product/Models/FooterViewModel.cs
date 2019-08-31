using System.Collections.Generic;
using Entities;

namespace Product.Models
{
    public class FooterViewModel
    {
        public Settings Settings { get; set; }
        public IList<MenuElement> FooterMenu { get; set; }
    }
}
