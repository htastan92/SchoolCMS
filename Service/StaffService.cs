using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class StaffService
    {
        private readonly UnitOfWork _unitOfWork;

        public StaffService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Staff GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Staff.FirstOrDefault(s => s.Id == id && s.Status.Id != (int)Statuses.Removed);
            }
        }

        public Staff GetWeb(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Staff.FirstOrDefault(s => s.Id == id && s.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Staff> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Staff
                    .Where(s => s.Status.Id != (int)Statuses.Removed)
                    .ToList();
            }
        }

        public IList<Staff> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Staff
                    .Where(s => s.Status.Id == (int)Statuses.Published)
                    .ToList();
            }
        }

        public int New(Staff staff)
        {
            using (var db = new SchoolContext())
            {
                db.Staff.Add(staff);
                _unitOfWork.SaveChanges();
            }

            return staff.Id;
        }

        public int Edit(Staff staff)
        {
            using (var db = new SchoolContext())
            {
                db.Staff.Update(staff);
                _unitOfWork.SaveChanges();
            }

            return staff.Id;
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
}
