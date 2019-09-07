using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class CampusService:ICampusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CampusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Campus GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.Include(s=>s.Status).FirstOrDefault(c => c.Id == id && c.Status.Id != (int)Statuses.Removed);
            }
        }

        public Campus GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.FirstOrDefault(c => c.Slug == slug && c.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Campus> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.Include(s=>s.Status).Where(c => c.Status.Id != (int)Statuses.Removed).ToList();
            }

        }

        public IList<Campus> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.Where(c => c.Status.Id == (int)Statuses.Published).ToList();
            }
        }

        public int New(Campus campus)
        {
            using (var db = new SchoolContext())
            {
                db.Campuses.Add(campus);
                db.SaveChanges();
                //_unitOfWork.SaveChanges();
            }

            return campus.Id;
        }

        public int Edit(Campus campus)
        {
            using (var db = new SchoolContext())
            {
                db.Campuses.Update(campus);
                db.SaveChanges();
                // _unitOfWork.SaveChanges();
            }

            return campus.Id;
        }

        public bool Draft(int? id)
        {
            try
            {
               
                using (var db = new SchoolContext())
                {
                    var findCampus = db.Campuses.Find(id);
                    findCampus.StatusId = (int)Statuses.Draft;
                    db.Entry(findCampus).State = EntityState.Modified;
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
                    var findCampus = db.Campuses.Find(id);
                    findCampus.StatusId = (int)Statuses.Published;
                    db.Entry(findCampus).State = EntityState.Modified;
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
                    var findCampus = db.Campuses.Find(id);
                    findCampus.StatusId = (int)Statuses.Removed;
                    db.Entry(findCampus).State = EntityState.Modified;
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

    public interface ICampusService
    {
        Campus GetAdmin(int? id);
        Campus GetWeb(string slug);
        IList<Campus> GetAllAdmin();
        IList<Campus> GetAllWeb();
        int New(Campus campus);
        int Edit(Campus campus);
        bool Draft(int? id);
        bool Publish(int? id);
        bool Remove(int? id);
    }
}
