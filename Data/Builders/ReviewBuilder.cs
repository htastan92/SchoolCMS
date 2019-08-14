using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class ReviewBuilder:IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasOne(s => s.Status).WithMany(r => r.Reviews).HasForeignKey(s => s.StatusId);
            builder.HasOne(i => i.Image).WithMany(r => r.Reviews).HasForeignKey(i => i.ImageId);
        }
    }
}
