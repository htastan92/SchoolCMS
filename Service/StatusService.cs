using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class StatusService:IStatusService
    {
        public Status Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Statuses.FirstOrDefault(s => s.Id == id);
            }
        }
    }

    public interface IStatusService
    {
        Status Get(int id);
    }
}
