using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainingProject.tables
{
    public class StandConfiguration : IEntityTypeConfiguration<Stand>
    {
        public void Configure(EntityTypeBuilder<Stand> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.StoreDepartment)
                .WithMany(t => t.Stands)
                .HasForeignKey(u => new { u.StoreId, u.DepartmentId });
        }
    }
}
