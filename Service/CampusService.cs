﻿using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class CampusService:ICampusService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CampusService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Campus GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.FirstOrDefault(c => c.Id == id && c.Status.Id != (int)Statuses.Removed);
            }
        }

        public Campus GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.FirstOrDefault(c => c.Slug == slug && c.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<Campus> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.Where(c => c.Status.Id != (int)Statuses.Removed).ToList();
            }

        }

        public IList<Campus> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.Campuses.Where(c => c.Status.Id == (int)Statuses.Published).ToList();
            }
        }

        public int New(Campus campus)
        {
            using (var db = new SchoolContext())
            {
                db.Campuses.Add(campus);
                _unitOfWork.SaveChanges();
            }

            return campus.Id;
        }

        public int Edit(Campus campus)
        {
            using (var db = new SchoolContext())
            {
                db.Campuses.Update(campus);
                _unitOfWork.SaveChanges();
            }

            return campus.Id;
        }

        public bool Draft(int? id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int)Statuses.Draft;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Publish(int? id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int)Statuses.Published;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Remove(int? id)
        {
            try
            {
                GetAdmin(id).Status.Id = (int)Statuses.Removed;
                _unitOfWork.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public interface ICampusService
    {
        Campus GetAdmin(int? id);
        Campus GetWeb(string slug);
        IList<Campus> GetAllAdmin();
        IList<Campus> GetAllWeb();
        int New(Campus campus);
        int Edit(Campus campus);
        bool Draft(int? id);
        bool Publish(int? id);
        bool Remove(int? id);
    }
}
