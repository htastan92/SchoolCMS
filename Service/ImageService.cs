using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data;
using Entities;

namespace Service
{
    public class ImageService
    {
        private readonly UnitOfWork _unitOfWork;

        public ImageService(UnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Image Get(int id)
        {
            using (var db = new SchoolContext())
            {
                return db.Images.FirstOrDefault(i => i.Id == id);
            }
        }

        public IList<Image> GetAll()
        {
            using (var db = new SchoolContext())
            {
                return db.Images.ToList();
            }
        }

        public int New(Image image)
        {
            using (var db = new SchoolContext())
            {
                db.Images.Add(image);
                _unitOfWork.SaveChanges();
            }

            return image.Id;
        }

        public int Edit(Image image)
        {
            using (var db = new SchoolContext())
            {
                db.Images.Update(image);
                _unitOfWork.SaveChanges();
            }

            return image.Id;
        }

        public void Delete(int id)
        {
            using (var db = new SchoolContext())
            {
                var image = db.Images.FirstOrDefault(i => i.Id == id);
                if (image!=null)
                {
                    db.Images.Remove(image);
                }
            }
        }
    }
}
