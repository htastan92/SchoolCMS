using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class NewsCategoryNewsBuilder : IEntityTypeConfiguration<NewsCategoryNews>
    {
        public void Configure(EntityTypeBuilder<NewsCategoryNews> builder)
        {
            builder.HasOne(nc => nc.NewsCategory).WithMany(ncn => ncn.NewsCategoryNews)
                .HasForeignKey(nc => nc.NewsCategoryId);
        }
    }
}
