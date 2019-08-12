using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;

namespace Service
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public News GetAdmin(int? id)
        {
            using (var db = new SchoolContext())
            {
                return db.News.FirstOrDefault(n => n.Id == id && n.Status.Id != (int)Statuses.Removed);
            }
        }

        public News GetWeb(string slug)
        {
            using (var db = new SchoolContext())
            {
                return db.News.FirstOrDefault(n => n.Slug == slug && n.Status.Id == (int)Statuses.Published);
            }
        }

        public IList<News> GetAllAdmin()
        {
            using (var db = new SchoolContext())
            {
                return db.News.Where(n => n.Status.Id != (int)Statuses.Removed).ToList();
            }
        }

        public IList<News> GetAllWeb()
        {
            using (var db = new SchoolContext())
            {
                return db.News.Where(n => n.Status.Id == (int)Statuses.Published).ToList();
            }
        }

        public IList<News> LastNewsHomepage()
        {
            using (var db = new SchoolContext())
            {
                return db.News.Where(n => n.Status.Id == (int) Statuses.Published)
                    .OrderByDescending(n => n.Id)
                    .Take(3)
                    .ToList();
            }
        }

        public IList<NewsCategory> GetNewsCategories(int newsId)
        {
            IList<NewsCategory> newsCategories = new List<NewsCategory>();
            using (var db = new SchoolContext())
            {
                var categoriesOfNews = db.NewsCategoryNews
                    .Where(ncn => ncn.NewsId == newsId)
                    .Select(ncn => ncn.NewsCategory).ToList();
                foreach (var category in categoriesOfNews)
                {
                    newsCategories.Add(category);
                }
            }

            return newsCategories;
        }

        public int New(News news)
        {
            using (var db = new SchoolContext())
            {
                db.News.Add(news);
                _unitOfWork.SaveChanges();
            }

            return news.Id;
        }

        public int Edit(News news)
        {
            using (var db = new SchoolContext())
            {
                db.News.Update(news);
                _unitOfWork.SaveChanges();
            }

            return news.Id;
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

    public interface INewsService
    {
        News GetAdmin(int? id);
        News GetWeb(string slug);
        IList<News> GetAllAdmin();
        IList<News> GetAllWeb();
        IList<News> LastNewsHomepage();
        int New(News news);
        int Edit(News news);
        bool Publish(int? id);
        bool Draft(int? id);
        bool Remove(int? id);
        IList<NewsCategory> GetNewsCategories(int newsId);
    }
}
