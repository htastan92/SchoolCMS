using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class FormService
    {
        private readonly UnitOfWork _unitOfWork;

        public FormService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Form Get(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Forms.FirstOrDefault(f => f.Id == id);
            }
        }

        public IList<Form> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Forms.ToList();
            }
        }

        public int New(Form form)
        {
            using (var db = new SchoolContext())
            {
                db.Forms.Add(form);
                _unitOfWork.SaveChanges();
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
                    _unitOfWork.SaveChanges();
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
