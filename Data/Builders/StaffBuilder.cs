using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class StaffBuilder:IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasOne(c => c.Campus).WithMany(s => s.Staff).HasForeignKey(c => c.CampusId);
            builder.HasOne(s => s.Status).WithMany(st => st.Staff).HasForeignKey(s => s.StatusId);
        }
    }
}
