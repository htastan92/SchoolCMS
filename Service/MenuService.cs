using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class MenuService :IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MenuElement GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.Include(s=>s.Status).Include(pm=>pm.ParentMenu).FirstOrDefault(m => m.Id == id && m.Status.Id != (int)Statuses.Removed);
            }
        }

        public MenuElement GetWeb(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.Include(s=>s.Status).Include(pm=>pm.ParentMenu).FirstOrDefault(m => m.Id == id && m.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<MenuElement> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.Include(p=>p.ParentMenu).Include(s=>s.Status)
                    .Where(m => m.Status.Id != (int)Statuses.Removed)
                    .ToList();
            }
        }

        public IList<MenuElement> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.Include(s=>s.Status).Include(pm=>pm.ParentMenu)
                    .Where(m => m.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public IList<MenuElement> GetAllHeader()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.Include(s=>s.Status).Include(pm=>pm.ParentMenu)
                    .Where(m => m.MenuLocation == (int)MenuLocations.Header && m.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public IList<MenuElement> GetAllFooter()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.Include(s=>s.Status).Include(pm=>pm.ParentMenu)
                    .Where(m => m.MenuLocation == (int)MenuLocations.Footer && m.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public int New(MenuElement menuElement)
        {
            using (var db = new SchoolContext())
            {
                db.MenuElements.Add(menuElement);
                db.SaveChanges();
            }

            return menuElement.Id;
        }

        public int Edit(MenuElement menuElement)
        {
            using (var db = new SchoolContext())
            {
                db.MenuElements.Update(menuElement);
                db.SaveChanges();
            }

            return menuElement.Id;
        }

        public bool Publish(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findMenu = db.MenuElements.Find(id);
                    findMenu.StatusId = (int)Statuses.Published;
                    db.Entry(findMenu).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Draft(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findMenu = db.MenuElements.Find(id);
                    findMenu.StatusId = (int)Statuses.Draft;
                    db.Entry(findMenu).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findMenu = db.MenuElements.Find(id);
                    findMenu.StatusId = (int)Statuses.Removed;
                    db.Entry(findMenu).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IMenuService
    {
        MenuElement GetAdmin(int? id);
        MenuElement GetWeb(int? id);
        IList<MenuElement> GetAllAdmin();
        IList<MenuElement> GetAllWeb();
        IList<MenuElement> GetAllHeader();
        IList<MenuElement> GetAllFooter();
        int New(MenuElement menuElement);
        int Edit(MenuElement menuElement);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
    }
}
