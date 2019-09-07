using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class CarouselService : ICarouselService
    {

        public Carousel GetAdmin(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Carousels.FirstOrDefault(c => c.Id == id && c.Status.Id != (int)Statuses.Removed);
            }
        }

        public Carousel GetWeb(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Carousels.FirstOrDefault(c => c.Id == id && c.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Carousel> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Carousels.Include(x=>x.Status)
                    .Where(c => c.Status.Id != (int)Statuses.Removed)
                    .ToList();
            }
        }

        public IList<Carousel> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Carousels
                    .Where(c => c.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public int New(Carousel carousel)
        {
            using (var db = new SchoolContext())
            {
                db.Carousels.Add(carousel);
                db.SaveChanges();
            }

            return carousel.Id;
        }

        public int Edit(Carousel carousel)
        {
            using (var db = new SchoolContext())
            {
                db.Carousels.Update(carousel);
                db.SaveChanges();
            }

            return carousel.Id;
        }

        public bool Publish(int id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findCarousel = db.Carousels.Find(id);
                    findCarousel.StatusId = (int)Statuses.Published;
                    db.Entry(findCarousel).State = EntityState.Modified;
                    db.SaveChanges();
                }

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
                using (var db = new SchoolContext())
                {
                    var findCarousel = db.Carousels.Find(id);
                    findCarousel.StatusId = (int)Statuses.Draft;
                    db.Entry(findCarousel).State = EntityState.Modified;
                    db.SaveChanges();
                }
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
                using (var db = new SchoolContext())
                {
                    var findCarousel = db.Carousels.Find(id);
                    findCarousel.StatusId = (int)Statuses.Removed;
                    db.Entry(findCarousel).State = EntityState.Modified;
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

    public interface ICarouselService
    {
        Carousel GetAdmin(int id);
        Carousel GetWeb(int id);
        IList<Carousel> GetAllAdmin();
        IList<Carousel> GetAllWeb();
        int New(Carousel carousel);
        int Edit(Carousel carousel);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
    }
}
