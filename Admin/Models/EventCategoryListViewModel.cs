using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace Admin.Models
{
    public class EventCategoryListViewModel
    {
        public IList<EventCategory> EventCategories { get; set; }
    }
}
