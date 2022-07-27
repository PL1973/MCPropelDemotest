using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MCPropelDemotest.Models
{
    public partial class SMSContext : DbContext
    {
        public SMSContext()
        {
        }

        public SMSContext(DbContextOptions<SMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentMs> StudentMs { get; set; }
        public object StudentMS { get; internal set; }
        public object EmailID { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-PKK6CDR\\SQLEXPRESS;Database=SMS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentMs>(entity =>
            {
                entity.HasKey(e => e.Regno)
                    .HasName("PK__StudentM__2C6EFDC00A885CB9");

                entity.ToTable("StudentMS");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BatchId)
                    .HasColumnName("BatchID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CourseFee).HasColumnType("money");

                entity.Property(e => e.CourseJoining)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Doj)
                    .HasColumnName("DOJ")
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EmailId)
                    .HasColumnName("EmailID")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StudentfullName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
