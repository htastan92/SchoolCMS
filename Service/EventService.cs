using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Event GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Events.Include(c=>c.Campus).Include(i=>i.Image).Include(s=>s.Status).FirstOrDefault(e => e.Id == id && e.Status.Id != (int)Statuses.Removed);
            }
        }

        public Event GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.Events.Include(c=>c.Campus).Include(i=>i.Image).Include(s=>s.Status).FirstOrDefault(e => e.Slug == slug && e.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Event> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Events.Include(c=>c.Campus).Include(i=>i.Image).Include(s=>s.Status).Where(e => e.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public IList<Event> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Events.Include(c=>c.Campus).Include(i=>i.Image).Include(s=>s.Status).Where(e => e.Status.Id == (int)Statuses.Published).ToList();
            }
        }

        public IList<Event> UpcomingEvents()
        {
            using (var db = new SchoolContext())
            {
                return db.Events
                    .Where(e => e.Status.Id == (int)Statuses.Published && e.StartDate > DateTime.Now)
                    .OrderBy(e => e.EndDate)
                    .Take(8)
                    .ToList();
            }

        }

        public IList<EventCategory> GetEventCategories(int eventId)
        {
            IList<EventCategory> eventCategories = new List<EventCategory>();
            using (var db = new SchoolContext())
            {
                var categoriesOfEvent = db.EventCategoryEvent
                    .Where(ece => ece.EventId == eventId)
                    .Select(ece => ece.EventCategory).ToList();
                foreach (var category in categoriesOfEvent)
                {
                    eventCategories.Add(category);
                }
            }

            return eventCategories;
        }

        public int New(Event addEvent)
        {
            using (var db = new SchoolContext())
            {
                db.Events.Add(addEvent);
                db.SaveChanges();
                // _unitOfWork.SaveChanges();
            }

            return addEvent.Id;
        }

        public int Edit(Event editEvent)
        {
            using (var db = new SchoolContext())
            {
                db.Events.Update(editEvent);
                db.SaveChanges();
                //_unitOfWork.SaveChanges();
            }

            return editEvent.Id;
        }

        public bool Draft(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findEvent = db.Events.Find(id);
                    findEvent.StatusId = (int)Statuses.Draft;
                    db.Entry(findEvent).State = EntityState.Modified;
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
                    var findEvent = db.Events.Find(id);
                    findEvent.StatusId = (int)Statuses.Published;
                    db.Entry(findEvent).State = EntityState.Modified;
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
                    var findEvent = db.Events.Find(id);
                    findEvent.StatusId = (int)Statuses.Removed;
                    db.Entry(findEvent).State = EntityState.Modified;
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

    public interface IEventService
    {
        Event GetAdmin(int? id);
        Event GetWeb(string slug);
        IList<Event> GetAllAdmin();
        IList<Event> GetAllWeb();
        IList<Event> UpcomingEvents();
        int New(Event addEvent);
        int Edit(Event editEvent);
        bool Draft(int? id);
        bool Publish(int? id);
        bool Remove(int? id);
        IList<EventCategory> GetEventCategories(int eventId);
    }
}
