using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Models
{
    public partial class HR1Context : DbContext
    {
        public HR1Context()
        {
        }

        public HR1Context(DbContextOptions<HR1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Arkiva> Arkivas { get; set; } = null!;
        public virtual DbSet<Certifikime> Certifikimes { get; set; } = null!;
        public virtual DbSet<Edukimi> Edukimis { get; set; } = null!;
        public virtual DbSet<Projekte> Projektes { get; set; } = null!;
        public virtual DbSet<Punesime> Punesimes { get; set; } = null!;
        public virtual DbSet<Punonje> Punonjes { get; set; } = null!;
        public virtual DbSet<Punonjesbalanca> Punonjesbalancas { get; set; } = null!;
        public virtual DbSet<Pushimet> Pushimets { get; set; } = null!;
        public virtual DbSet<Pushimetzyrtare> Pushimetzyrtares { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Shkolla> Shkollas { get; set; } = null!;
        public virtual DbSet<ShkollePunonje> ShkollePunonjes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-3OUFFGR\\MSSQLSERVER01;Database=HR1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arkiva>(entity =>
            {
                entity.ToTable("Arkiva");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.Punonjes)
                    .WithMany(p => p.Arkivas)
                    .HasForeignKey(d => d.PunonjesId)
                    .HasConstraintName("FK__Arkiva__Punonjes__571DF1D5");
            });

            modelBuilder.Entity<Certifikime>(entity =>
            {
                entity.ToTable("Certifikime");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DataFitimit).HasColumnType("date");

                entity.Property(e => e.DataSkadences).HasColumnType("date");

                entity.Property(e => e.LinkimTeknologjie).IsUnicode(false);

                entity.Property(e => e.Provideri)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Punonjes)
                    .WithMany(p => p.Certifikimes)
                    .HasForeignKey(d => d.PunonjesId)
                    .HasConstraintName("FK__Certifiki__Punon__534D60F1");
            });

            modelBuilder.Entity<Edukimi>(entity =>
            {
                entity.ToTable("Edukimi");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.IdPunonjesi).HasColumnName("Id_Punonjesi");

                entity.Property(e => e.IdShkolle).HasColumnName("ID_shkolle");

                entity.Property(e => e.ProfiliAkademik)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.TipiMasterit)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Papercaktuar')");

                entity.Property(e => e.Universitet)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.VitiMbarimit).HasColumnType("date");

                entity.Property(e => e.VitiNisjes).HasColumnType("date");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Edukimis)
                    .HasForeignKey(d => new { d.IdPunonjesi, d.IdShkolle })
                    .HasConstraintName("FK__Edukimi__3B75D760");
            });

            modelBuilder.Entity<Projekte>(entity =>
            {
                entity.ToTable("Projekte");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Punesime>(entity =>
            {
                entity.ToTable("Punesime");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Kompania)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Pershkrim)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Pozicioni)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShkallaKonfidencialitetit)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Punonjes)
                    .WithMany(p => p.Punesimes)
                    .HasForeignKey(d => d.PunonjesId)
                    .HasConstraintName("FK__Punesime__Punonj__4F7CD00D");
            });

            modelBuilder.Entity<Punonje>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Punonjes__536C85E4D1E341E2")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__Punonjes__85FB4E38F87EC233")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Punonjes__A9D1053445C62A30")
                    .IsUnique();

                entity.HasIndex(e => e.Contact2, "UQ__Punonjes__CFEC400E2F606E55")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Adresa)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ArsyeLargimi)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Contact2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataArdhjes).HasColumnType("date");

                entity.Property(e => e.DataLargimit).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fotoprofili).HasColumnName("fotoprofili");

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.Pershkrimi)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Punonjes)
                    .UsingEntity<Dictionary<string, object>>(
                        "PuonjesProjekte",
                        l => l.HasOne<Projekte>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PuonjesPr__Proje__4BAC3F29"),
                        r => r.HasOne<Punonje>().WithMany().HasForeignKey("PunonjesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__PuonjesPr__Punon__4AB81AF0"),
                        j =>
                        {
                            j.HasKey("PunonjesId", "ProjectId").HasName("PK__PuonjesP__B2A8922D8EC39FCC");

                            j.ToTable("PuonjesProjekte");
                        });
            });

            modelBuilder.Entity<Punonjesbalanca>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("punonjesbalanca");

                entity.Property(e => e.IdPunonjesi).HasColumnName("Id_Punonjesi");

                entity.Property(e => e.Total)
                    .HasColumnName("total")
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdPunonjesiNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdPunonjesi)
                    .HasConstraintName("FK__punonjesb__Id_Pu__440B1D61");
            });

            modelBuilder.Entity<Pushimet>(entity =>
            {
                entity.ToTable("pushimet");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Raporti).HasColumnName("raporti");

                entity.Property(e => e.Tipi)
                    .HasMaxLength(255)
                    .HasColumnName("tipi")
                    .HasDefaultValueSql("('E papercaktuar')");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Pushimets)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__pushimet__Employ__3F466844");
            });

            modelBuilder.Entity<Pushimetzyrtare>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pushimetzyrtare");

                entity.Property(e => e.Data)
                    .HasColumnType("date")
                    .HasColumnName("data");

                entity.Property(e => e.IsHoliday).HasColumnName("isHoliday");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Roles__737584F6FB9766EE")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasMany(d => d.Punonjes)
                    .WithMany(p => p.Roles)
                    .UsingEntity<Dictionary<string, object>>(
                        "UserRole",
                        l => l.HasOne<Punonje>().WithMany().HasForeignKey("PunonjesId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__Punonj__300424B4"),
                        r => r.HasOne<Role>().WithMany().HasForeignKey("RoleId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__UserRole__RoleId__2F10007B"),
                        j =>
                        {
                            j.HasKey("RoleId", "PunonjesId").HasName("PK__UserRole__B0A65D860A641C9B");

                            j.ToTable("UserRole");
                        });
            });

            modelBuilder.Entity<Shkolla>(entity =>
            {
                entity.HasKey(e => e.IdShkolle)
                    .HasName("PK__shkolla__88B03EAFC2B1CF72");

                entity.ToTable("shkolla");

                entity.Property(e => e.IdShkolle)
                    .HasColumnName("id_shkolle")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Emri)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("emri");

                entity.Property(e => e.Tipi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("tipi");
            });

            modelBuilder.Entity<ShkollePunonje>(entity =>
            {
                entity.HasKey(e => new { e.PunonjesId, e.IdShkolle })
                    .HasName("PK__shkolle___43929F47A6EB131B");

                entity.ToTable("shkolle_punonjes");

                entity.Property(e => e.IdShkolle).HasColumnName("ID_shkolle");

                entity.HasOne(d => d.IdShkolleNavigation)
                    .WithMany(p => p.ShkollePunonjes)
                    .HasForeignKey(d => d.IdShkolle)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shkolle_p__ID_sh__36B12243");

                entity.HasOne(d => d.Punonjes)
                    .WithMany(p => p.ShkollePunonjes)
                    .HasForeignKey(d => d.PunonjesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__shkolle_p__Punon__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
