using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace De4.Models
{
    public partial class De4Context : DbContext
    {
        public De4Context()
        {
        }

        public De4Context(DbContextOptions<De4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<NhaXuatBan> NhaXuatBans { get; set; }
        public virtual DbSet<Sach> Saches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-FV5ABKPJ\\SQLEXPRESS;Initial Catalog=De4;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Vietnamese_CI_AS");

            modelBuilder.Entity<NhaXuatBan>(entity =>
            {
                entity.HasKey(e => e.Manxb)
                    .HasName("PK__NhaXuatB__339E504204C9D612");

                entity.ToTable("NhaXuatBan");

                entity.Property(e => e.Manxb)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tennhaxb).HasMaxLength(50);
            });

            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasKey(e => e.Masach)
                    .HasName("PK__Sach__9F923C8887B480C8");

                entity.ToTable("Sach");

                entity.Property(e => e.Masach)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Manxb)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Tensach).HasMaxLength(59);

                entity.HasOne(d => d.ManxbNavigation)
                    .WithMany(p => p.Saches)
                    .HasForeignKey(d => d.Manxb)
                    .HasConstraintName("FK_Sach_NhaXB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
