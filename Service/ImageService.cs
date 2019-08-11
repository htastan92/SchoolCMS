using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class ImageService
    {
        private readonly UnitOfWork _unitOfWork;

        public ImageService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Image Find(string imageUrl)
        {
            using (var db = new SchoolContext())
            {
                var isImageExists = db.Images.Any(i => i.Url == imageUrl);
                if (isImageExists)
                    return db.Images.FirstOrDefault(i => i.Url == imageUrl);

                var newImage = new Image { Url = imageUrl };
                _unitOfWork.SaveChanges();

                return newImage;
            }
        }
    }
}