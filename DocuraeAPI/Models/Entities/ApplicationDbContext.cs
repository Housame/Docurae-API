using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DocuraeAPI.Models.Entities
{
    public partial class ApplicationDbContext : DbContext
    {
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Individual> Individual { get; set; }
        public virtual DbSet<LogText> LogText { get; set; }
        public virtual DbSet<LogTextAdditions> LogTextAdditions { get; set; }
        public virtual DbSet<LogTextAdditionsType> LogTextAdditionsType { get; set; }
        public virtual DbSet<LogTextType> LogTextType { get; set; }
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Reminder> Reminder { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DocuraeTestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company", "doc");

                entity.Property(e => e.LogoId).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Individual>(entity =>
            {
                entity.ToTable("Individual", "doc");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Individual)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Individual_doc.Unit_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Individual)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Individual_doc.User_Id");
            });

            modelBuilder.Entity<LogText>(entity =>
            {
                entity.ToTable("LogText", "doc");

                entity.Property(e => e.ActualDate).HasColumnType("datetime");

                entity.Property(e => e.LogText1)
                    .IsRequired()
                    .HasColumnName("LogText");

                entity.Property(e => e.SigninDate).HasColumnType("datetime");

                entity.HasOne(d => d.LogTextType)
                    .WithMany(p => p.LogText)
                    .HasForeignKey(d => d.LogTextTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogText_doc.LogTextType_Id");

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.LogText)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogText_doc.Patient_Id");

                entity.HasOne(d => d.Signer)
                    .WithMany(p => p.LogText)
                    .HasForeignKey(d => d.SignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogText_doc.User_Id");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.LogText)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogText_doc.Unit_Id");
            });

            modelBuilder.Entity<LogTextAdditions>(entity =>
            {
                entity.ToTable("LogTextAdditions", "doc");

                entity.Property(e => e.ActualDate).HasColumnType("datetime");

                entity.Property(e => e.LtadditionsText)
                    .IsRequired()
                    .HasColumnName("LTAdditionsText");

                entity.Property(e => e.LtadditionsTypeId).HasColumnName("LTAdditionsTypeId");

                entity.Property(e => e.SigningsDate).HasColumnType("datetime");

                entity.HasOne(d => d.LogText)
                    .WithMany(p => p.LogTextAdditions)
                    .HasForeignKey(d => d.LogTextId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogTextAddditions_doc.LogText_Id");

                entity.HasOne(d => d.LtadditionsType)
                    .WithMany(p => p.LogTextAdditions)
                    .HasForeignKey(d => d.LtadditionsTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogTextAdditions_doc.LogTextAdditionsType_Id");

                entity.HasOne(d => d.Signer)
                    .WithMany(p => p.LogTextAdditions)
                    .HasForeignKey(d => d.SignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.LogTextAdditions_doc.User_Id");
            });

            modelBuilder.Entity<LogTextAdditionsType>(entity =>
            {
                entity.ToTable("LogTextAdditionsType", "doc");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LogTextType>(entity =>
            {
                entity.ToTable("LogTextType", "doc");

                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("Patient", "doc");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Public).HasDefaultValueSql("((1))");

                entity.Property(e => e.SocialNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Patient)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Patient_doc.Section_Id");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.ToTable("Reminder", "doc");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.LogText)
                    .WithMany(p => p.Reminder)
                    .HasForeignKey(d => d.LogTextId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Reminder_doc.LogText_Id");

                entity.HasOne(d => d.Signer)
                    .WithMany(p => p.Reminder)
                    .HasForeignKey(d => d.SignerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Reminder_doc.User_Id");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section", "doc");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Section_doc.Company_Id");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Section)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Section_doc.Unit_Id");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit", "doc");

                entity.Property(e => e.Adress).HasMaxLength(50);

                entity.Property(e => e.Adress2).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Unit)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_doc.Unit_doc.Company_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User", "doc");

                entity.Property(e => e.CompanyId).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.JobTitle).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.SocialNumber).HasMaxLength(50);
            });
        }
    }
}
