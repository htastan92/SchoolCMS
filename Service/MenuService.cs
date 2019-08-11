﻿using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class MenuService
    {
        private readonly UnitOfWork _unitOfWork;

        public MenuService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public MenuElement Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.FirstOrDefault(m => m.Id == id);
            }
        }

        public IList<MenuElement> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.MenuElements.ToList();
            }
        }

        public int New(MenuElement menuElement)
        {
            using (var db = new SchoolContext())
            {
                db.MenuElements.Add(menuElement);
                _unitOfWork.SaveChanges();
            }

            return menuElement.Id;
        }

        public int Edit(MenuElement menuElement)
        {
            using (var db = new SchoolContext())
            {
                db.MenuElements.Update(menuElement);
                _unitOfWork.SaveChanges();
            }

            return menuElement.Id;
        }

        public void Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var menuElement = db.MenuElements.FirstOrDefault(m=>m.Id==id);
                if (menuElement!=null)
                {
                    db.MenuElements.Remove(menuElement);
                    _unitOfWork.SaveChanges();
                }
            }
        }
    }
}
