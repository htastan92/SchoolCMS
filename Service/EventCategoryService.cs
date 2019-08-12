using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Entities;

namespace Service
{
    public class EventCategoryService:IEventCategoryService
    {
            private readonly UnitOfWork _unitOfWork;

        public EventCategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EventCategory Get(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.EventCategories.FirstOrDefault(e => e.Id == id && e.Status.Id != (int)Statuses.Removed);
            }
        }

        public IList<EventCategory> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.EventCategories.Where(e => e.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public int New(EventCategory addEventCategory)
        {
            using (var db = new SchoolContext())
            {
                db.EventCategories.Add(addEventCategory);
                _unitOfWork.SaveChanges();
            }

            return addEventCategory.Id;
        }

        public int Edit(EventCategory editEventCategory)
        {
            using (var db = new SchoolContext())
            {
                db.EventCategories.Update(editEventCategory);
                _unitOfWork.SaveChanges();
            }

            return editEventCategory.Id;
        }

        public bool Draft(int? id)
        {
            try
            {
                Get(id).Status.Id = (int)Statuses.Draft;
                _unitOfWork.SaveChanges();
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
                Get(id).Status.Id = (int)Statuses.Published;
                _unitOfWork.SaveChanges();
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
                Get(id).Status.Id = (int)Statuses.Removed;
                _unitOfWork.SaveChanges();
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
