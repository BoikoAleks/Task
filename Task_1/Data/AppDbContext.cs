using Microsoft.EntityFrameworkCore;
using Task_1.Models;

namespace Task_1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ProductionFacility> ProductionFacilities { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure EquipmentPlacementContract relationships
            modelBuilder.Entity<EquipmentPlacementContract>()
                .HasOne(e => e.ProductionFacility)
                .WithMany()
                .HasForeignKey(e => e.ProductionFacilityCode);

            modelBuilder.Entity<EquipmentPlacementContract>()
                .HasOne(e => e.EquipmentType)
                .WithMany()
                .HasForeignKey(e => e.EquipmentTypeCode);

            // Ensure primary and foreign keys are of the same type
            modelBuilder.Entity<EquipmentPlacementContract>()
                .Property(e => e.EquipmentTypeCode)
                .HasColumnType("int"); // Explicitly specify int type

            // Seed data for ProductionFacility
            modelBuilder.Entity<ProductionFacility>().HasData(
                new ProductionFacility { Code = 1, Name = "Facility A", StandardArea = 500.0 },
                new ProductionFacility { Code = 2, Name = "Facility B", StandardArea = 800.0 }
            );

            // Seed data for EquipmentType
            modelBuilder.Entity<EquipmentType>().HasData(
                new EquipmentType { Code = 1, Name = "Conveyor", Area = 20.0 },
                new EquipmentType { Code = 2, Name = "Press Machine", Area = 50.0 }
            );
        }
    }
}