using Microsoft.EntityFrameworkCore;

namespace OrmBenchmark.EFCore
{
    public partial class EFCoreContext : DbContext
    {
        public EFCoreContext()
        {
        }

        public virtual DbSet<SimpleEntity> SimpleTables { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Constants.CONNECTION_STRING);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SimpleEntity>(entity =>
            {
                entity.ToTable("ORM_BENCHMARK_TABLE");

                entity.HasKey(c => c.Id);
                entity.Property(c => c.Id).HasColumnName("ID");

                entity.Property(c => c.StringField1).HasColumnName("STRINGFIELD1");
                entity.Property(c => c.StringField2).HasColumnName("STRINGFIELD2");
                entity.Property(c => c.StringField3).HasColumnName("STRINGFIELD3");

                entity.Property(c => c.LongField1).HasColumnName("LONGFIELD1");
                entity.Property(c => c.LongField2).HasColumnName("LONGFIELD2");
                entity.Property(c => c.LongField3).HasColumnName("LONGFIELD3");

                entity.Property(c => c.DateField1).HasColumnName("DATEFIELD1");
                entity.Property(c => c.DateField2).HasColumnName("DATEFIELD2");
                entity.Property(c => c.DateField3).HasColumnName("DATEFIELD3");
            });
        }
    }
}