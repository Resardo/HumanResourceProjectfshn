using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entities.Model
{
    public partial class HumanResourcesContext : DbContext
    {
        public HumanResourcesContext()
        {
        }

        public HumanResourcesContext(DbContextOptions<HumanResourcesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Archive> Archives { get; set; } = null!;
        public virtual DbSet<Certification> Certifications { get; set; } = null!;
        public virtual DbSet<Education> Educations { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Holiday> Holidays { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<Permit> Permits { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=HumanResources.mssql.somee.com;Database=HumanResources;User ID=K508073559P_SQLLogin_1;Password=uac1f7nqwp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archive>(entity =>
            {
                entity.ToTable("Archive");

                entity.HasIndex(e => e.EmployeeId, "UQ__Archive__7AD04F10FC5AE418")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CardId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Diploma)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RaportAftesie)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Archive)
                    .HasForeignKey<Archive>(d => d.EmployeeId)
                    .HasConstraintName("FK__Archive__Employe__4AB81AF0");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Providers)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TakeDate).HasColumnType("date");

                entity.Property(e => e.Technology)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Certifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Certifica__Emplo__4BAC3F29");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("Education");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AcademicProfile)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.EndYear).HasColumnType("date");

                entity.Property(e => e.MasterType)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Papercaktuar')");

                entity.Property(e => e.StartYear).HasColumnType("date");

                entity.Property(e => e.University)
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Username, "UQ__Employee__536C85E451F3832D")
                    .IsUnique();

                entity.HasIndex(e => e.PhoneNumber, "UQ__Employee__85FB4E38DC25209A")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Employee__A9D105345D78E8A8")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Adress)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.ComeDate).HasColumnType("date");

                entity.Property(e => e.Contact2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailConfirm).HasDefaultValueSql("((0))");

                entity.Property(e => e.LeaveDate).HasColumnType("date");

                entity.Property(e => e.LeaveReason)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(64)
                    .IsFixedLength();

                entity.Property(e => e.Username)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasMany(d => d.Educations)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeEducation",
                        l => l.HasOne<Education>().WithMany().HasForeignKey("EducationId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EmployeeE__Educa__4CA06362"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EmployeeE__Emplo__4D94879B"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "EducationId").HasName("PK__Employee__3E6BAC916DD2825A");

                            j.ToTable("EmployeeEducation");
                        });

                entity.HasMany(d => d.Projects)
                    .WithMany(p => p.Employees)
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeProject",
                        l => l.HasOne<Project>().WithMany().HasForeignKey("ProjectId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EmployeeP__Proje__4F7CD00D"),
                        r => r.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__EmployeeP__Emplo__4E88ABD4"),
                        j =>
                        {
                            j.HasKey("EmployeeId", "ProjectId").HasName("PK__Employee__6DB1E4FEC2838F27");

                            j.ToTable("EmployeeProjects");
                        });
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasKey(e => e.Dates)
                    .HasName("PK__Holidays__BFFD8592DB6EB37B");

                entity.Property(e => e.Dates).HasColumnType("date");

                entity.Property(e => e.IsHoliday)
                    .HasColumnName("isHoliday")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Company)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConfidencialityScale)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Descriptions)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Jobs__EmployeeId__5070F446");
            });

            modelBuilder.Entity<Permit>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.PermitType)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Permits)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Permits__Employe__5165187F");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.DateFrom).HasColumnType("date");

                entity.Property(e => e.DateTo).HasColumnType("date");

                entity.Property(e => e.Names)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Name, "UQ__Roles__737584F696EB7A16")
                    .IsUnique();

                entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PunonjesId })
                    .HasName("PK__UserRole__B0A65D86D6E4E10D");

                entity.ToTable("UserRole");

                entity.Property(e => e.AssignedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Punonjes)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.PunonjesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__Punonj__52593CB8");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__RoleId__534D60F1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
