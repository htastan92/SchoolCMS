using System;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=")
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
