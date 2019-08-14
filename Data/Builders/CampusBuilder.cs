using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class CampusBuilder :IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.HasOne(s => s.Status).WithMany(c => c.Campuses).HasForeignKey(s => s.StatusId);
            builder.HasOne(i => i.Image).WithMany(c => c.Campuses).HasForeignKey(s => s.ImageId);
        }
    }
}
