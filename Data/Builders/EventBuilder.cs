using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class EventBuilder:IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasOne(s => s.Status).WithMany(e => e.Events).HasForeignKey(s => s.StatusId);
            builder.HasOne(c => c.Campus).WithMany(e => e.Events).HasForeignKey(c => c.CampusId);
            builder.HasOne(i => i.Image).WithMany(e => e.Events).HasForeignKey(i => i.ImageId);
        }
    }
}
