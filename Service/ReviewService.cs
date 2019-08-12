using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Review GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Reviews.FirstOrDefault(e => e.Id == id && e.Status.Id != (int)Statuses.Removed);
            }
        }

        public Review GetWeb(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Reviews.FirstOrDefault(e => e.Id == id && e.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Review> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Reviews.Where(e => e.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public IList<Review> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Reviews.Where(e => e.Status.Id == (int)Statuses.Published).ToList();
            }
        }

        public int New(Review review)
        {
            using (var db = new SchoolContext())
            {
                db.Reviews.Add(review);
                _unitOfWork.SaveChanges();
            }

            return review.Id;
        }

        public int Edit(Review review)
        {
            using (var db = new SchoolContext())
            {
                db.Reviews.Update(review);
                _unitOfWork.SaveChanges();
            }

            return review.Id;
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

    public interface IReviewService
    {
        Review GetAdmin(int? id);
        Review GetWeb(int? id);
        IList<Review> GetAllAdmin();
        IList<Review> GetAllWeb();
        int New(Review review);
        int Edit(Review review);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
    }
}
