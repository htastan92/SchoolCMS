using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class EventCategoryBuilder :IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.HasOne(s => s.Status).WithMany(ec => ec.EventCategories).HasForeignKey(s => s.StatusId);
        }
    }
}
