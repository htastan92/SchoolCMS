using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class MemberService : IMemberService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MemberService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Member Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Members.FirstOrDefault(m => m.Id == id && m.StatusId == (int)Statuses.Published);
            }
        }
        public Member Get(string oldPassword)
        {
            using (var db = new SchoolContext())
            {
                return db.Members.FirstOrDefault(m => m.Password == oldPassword && m.StatusId == (int)Statuses.Published);
            }
        }

        public IList<Member> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Members
                    .Where(m => m.StatusId != (int)Statuses.Removed)
                    .ToList();
            }
        }

        public int New(Member member)
        {
            using (var db = new SchoolContext())
            {
                db.Members.Add(member);
                db.SaveChanges();
            }

            return member.Id;
        }

        public int Edit(Member member)
        {
            using (var db = new SchoolContext())
            {
                db.Members.Update(member);
                db.SaveChanges();
            }

            return member.Id;
        }

        public bool Publish(int id)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findMember = db.Members.Find(id);
                    findMember.StatusId = (int)Statuses.Published;
                    db.Entry(findMember).State = EntityState.Modified;
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
                    var findMember = db.Members.Find(id);
                    findMember.StatusId = (int)Statuses.Draft;
                    db.Entry(findMember).State = EntityState.Modified;
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
                    var findMember = db.Members.Find(id);
                    findMember.StatusId = (int)Statuses.Removed;
                    db.Entry(findMember).State = EntityState.Modified;
                    db.SaveChanges();
                }

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

        public Member GetLoginedMember(string username, string password)
        {
            using (var db = new SchoolContext())
            {
                return db.Members.FirstOrDefault(m => m.Username == username && m.Password == password);
            }
        }

        public bool ChangePassword(string oldPassword,string newPassword,int memberId)
        {
            try
            {
                using (var db = new SchoolContext())
                {
                    var findMember = Get(memberId);
                    if (findMember!=null)
                    {
                        if (findMember.Password!=oldPassword)
                        {
                            return false;
                        }
                        else
                        {
                            findMember.Password = newPassword;
                            db.Entry(findMember).State = EntityState.Modified;
                            db.SaveChanges();
                            return true;
                        }

                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface IMemberService
    {
        Member Get(int id);
        Member Get(string oldPassword);
        IList<Member> GetAll();
        int New(Member member);
        int Edit(Member member);
        bool Publish(int id);
        bool Draft(int id);
        bool Remove(int id);
        bool CheckLogin(string username, string password);
        Member GetLoginedMember(string username, string password);
        bool ChangePassword(string oldPassword, string newPassword,int memberId);
    }
}
