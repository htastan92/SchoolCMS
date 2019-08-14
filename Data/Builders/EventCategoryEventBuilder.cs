using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class EventCategoryEventBuilder:IEntityTypeConfiguration<EventCategoryEvent>
    {
        public void Configure(EntityTypeBuilder<EventCategoryEvent> builder)
        {
            builder.HasOne(ec => ec.EventCategory).WithMany(ece => ece.EventCategoryEvent)
                .HasForeignKey(ec => ec.EventCategoryId);
        }
    }
}
