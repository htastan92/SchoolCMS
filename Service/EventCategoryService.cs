using Data;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class EventCategoryService:IEventCategoryService
    {
            private readonly IUnitOfWork _unitOfWork;

        public EventCategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EventCategory Get(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.EventCategories.Include(s=>s.Status).FirstOrDefault(e => e.Id == id && e.Status.Id != (int)Statuses.Removed);
            }
        }

        public IList<EventCategory> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.EventCategories.Include(s=>s.Status).Where(e => e.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public int New(EventCategory addEventCategory)
        {
            using (var db = new SchoolContext())
            {
                db.EventCategories.Add(addEventCategory);
                db.SaveChanges();
               // _unitOfWork.SaveChanges();
            }

            return addEventCategory.Id;
        }

        public int Edit(EventCategory editEventCategory)
        {
            using (var db = new SchoolContext())
            {
                db.EventCategories.Update(editEventCategory);
                db.SaveChanges();
            }

            return editEventCategory.Id;
        }

        public bool Draft(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findEventCategory = db.EventCategories.Find(id);
                    findEventCategory.StatusId = (int)Statuses.Draft;
                    db.Entry(findEventCategory).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Publish(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findEventCategory = db.EventCategories.Find(id);
                    findEventCategory.StatusId = (int)Statuses.Published;
                    db.Entry(findEventCategory).State = EntityState.Modified;
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
                    var findEventCategory = db.EventCategories.Find(id);
                    findEventCategory.StatusId = (int)Statuses.Removed;
                    db.Entry(findEventCategory).State = EntityState.Modified;
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

    public interface IEventCategoryService
    {
        EventCategory Get(int? id);
        IList<EventCategory> GetAll();
        int New(EventCategory addEventCategory);
        int Edit(EventCategory editEventCategory);
        bool Draft(int? id);
        bool Publish(int? id);
        bool Remove(int? id);
    }
}
