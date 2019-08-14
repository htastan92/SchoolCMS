using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class NewsCategoryBuilder:IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasOne(s => s.Status).WithMany(nc => nc.NewsCategories).HasForeignKey(s => s.StatusId);
        }
    }
}
