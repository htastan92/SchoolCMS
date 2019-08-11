using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class SettingsService
    {
        private readonly UnitOfWork _unitOfWork;

        public SettingsService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Settings Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Settings.FirstOrDefault(s => s.Id == id);
            }
        }

        public IList<Settings> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Settings.ToList();
            }
        }

        public int New(Settings settings)
        {
            using (var db = new SchoolContext())
            {
                db.Settings.Add(settings);
                _unitOfWork.SaveChanges();
            }

            return settings.Id;
        }
        public int Edit(Settings settings)
        {
            using (var db = new SchoolContext())
            {
                db.Settings.Update(settings);
                _unitOfWork.SaveChanges();
            }

            return settings.Id;
        }

        public void Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var settings = db.Settings.FirstOrDefault(s => s.Id == id);
                if (settings!=null)
                {
                    db.Settings.Remove(settings);
                    _unitOfWork.SaveChanges();
                }
            }
        }
    }
}
