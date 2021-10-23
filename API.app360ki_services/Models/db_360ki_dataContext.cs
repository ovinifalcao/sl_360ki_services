using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.app360ki_services.Models
{
    public partial class db_360ki_dataContext : DbContext
    {
        public db_360ki_dataContext()
        {
        }

        public db_360ki_dataContext(DbContextOptions<db_360ki_dataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BsOcurrenceReport> BsOcurrenceReports { get; set; }
        public virtual DbSet<BsOcurrencesReply> BsOcurrencesReplies { get; set; }
        public virtual DbSet<BsUserResgistered> BsUserResgistereds { get; set; }
        public virtual DbSet<KdCityZone> KdCityZones { get; set; }
        public virtual DbSet<KdOcurrence> KdOcurrences { get; set; }
        public virtual DbSet<KdOcurrencesReply> KdOcurrencesReplies { get; set; }
        public virtual DbSet<OpUserService> OpUserServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ITLNB070\\SQL2017;Initial Catalog=db_360ki_data;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BsOcurrenceReport>(entity =>
            {
                entity.HasKey(e => e.RptId)
                    .HasName("PK__bs_Ocurr__F6FF16C818072571");

                entity.ToTable("bs_Ocurrence_Report");

                entity.Property(e => e.RptId).HasColumnName("RPT_Id");

                entity.Property(e => e.CityZoneId).HasColumnName("CityZone_Id");

                entity.Property(e => e.KindId).HasColumnName("Kind_Id");

                entity.Property(e => e.Moment).HasColumnType("datetime");

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UsrgdOwnerFk).HasColumnName("USRGD_Owner_fk");

                entity.HasOne(d => d.CityZone)
                    .WithMany(p => p.BsOcurrenceReports)
                    .HasForeignKey(d => d.CityZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bs_Ocurre__CityZ__45F365D3");

                entity.HasOne(d => d.Kind)
                    .WithMany(p => p.BsOcurrenceReports)
                    .HasForeignKey(d => d.KindId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bs_Ocurre__Kind___44FF419A");

                entity.HasOne(d => d.UsrgdOwnerFkNavigation)
                    .WithMany(p => p.BsOcurrenceReports)
                    .HasForeignKey(d => d.UsrgdOwnerFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bs_Ocurre__USRGD__440B1D61");
            });

            modelBuilder.Entity<BsOcurrencesReply>(entity =>
            {
                entity.HasKey(e => new { e.RptFk, e.UsrgdFk })
                    .HasName("PK__bs_Ocurr__08FE82DE201F4AE6");

                entity.ToTable("bs_Ocurrences_Replies");

                entity.Property(e => e.RptFk).HasColumnName("RPT_Fk");

                entity.Property(e => e.UsrgdFk).HasColumnName("USRGD_Fk");

                entity.Property(e => e.KindId).HasColumnName("Kind_Id");

                entity.Property(e => e.Moment).HasColumnType("datetime");

                entity.HasOne(d => d.RptFkNavigation)
                    .WithMany(p => p.BsOcurrencesReplies)
                    .HasForeignKey(d => d.RptFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bs_Ocurre__RPT_F__47DBAE45");

                entity.HasOne(d => d.UsrgdFkNavigation)
                    .WithMany(p => p.BsOcurrencesReplies)
                    .HasForeignKey(d => d.UsrgdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bs_Ocurre__USRGD__46E78A0C");
            });

            modelBuilder.Entity<BsUserResgistered>(entity =>
            {
                entity.HasKey(e => e.UsrgdId)
                    .HasName("PK__bs_User___E01881539FAF5E4D");

                entity.ToTable("bs_User_Resgistered");

                entity.Property(e => e.UsrgdId).HasColumnName("USRGD_Id");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CityZoneId).HasColumnName("CityZone_Id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.CityZone)
                    .WithMany(p => p.BsUserResgistereds)
                    .HasForeignKey(d => d.CityZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bs_User_R__CityZ__48CFD27E");
            });

            modelBuilder.Entity<KdCityZone>(entity =>
            {
                entity.HasKey(e => e.KdCtZnId)
                    .HasName("PK__kd_City___52F4F9C68663173A");

                entity.ToTable("kd_City_Zones");

                entity.Property(e => e.KdCtZnId).HasColumnName("Kd_Ct_Zn_Id");

                entity.Property(e => e.KdCtZnDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Kd_Ct_Zn_Desc");
            });

            modelBuilder.Entity<KdOcurrence>(entity =>
            {
                entity.HasKey(e => e.KdOcId)
                    .HasName("PK__kd_Ocurr__077A6F1CEB086CF9");

                entity.ToTable("kd_Ocurrences");

                entity.Property(e => e.KdOcId).HasColumnName("Kd_Oc_Id");

                entity.Property(e => e.KdOcDesc)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Kd_Oc_Desc");
            });

            modelBuilder.Entity<KdOcurrencesReply>(entity =>
            {
                entity.HasKey(e => e.KdOcRpId)
                    .HasName("PK__kd_Ocurr__3529AB4F98AEFB8F");

                entity.ToTable("kd_Ocurrences_Replies");

                entity.Property(e => e.KdOcRpId).HasColumnName("Kd_Oc_Rp_Id");

                entity.Property(e => e.KdOcRpDesc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Kd_Oc_Rp_Desc");
            });

            modelBuilder.Entity<OpUserService>(entity =>
            {
                entity.HasKey(e => e.UsrgdFk)
                    .HasName("PK__op_User___E018D8DE08452EF8");

                entity.ToTable("op_User_Services");

                entity.HasIndex(e => e.PhoneNum, "UQ__op_User___75C2713A2EF2F6CC")
                    .IsUnique();

                entity.Property(e => e.UsrgdFk)
                    .ValueGeneratedNever()
                    .HasColumnName("USRGD_FK");

                entity.Property(e => e.PhoneNum).HasColumnName("Phone_Num");

                entity.Property(e => e.Wsp)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WSP");

                entity.HasOne(d => d.UsrgdFkNavigation)
                    .WithOne(p => p.OpUserService)
                    .HasForeignKey<OpUserService>(d => d.UsrgdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__op_User_S__USRGD__49C3F6B7");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
