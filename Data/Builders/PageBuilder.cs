using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class PageBuilder :IEntityTypeConfiguration<Page>
    {
        public void Configure(EntityTypeBuilder<Page> builder)
        {
            builder.HasOne(s => s.Status).WithMany(p => p.Pages).HasForeignKey(s => s.StatusId);
            builder.HasOne(i => i.Image).WithMany(p => p.Pages).HasForeignKey(i => i.ImageId);
        }
    }
}
