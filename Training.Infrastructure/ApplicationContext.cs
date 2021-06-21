using Microsoft.EntityFrameworkCore;

namespace TrainingProject.tables
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cell> cells { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Stand> stands { get; set; }
        public DbSet<StoreDepartment> storeDepartments { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoreDepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new StandConfiguration());
            modelBuilder.ApplyConfiguration(new CellConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}