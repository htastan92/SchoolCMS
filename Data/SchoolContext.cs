using System.Linq;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=;Database=SchoolCmsDb;User Id=sa;Password=Wissen2018");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // News <=> News Category
            modelBuilder.Entity<NewsCategoryNews>().HasKey(c => new { c.NewsId, c.NewsCategoryId });
            modelBuilder.Entity<NewsCategoryNews>()
                .HasOne(cs => cs.News)
                .WithMany(s => s.NewsCategoryNews)
                .HasForeignKey(c => c.NewsId);
            modelBuilder.Entity<NewsCategoryNews>()
                .HasOne(cs => cs.NewsCategory)
                .WithMany(c => c.NewsCategoryNews)
                .HasForeignKey(cs => cs.NewsCategoryId);

            // Event <=> Event Category
            modelBuilder.Entity<EventCategoryEvent>().HasKey(c => new { c.EventId, c.EventCategoryId });
            modelBuilder.Entity<EventCategoryEvent>()
                .HasOne(cs => cs.Event)
                .WithMany(s => s.EventCategoryEvent)
                .HasForeignKey(c => c.EventId);
            modelBuilder.Entity<EventCategoryEvent>()
                .HasOne(cs => cs.EventCategory)
                .WithMany(c => c.EventCategoryEvent)
                .HasForeignKey(cs => cs.EventCategoryId);

            foreach (var foreignkey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignkey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            #region Seeding

            // Member
            modelBuilder.Entity<Member>().HasData(
                new Member { Id = 1, Username = "huseyin", Password = "hs123" });

            // Status
            modelBuilder.Entity<Status>().HasData(
                new Status { Id = 1, Name = "Yayında" },
                new Status { Id = 2, Name = "Taslak" },
                new Status { Id = 3, Name = "Silinmiş" });

            modelBuilder.Entity<Image>().HasData(
                new Image { Id = 1, Url = "babosko.jpg" }
            );

            modelBuilder.Entity<MenuElement>().HasData(
                new MenuElement{Id = 1, Name = "Header",StatusId = 1}
            );

            #endregion
        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Image> Images { get; set; }

        // News
        public DbSet<News> News { get; set; }
        public DbSet<NewsCategory> NewsCategories { get; set; }
        public DbSet<NewsCategoryNews> NewsCategoryNews { get; set; }

        // Event
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<EventCategoryEvent> EventCategoryEvent { get; set; }


        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<MenuElement> MenuElements { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Carousel> Carousels { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
