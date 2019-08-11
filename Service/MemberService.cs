using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
namespace Service
{
    public class MemberService
    {
        private readonly UnitOfWork _unitOfWork;

        public MemberService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Member Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Members.FirstOrDefault(m => m.Id == id && m.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Member> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Members
                    .Where(m => m.Status.Id != (int)Statuses.Removed)
                    .ToList();
            }
        }

        public int New(Member member)
        {
            using (var db = new SchoolContext())
            {
                db.Members.Add(member);
                _unitOfWork.SaveChanges();
            }

            return member.Id;
        }

        public int Edit(Member member)
        {
            using (var db = new SchoolContext())
            {
                db.Members.Update(member);
                _unitOfWork.SaveChanges();
            }

            return member.Id;
        }

        public bool Publish(int id)
        {
            try
            {
                Get(id).Status.Id = (int)Statuses.Published;
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
                Get(id).Status.Id = (int)Statuses.Draft;
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
                Get(id).Status.Id = (int)Statuses.Removed;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CheckLogin(string username, string password)
        {
            using (var db = new SchoolContext())
            {
                return db.Members.Any(m => m.Username == username && m.Password == password);
            }
        }
    }
}
