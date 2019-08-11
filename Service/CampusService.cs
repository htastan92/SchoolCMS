using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class CampusService
    {
        private readonly UnitOfWork _unitOfWork;

        public CampusService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Campus GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.FirstOrDefault(c => c.Id == id && c.Status.Id != (int)Statuses.Removed);
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
                return db.Campuses.Where(c => c.Status.Id != (int)Statuses.Removed).ToList();
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
                _unitOfWork.SaveChanges();
            }

            return campus.Id;
        }

        public int Edit(Campus campus)
        {
            using (var db = new SchoolContext())
            {
                db.Campuses.Update(campus);
                _unitOfWork.SaveChanges();
            }

            return campus.Id;
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
