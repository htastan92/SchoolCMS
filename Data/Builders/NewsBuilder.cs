using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class NewsBuilder:IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasOne(s => s.Status).WithMany(n => n.News).HasForeignKey(s => s.StatusId);
            builder.HasOne(c => c.Campus).WithMany(n => n.News).HasForeignKey(c => c.CampusId);
            builder.HasOne(i => i.Image).WithMany(n => n.News).HasForeignKey(i => i.ImageId);
        }
    }
}
