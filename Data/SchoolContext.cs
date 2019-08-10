using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=94.73.170.20;Database=u7801466_dbTestx;User Id=u7801466_userE86;Password=IDyk81F0;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Campus> Campuses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<Member> Members { get; set; }
        public DbSet<MenuElement> MenuElements { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}
