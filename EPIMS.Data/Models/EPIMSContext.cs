using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EPIMS.Data.Models
{
    public partial class EPIMSContext : DbContext
    {
        public EPIMSContext()
        {
        }

        public EPIMSContext(DbContextOptions<EPIMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Poles> Poles { get; set; }
        public virtual DbSet<PolesCountByWork> PolesCountByWork { get; set; }
        public virtual DbSet<Userrole> Userrole { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkDetails> WorkDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=EPIMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Poles>(entity =>
            {
                entity.ToTable("poles");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Manufacturer).HasMaxLength(200);

                entity.Property(e => e.Poletype).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");
            });

            modelBuilder.Entity<PolesCountByWork>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.HasOne(d => d.Pole)
                    .WithMany(p => p.PolesCountByWork)
                    .HasForeignKey(d => d.PoleId)
                    .HasConstraintName("fk_pole_id");

                entity.HasOne(d => d.Work)
                    .WithMany(p => p.PolesCountByWork)
                    .HasForeignKey(d => d.WorkId)
                    .HasConstraintName("fk_work_id");
            });

            modelBuilder.Entity<Userrole>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.UserCode).HasMaxLength(200);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.Property(e => e.MiddleName).HasMaxLength(200);

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("fk_user_role_id");
            });

            modelBuilder.Entity<WorkDetails>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(700);

                entity.Property(e => e.Division).HasMaxLength(200);

                entity.Property(e => e.Image).HasMaxLength(200);

                entity.Property(e => e.Lang).HasMaxLength(200);

                entity.Property(e => e.Lat).HasMaxLength(200);

                entity.Property(e => e.SubDivision).HasMaxLength(200);

                entity.Property(e => e.Zone).HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorkDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
