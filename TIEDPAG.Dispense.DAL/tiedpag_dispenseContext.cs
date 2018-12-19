using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TIEDPAG.Dispense.Model;

namespace TIEDPAG.Dispense.DAL
{
    public partial class tiedpag_dispenseContext : DbContext
    {
        public tiedpag_dispenseContext()
        {
        }

        public tiedpag_dispenseContext(DbContextOptions<tiedpag_dispenseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("Server=182.61.40.185;User Id=tiedpag;Password=Mysql@12;Database=tiedpag_dispense");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area", "tiedpag_dispense");

                entity.HasIndex(e => e.Name)
                    .HasName("Area_Index_Name");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Createby).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Updateby).HasColumnType("int(11)");
            });
        }
    }
}
