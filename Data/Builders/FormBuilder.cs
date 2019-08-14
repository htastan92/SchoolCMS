using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class FormBuilder:IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasOne(c => c.Campus).WithMany(f => f.Forms).HasForeignKey(c => c.CampusId);
        }
    }
}
