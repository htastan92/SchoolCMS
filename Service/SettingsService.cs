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
            _unitOfWork = unitOfWork;
        }

        public Settings Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Settings.FirstOrDefault(s => s.Id == id);
            }
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
    }
}
