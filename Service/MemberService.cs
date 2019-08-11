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
            this._unitOfWork = unitOfWork;
        }

        public Member Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Members.FirstOrDefault(m => m.Id == id);
            }
        }

        public IList<Member> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Members.ToList();
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
            using (var db=new SchoolContext())
            {
                db.Members.Update(member);
                _unitOfWork.SaveChanges();
            }

            return member.Id;
        }

        public void Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var member = db.Members.FirstOrDefault(m=>m.Id==id);
                if (member!=null)
                {
                    db.Members.Remove(member);
                    _unitOfWork.SaveChanges();
                }
            }
        }
    }
}
