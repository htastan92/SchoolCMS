using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class SettingsBuilder:IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.HasOne(em => em.EditorMember).WithMany(s => s.Settings).HasForeignKey(em => em.EditorMemberId);
        }
    }
}
