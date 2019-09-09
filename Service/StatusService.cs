using System;
using System.Collections.Generic;
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

        public IList<Status> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Statuses.Where(s=>s.Id != (int)Statuses.Removed).ToList();
            }
        }
    }

    public interface IStatusService
    {
        Status Get(int id);
        IList<Status> GetAll();
    }
}
