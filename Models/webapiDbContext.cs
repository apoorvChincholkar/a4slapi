using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.Models
{
    public partial class webapiDbContext : DbContext
    {
        public virtual DbSet<AlertData> AlertData { get; set; }
        public virtual DbSet<CleaningAgencyTicketDetails> CleaningAgencyTicketDetails { get; set; }
        public virtual DbSet<CleaningMaster> CleaningMaster { get; set; }
        public virtual DbSet<ConsumedFileList> ConsumedFileList { get; set; }
        public virtual DbSet<DailyReportDispatchRecord> DailyReportDispatchRecord { get; set; }
        public virtual DbSet<DailyReportMailingList> DailyReportMailingList { get; set; }
        public virtual DbSet<EnergyMeterParameters> EnergyMeterParameters { get; set; }
        public virtual DbSet<HourlySiteEstimate> HourlySiteEstimate { get; set; }
        public virtual DbSet<InverterData> InverterData { get; set; }
        public virtual DbSet<InverterMaster> InverterMaster { get; set; }
        public virtual DbSet<InverterParamMaster> InverterParamMaster { get; set; }
        public virtual DbSet<InverterType> InverterType { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<OrganizationMaster> OrganizationMaster { get; set; }
        public virtual DbSet<OrganizationSiteInverterParams> OrganizationSiteInverterParams { get; set; }
        public virtual DbSet<SiteCleaningTicketConfigDetails> SiteCleaningTicketConfigDetails { get; set; }
        public virtual DbSet<SiteMaster> SiteMaster { get; set; }
        public virtual DbSet<SubscriptionMaster> SubscriptionMaster { get; set; }
        public virtual DbSet<TicketHistory> TicketHistory { get; set; }
        public virtual DbSet<TicketMaster> TicketMaster { get; set; }
        public virtual DbSet<TimelineData> TimelineData { get; set; }
        public virtual DbSet<TimezoneMaster> TimezoneMaster { get; set; }
        public virtual DbSet<TransactionIndex621e01e85109403aBb88291ecdf09679> TransactionIndex621e01e85109403aBb88291ecdf09679 { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=192.168.31.32,1433;Database=EnergyDB;Trusted_Connection=True;User Id=sa; Password=20a5r1990c;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlertData>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SiteId, e.Id });

                entity.HasIndex(e => new { e.OrganizationId, e.SiteId, e.InverterId, e.DateTime })
                    .HasName("IX_AlertData");

                entity.HasOne(d => d.SiteMaster)
                    .WithMany(p => p.AlertData)
                    .HasForeignKey(d => new { d.OrganizationId, d.SiteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlertData_SiteMaster");
            });

            modelBuilder.Entity<CleaningAgencyTicketDetails>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.OrganizationId, e.SiteId, e.AgencyId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ConsumedFileList>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.FileName });

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.ConsumedFileList)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConsumedFileList_OrganizationMaster");
            });

            modelBuilder.Entity<DailyReportDispatchRecord>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.EmailId, e.DateTime });

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.DailyReportDispatchRecord)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyReportDispatchRecord_OrganizationMaster");
            });

            modelBuilder.Entity<DailyReportMailingList>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.MobileNumber).IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.DailyReportMailingList)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyReportMailingList_OrganizationMaster");
            });

            modelBuilder.Entity<EnergyMeterParameters>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SiteId, e.MeterId, e.DateTime, e.ParameterName, e.Type });
            });

            modelBuilder.Entity<HourlySiteEstimate>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SiteId, e.DateTime });

                entity.HasOne(d => d.SiteMaster)
                    .WithMany(p => p.HourlySiteEstimate)
                    .HasForeignKey(d => new { d.OrganizationId, d.SiteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InverterReading_SiteMaster");
            });

            modelBuilder.Entity<InverterData>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SiteId, e.InverterId, e.DateTime });

                entity.HasIndex(e => new { e.OrganizationId, e.SiteId, e.InverterId, e.DateTime })
                    .HasName("UK_InverterData")
                    .IsUnique()
                    .ForSqlServerIsClustered();

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.InverterData)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InverterData_OrganizationMaster");

                entity.HasOne(d => d.SiteMaster)
                    .WithMany(p => p.InverterData)
                    .HasForeignKey(d => new { d.OrganizationId, d.SiteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InverterData_SiteMaster");

                entity.HasOne(d => d.InverterMaster)
                    .WithMany(p => p.InverterData)
                    .HasForeignKey(d => new { d.OrganizationId, d.SiteId, d.InverterId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InverterData_InverterMaster");
            });

            modelBuilder.Entity<InverterMaster>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SiteId, e.Id });

                entity.HasOne(d => d.SiteMaster)
                    .WithMany(p => p.InverterMaster)
                    .HasForeignKey(d => new { d.OrganizationId, d.SiteId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InverterMaster_SiteMaster");
            });

            modelBuilder.Entity<InverterParamMaster>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id });
            });

            modelBuilder.Entity<InverterType>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey });
            });

            modelBuilder.Entity<OrganizationMaster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.TimezoneNavigation)
                    .WithMany(p => p.OrganizationMaster)
                    .HasForeignKey(d => d.Timezone)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationMaster_TimezoneMaster");
            });

            modelBuilder.Entity<SiteCleaningTicketConfigDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SiteId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SiteMaster>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id });

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.SiteMaster)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteMaster_OrganizationMaster");

                entity.HasOne(d => d.SubscriptionMaster)
                    .WithMany(p => p.SiteMaster)
                    .HasForeignKey(d => new { d.OrganizationId, d.SubscriptionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiteMaster_SubscriptionMaster");
            });

            modelBuilder.Entity<SubscriptionMaster>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.SubscriptionId });

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.SubscriptionMaster)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionMaster_OrganizationMaster");
            });

            modelBuilder.Entity<TicketHistory>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id, e.TicketId });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.TicketMaster)
                    .WithMany(p => p.TicketHistory)
                    .HasForeignKey(d => new { d.OrganizationId, d.TicketId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketHistory_TicketMaster");
            });

            modelBuilder.Entity<TicketMaster>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id });

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TicketMaster)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketMaster_OrganizationMaster");
            });

            modelBuilder.Entity<TimelineData>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id });

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.TimelineData)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TimelineData_OrganizationMaster");
            });

            modelBuilder.Entity<TimezoneMaster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<TransactionIndex621e01e85109403aBb88291ecdf09679>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => new { e.OrganizationId, e.Id });

                entity.Property(e => e.ContactNumber).IsUnicode(false);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.UserMaster)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserMaster_UserMaster");
            });
        }
    }
}
