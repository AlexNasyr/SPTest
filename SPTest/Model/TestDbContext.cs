using Microsoft.EntityFrameworkCore;
using SPTest.Model.TestDb;

#nullable disable

namespace SPTest.Model {
    public partial class TestDbContext : DbContext, ITestDbContext {
        public TestDbContext() {
        }
        public TestDbContext(DbContextOptions<TestDbContext> options)
            : base(options) {
        }

        public virtual DbSet<EventLog> EventLogs { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductVersion> ProductVersions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<EventLog>(entity => {
                entity.ToTable("EventLog");

                entity.HasIndex(e => e.EventDate, "IdX_EventDate");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.EventDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Product>(entity => {
                entity.ToTable("Product");

                entity.HasIndex(e => e.Name, "UQ__Product__737584F616212ABF")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<ProductVersion>(entity => {
                entity.ToTable("ProductVersion");

                entity.HasIndex(e => e.CreatingDate, "IdX_CreatingDate");

                entity.HasIndex(e => e.Height, "IdX_Height");

                entity.HasIndex(e => e.Length, "IdX_Length");

                entity.HasIndex(e => e.Name, "IdX_Name");

                entity.HasIndex(e => e.Width, "IdX_Width");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CreatingDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Height).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Length).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Width).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVersions)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("ProductVersion_Product_0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
