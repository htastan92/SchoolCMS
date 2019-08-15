using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class FormService:IFormService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FormService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Form Get(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Forms.Include(c=>c.Campus).FirstOrDefault(f => f.Id == id);
            }
        }

        public IList<Form> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Forms.Include(c=>c.Campus).ToList();
            }
        }

        public int New(Form form)
        {
            using (var db = new SchoolContext())
            {
                db.Forms.Add(form);
                db.SaveChanges();
            }

            return form.Id;
        }

        public void Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var form = db.Forms.FirstOrDefault(i => i.Id == id);
                if (form != null)
                {
                    db.Forms.Remove(form);
                    db.SaveChanges();
                }
            }
        }
    }

    public interface IFormService
    {
        Form Get(int? id);
        IList<Form> GetAll();
        int New(Form form);
        void Delete(int id);

    }
}
