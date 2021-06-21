using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainingProject.tables
{
    public class StoreDepartmentConfiguration : IEntityTypeConfiguration<StoreDepartment>
    {
        public void Configure(EntityTypeBuilder<StoreDepartment> builder)
        {
            builder.HasKey(u => new { u.StoreId, u.DepartmentId });
        }
    }
}