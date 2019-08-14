using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class MenuElementBuilder:IEntityTypeConfiguration<MenuElement>
    {
        public void Configure(EntityTypeBuilder<MenuElement> builder)
        {
            builder.HasOne(s => s.Status).WithMany(me => me.MenuElements).HasForeignKey(s => s.StatusId);
            builder.HasOne(pm => pm.ParentMenu).WithMany().HasForeignKey(pm => pm.ParentMenuId);
        }
    }
}
