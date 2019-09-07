using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class CampusBuilder :IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.HasOne(c => c.Status).WithMany(s => s.Campuses).HasForeignKey(c => c.StatusId);
            
        }
    }
}
