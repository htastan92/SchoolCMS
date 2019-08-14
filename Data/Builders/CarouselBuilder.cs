using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class CarouselBuilder : IEntityTypeConfiguration<Carousel>
    {
        public void Configure(EntityTypeBuilder<Carousel> builder)
        {
            builder.HasOne(s => s.Status).WithMany(c => c.Carousels).HasForeignKey(s => s.StatusId);
            builder.HasOne(s => s.Image).WithMany(c => c.Carousels).HasForeignKey(s => s.ImageId);
        }
    }
}
