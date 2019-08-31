using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class SettingsService : ISettingsService
    {
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
                db.SaveChanges();
            }

            return editedSettings.Id;
        }
    }

    public interface ISettingsService
    {
        Settings Get();
        int Edit(Settings editedSettings);
    }
}
