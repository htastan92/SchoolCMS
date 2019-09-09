﻿using System.Collections.Generic;
using Entities;

namespace Admin.Models
{
    public class NewsListViewModel
    {
        public IList<News> News { get; set; }
        public IList<Status> Statuses { get; set; }
    }
}
