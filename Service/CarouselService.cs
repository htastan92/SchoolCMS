using System;
using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class CarouselService : ICarouselService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CarouselService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

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
                return db.Carousels
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
                _unitOfWork.SaveChanges();
            }

            return carousel.Id;
        }

        public int Edit(Carousel carousel)
        {
            using (var db = new SchoolContext())
            {
                db.Carousels.Update(carousel);
                _unitOfWork.SaveChanges();
            }

            return carousel.Id;
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
