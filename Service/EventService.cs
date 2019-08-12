﻿using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class EventService
    {
        private readonly UnitOfWork _unitOfWork;

        public EventService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Event GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Events.FirstOrDefault(e => e.Id == id && e.Status.Id != (int)Statuses.Removed);
            }
        }

        public Event GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.Events.FirstOrDefault(e => e.Slug == slug && e.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Event> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Events.Where(e => e.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public IList<Event> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Events.Where(e => e.Status.Id == (int)Statuses.Published).ToList();
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
                _unitOfWork.SaveChanges();
            }

            return addEvent.Id;
        }

        public int Edit(Event editEvent)
        {
            using (var db = new SchoolContext())
            {
                db.Events.Update(editEvent);
                _unitOfWork.SaveChanges();
            }

            return editEvent.Id;
        }

        public bool Draft(int? id)
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

        public bool Publish(int? id)
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

        public bool Remove(int? id)
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
}
