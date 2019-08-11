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
            this._unitOfWork = unitOfWork;
        }

        public Staff Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Staff.FirstOrDefault(s => s.Id == id);
            }
        }

        public IList<Staff> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Staff.ToList();
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

        public void Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var staff = db.Staff.FirstOrDefault(s => s.Id == id);
                if (staff!=null)
                {
                    db.Staff.Remove(staff);
                    _unitOfWork.SaveChanges();
                }
            }
        }
    }
}
