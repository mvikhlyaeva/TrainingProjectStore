using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TrainingProject.tables
{
    public class CellConfiguration : IEntityTypeConfiguration<Cell>
    {
        public void Configure(EntityTypeBuilder<Cell> builder)
        {
            builder.HasKey(u => u.Id);

            builder.HasOne(u => u.Stand)
                .WithMany(t => t.Cells)
                .HasForeignKey(u => u.StandId);
        }
    }
}