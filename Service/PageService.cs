using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class PageService
    {
        private readonly UnitOfWork _unitOfWork;

        public PageService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Page GetAdmin(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.FirstOrDefault(p => p.Id == id && p.Status.Id != (int) Statuses.Removed);
            }
        }

        public Page GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.FirstOrDefault(p => p.Slug == slug && p.Status.Id == (int) Statuses.Published);
            }
        }

        public IList<Page> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.Where(p => p.Status.Id != (int) Statuses.Removed).ToList();
            }
        }
        public IList<Page> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.Where(p => p.Status.Id == (int) Statuses.Published).ToList();
            }
        }

        public int New(Page page)
        {
            using (var db = new SchoolContext())
            {
                db.Pages.Add(page);
                _unitOfWork.SaveChanges();
            }

            return page.Id;
        }
        public int Edit(Page page)
        {
            using (var db = new SchoolContext())
            {
                db.Pages.Update(page);
                _unitOfWork.SaveChanges();
            }

            return page.Id;
        }

        public bool Draft(int id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int) Statuses.Draft;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool Publish(int id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int) Statuses.Published;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int) Statuses.Removed;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
