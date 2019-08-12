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

        public Settings Get()
        {
            using (var db = new SchoolContext())
            {
                return db.Settings.FirstOrDefault();
            }
        }

        public int Edit(Settings editedSettings)
        {
            using (var db = new SchoolContext())
            {
                db.Settings.Update(editedSettings);
                _unitOfWork.SaveChanges();
            }

            return editedSettings.Id;
        }
    }
}
