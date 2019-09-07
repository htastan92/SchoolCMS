using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class PageService:IPageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Page GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.FirstOrDefault(p => p.Id == id && p.Status.Id != (int)Statuses.Removed);
            }
        }

        public Page GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.FirstOrDefault(p => p.Slug == slug && p.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Page> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.Where(p => p.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public IList<Page> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Pages.Where(p => p.Status.Id == (int)Statuses.Published).ToList();
            }
        }

        public int New(Page page)
        {
            using (var db = new SchoolContext())
            {
                db.Pages.Add(page);
                db.SaveChanges();
            }

            return page.Id;
        }

        public int Edit(Page page)
        {
            using (var db = new SchoolContext())
            {
                db.Pages.Update(page);
                db.SaveChanges();
            }

            return page.Id;
        }

        public bool Publish(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findPage = db.Pages.Find(id);
                    findPage.StatusId = (int)Statuses.Published;
                    db.Entry(findPage).State = EntityState.Modified;
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
                    var findPage = db.Pages.Find(id);
                    findPage.StatusId = (int)Statuses.Draft;
                    db.Entry(findPage).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findPage = db.Pages.Find(id);
                    findPage.StatusId = (int)Statuses.Removed;
                    db.Entry(findPage).State = EntityState.Modified;
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

    public interface IPageService
    {
        Page GetAdmin(int? id);
        Page GetWeb(string slug);
        IList<Page> GetAllAdmin();
        IList<Page> GetAllWeb();
        int New(Page page);
        int Edit(Page page);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Delete(int? id);

    }
}
