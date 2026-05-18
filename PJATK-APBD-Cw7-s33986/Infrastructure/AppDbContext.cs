using Microsoft.EntityFrameworkCore;
using PJATK_APBD_Cw7_s33986.Models;

namespace PJATK_APBD_Cw7_s33986.Infrastructure;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<PC> PCs { get; set; }
    public DbSet<Component> Components { get; set; } 
    public DbSet<PCComponent> PCComponents { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Component>()
            .HasKey(c => c.Code);

        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new { pc.PCId, pc.ComponentCode });

        modelBuilder.Entity<PC>()
            .Property(p => p.Name)
            .HasColumnType("nvarchar(50)");

        modelBuilder.Entity<PC>()
            .Property(p => p.Weight)
            .HasColumnType("float(5)");

        modelBuilder.Entity<Component>()
            .Property(c => c.Code)
            .HasColumnType("char(10)");

        modelBuilder.Entity<Component>()
            .Property(c => c.Name)
            .HasColumnType("nvarchar(300)");

        modelBuilder.Entity<ComponentType>()
            .Property(ct => ct.Abbreviation)
            .HasColumnType("nvarchar(30)");

        modelBuilder.Entity<ComponentManufacturer>()
            .Property(m => m.Abbreviation)
            .HasMaxLength(30);

        modelBuilder.Entity<ComponentManufacturer>()
            .Property(m => m.FullName)
            .HasMaxLength(200);

        modelBuilder.Entity<ComponentType>()
            .Property(ct => ct.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<Component>()
            .Property(c => c.Description)
            .HasMaxLength(500);

        modelBuilder.Entity<Component>()
            .HasOne(c => c.ComponentManufacturer)
            .WithMany(m => m.Components)
            .HasForeignKey(c => c.ComponentManufacturerId);

        modelBuilder.Entity<Component>()
            .HasOne(c => c.ComponentType)
            .WithMany(t => t.Components)
            .HasForeignKey(c => c.ComponentTypeId);

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.PC)
            .WithMany(p => p.PCComponents)
            .HasForeignKey(pc => pc.PCId);

        modelBuilder.Entity<PCComponent>()
            .HasOne(pc => pc.Component)
            .WithMany(c => c.PCComponents)
            .HasForeignKey(pc => pc.ComponentCode);

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateTime(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "NV",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateTime(1993, 4, 5)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "COR",
                FullName = "Corsair Gaming Inc.",
                FoundationDate = new DateTime(1994, 1, 1)
            },
            new ComponentManufacturer
            {
                Id = 4,
                Abbreviation = "SAM",
                FullName = "Samsung Electronics",
                FoundationDate = new DateTime(1969, 1, 13)
            }
        );

        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor"
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "Graphics Card"
            },
            new ComponentType
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "Memory"
            },
            new ComponentType
            {
                Id = 4,
                Abbreviation = "SSD",
                Name = "Storage"
            }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component
            {
                Code = "CPU0000001",
                Name = "Ryzen 7 7800X3D",
                Description = "8-core gaming processor",
                ComponentManufacturerId = 1,
                ComponentTypeId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "RTX 4080 Super",
                Description = "High-end gaming graphics card",
                ComponentManufacturerId = 2,
                ComponentTypeId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "Corsair Vengeance DDR5 16GB",
                Description = "DDR5 RAM module 16GB",
                ComponentManufacturerId = 3,
                ComponentTypeId = 3
            },
            new Component
            {
                Code = "SSD0000001",
                Name = "Samsung 990 PRO 1TB",
                Description = "NVMe SSD 1TB",
                ComponentManufacturerId = 4,
                ComponentTypeId = 4
            }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC
            {
                Id = 1,
                Name = "Gaming Beast X",
                Weight = 12.5f,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8, 9, 0, 0),
                Stock = 5
            },
            new PC
            {
                Id = 2,
                Name = "Office Mini Pro",
                Weight = 4.2f,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15, 13, 30, 0),
                Stock = 12
            },
            new PC
            {
                Id = 3,
                Name = "Creator Max",
                Weight = 8.9f,
                Warranty = 12,
                CreatedAt = new DateTime(2026, 3, 1, 10, 0, 0),
                Stock = 7
            }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent
            {
                PCId = 1,
                ComponentCode = "CPU0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 1,
                ComponentCode = "GPU0000001",
                Amount = 1
            },
            new PCComponent
            {
                PCId = 1,
                ComponentCode = "RAM0000001",
                Amount = 2
            },
            new PCComponent
            {
                PCId = 3,
                ComponentCode = "SSD0000001",
                Amount = 1
            }
        );
    }
}
