using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class StaffService:IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
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
                    .Include(s => s.Status)
                    .Include(s => s.Campus)
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
                db.SaveChanges();
                //_unitOfWork.SaveChanges();
            }

            return staff.Id;
        }

        public int Edit(Staff staff)
        {
            using (var db = new SchoolContext())
            {
                db.Staff.Update(staff);
                db.SaveChanges();
               // _unitOfWork.SaveChanges();
            }

            return staff.Id;
        }

        public bool Publish(int? id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findsStaff = db.Staff.Find(id);
                    findsStaff.StatusId = (int)Statuses.Published;
                    db.Entry(findsStaff).State = EntityState.Modified;
                    db.SaveChanges();
                }

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
                using (var db = new SchoolContext())
                {
                    var findsStaff = db.Staff.Find(id);
                    findsStaff.StatusId = (int)Statuses.Draft;
                    db.Entry(findsStaff).State = EntityState.Modified;
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
                    var findsStaff = db.Staff.Find(id);
                    findsStaff.StatusId = (int)Statuses.Removed;
                    db.Entry(findsStaff).State = EntityState.Modified;
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

    public interface IStaffService
    {
        Staff GetAdmin(int? id);
        Staff GetWeb(int? id);
        IList<Staff> GetAllAdmin(); 
        IList<Staff> GetAllWeb();
        int New(Staff staff);
        int Edit(Staff staff);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
    }
}
