using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Admin.Helper
{
    public class SelectListHelper
    {
        public static SelectList StatusSelectList()
        {
            IEnumerable<Status> statuses;
            using (SchoolContext db = new SchoolContext())
            {
                statuses = db.Statuses.ToList();
            }

            SelectList statuList = new SelectList(statuses, "Id", "Name");
            return statuList;
        }

        public static SelectList EventCategorySelectList()
        {
            IEnumerable<EventCategory> eventCategories;
            using (SchoolContext db = new SchoolContext())
            {
                eventCategories = db.EventCategories.ToList();
            }

            SelectList eventCategoryList = new SelectList(eventCategories, "Id", "Name");
            return eventCategoryList;
        }
        public static SelectList newsCategorySelectList()
        {
            IEnumerable<NewsCategory> newsCategories;
            using (SchoolContext db = new SchoolContext())
            {
                newsCategories = db.NewsCategories.ToList();
            }

            SelectList newsCategoryList = new SelectList(newsCategories, "Id", "Name");
            return newsCategoryList;
        }
        public static SelectList campusSelectList()
        {
            IEnumerable<Campus> campuses;
            using (SchoolContext db = new SchoolContext())
            {
                campuses = db.Campuses.ToList();
            }

            SelectList campuSelectList = new SelectList(campuses, "Id", "Name");
            return campuSelectList;
        }

        public static SelectList parentMenuSelectList()
        {
            IEnumerable<MenuElement> menuElements;
            using (SchoolContext db = new SchoolContext())
            {
                menuElements = db.MenuElements.ToList();
            }

            SelectList menuElementList = new SelectList(menuElements, "Id", "Name");
            return menuElementList;
        }
    }
}
