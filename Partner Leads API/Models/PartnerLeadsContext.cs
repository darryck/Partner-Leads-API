using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Partner_Leads_API.Models
{
    public partial class PartnerLeadsContext : DbContext
    {
        public PartnerLeadsContext()
        {
        }

        public PartnerLeadsContext(DbContextOptions<PartnerLeadsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Lead> Leads { get; set; }
        public virtual DbSet<LeadStatus> LeadStatuses { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<PartnerCompany> PartnerCompanies { get; set; }
        public virtual DbSet<SalesRep> SalesReps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=24.2.16.24,1433;Database=PartnerLeads;User Id =Partner;Password=PartnerLeadsAPI123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Lead>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("lead");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("city");

                entity.Property(e => e.CustomerFullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("customer_full_name");

                entity.Property(e => e.InstallDate)
                    .HasColumnType("datetime")
                    .HasColumnName("install_date");

                entity.Property(e => e.LeadId).HasColumnName("lead_id");

                entity.Property(e => e.LeadStatus)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("lead_status");

                entity.Property(e => e.PartnerCompanyId).HasColumnName("partner_company_id");

                entity.Property(e => e.SalesRepId).HasColumnName("sales_rep_id");

                entity.Property(e => e.State)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("state");

                entity.Property(e => e.Zip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("zip");

                entity.HasOne(d => d.LeadStatusNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.LeadStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_lead_status");

                entity.HasOne(d => d.PartnerCompany)
                    .WithMany()
                    .HasForeignKey(d => d.PartnerCompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_partner_company");

                entity.HasOne(d => d.SalesRep)
                    .WithMany()
                    .HasForeignKey(d => d.SalesRepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_leads_sales_rep");
            });

            modelBuilder.Entity<LeadStatus>(entity =>
            {
                entity.HasKey(e => e.LeadStatusName);

                entity.ToTable("lead_status");

                entity.Property(e => e.LeadStatusName)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("lead_status_name");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("manager");

                entity.Property(e => e.ManagerId)
                    .ValueGeneratedNever()
                    .HasColumnName("manager_id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.ManagerFullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("manager_full_name");

                entity.Property(e => e.WorkPhone)
                    .HasMaxLength(10)
                    .HasColumnName("work_phone")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PartnerCompany>(entity =>
            {
                entity.ToTable("partner_company");

                entity.Property(e => e.PartnerCompanyId)
                    .ValueGeneratedNever()
                    .HasColumnName("partner_company_id");

                entity.Property(e => e.ApiKey)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("api_key")
                    .IsFixedLength(true);

                entity.Property(e => e.PartnerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("partner_name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<SalesRep>(entity =>
            {
                entity.ToTable("sales_rep");

                entity.Property(e => e.SalesRepId)
                    .ValueGeneratedNever()
                    .HasColumnName("sales_rep_id");

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.RepFullName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("rep_full_name");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.SalesReps)
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_sales_rep_manager");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
