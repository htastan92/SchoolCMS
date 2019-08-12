using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class MenuService :IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public MenuElement GetAdmin(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.FirstOrDefault(m => m.Id == id && m.Status.Id != (int)Statuses.Removed);
            }
        }

        public MenuElement GetWeb(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.FirstOrDefault(m => m.Id == id && m.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<MenuElement> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements
                    .Where(m => m.Status.Id != (int)Statuses.Removed)
                    .ToList();
            }
        }

        public IList<MenuElement> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements
                    .Where(m => m.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public IList<MenuElement> GetAllHeader()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements
                    .Where(m => m.MenuLocation == (int)MenuLocations.Header && m.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public IList<MenuElement> GetAllFooter()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements
                    .Where(m => m.MenuLocation == (int)MenuLocations.Footer && m.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public int New(MenuElement menuElement)
        {
            using (var db = new SchoolContext())
            {
                db.MenuElements.Add(menuElement);
                _unitOfWork.SaveChanges();
            }

            return menuElement.Id;
        }

        public int Edit(MenuElement menuElement)
        {
            using (var db = new SchoolContext())
            {
                db.MenuElements.Update(menuElement);
                _unitOfWork.SaveChanges();
            }

            return menuElement.Id;
        }

        public bool Publish(int id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int)Statuses.Published;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Draft(int id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int)Statuses.Draft;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int)Statuses.Removed;
                _unitOfWork.SaveChanges();
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
        MenuElement GetAdmin(int id);
        MenuElement GetWeb(int id);
        IList<MenuElement> GetAllAdmin();
        IList<MenuElement> GetAllWeb();
        IList<MenuElement> GetAllHeader();
        IList<MenuElement> GetAllFooter();
        int New(MenuElement menuElement);
        int Edit(MenuElement menuElement);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
    }
}
