using Microsoft.EntityFrameworkCore;
using BreakpointManagement.Data.Models;

#nullable disable

namespace BreakpointManagement.Data.Context
{
    public partial class AuditDbContext : DbContext
    {
        public AuditDbContext()
        {
        }

        public AuditDbContext(DbContextOptions<AuditDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdtBreakpoint> AdtBreakpoints { get; set; }
        public virtual DbSet<AdtBreakpointGroup> AdtBreakpointGroups { get; set; }
        public virtual DbSet<AdtBreakpointGroupMember> AdtBreakpointGroupMembers { get; set; }
        public virtual DbSet<AdtBreakpointStandard> AdtBreakpointStandards { get; set; }
        public virtual DbSet<AdtDrug> AdtDrugs { get; set; }
        public virtual DbSet<AdtDrugClass> AdtDrugClasses { get; set; }
        public virtual DbSet<AdtDrugSubClass> AdtDrugSubClasses { get; set; }
        public virtual DbSet<AdtProject> AdtProjects { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AdtBreakpoint>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adt_Breakpoint");

                entity.Property(e => e.BpgroupId).HasColumnName("BPGroupId");

                entity.Property(e => e.Bpyear)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("BPYEAR");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason).HasMaxLength(100);

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DisplayedAs)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Dosage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DosageType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Intermediate).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.LowIntermediate).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.Resistant).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.ResultType).HasMaxLength(25);

                entity.Property(e => e.RowState)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ScrHighIntermediate)
                    .HasMaxLength(50)
                    .HasColumnName("scrHighIntermediate");

                entity.Property(e => e.ScrLowIntermediate)
                    .HasMaxLength(50)
                    .HasColumnName("scrLowIntermediate");

                entity.Property(e => e.ScrResistant)
                    .HasMaxLength(50)
                    .HasColumnName("scrResistant");

                entity.Property(e => e.ScrSusceptible)
                    .HasMaxLength(50)
                    .HasColumnName("scrSusceptible");

                entity.Property(e => e.Susceptible).HasColumnType("decimal(8, 4)");

                entity.Property(e => e.UserAudit)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtBreakpointGroup>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("adt_BreakpointGroup");

                entity.Property(e => e.BpgroupId).HasColumnName("BPGroupId");

                entity.Property(e => e.BpgroupName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("BPGroupName");

                entity.Property(e => e.BpstandardId).HasColumnName("BPStandardId");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason).HasMaxLength(100);

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserAudit)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtBreakpointGroupMember>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("adt_BreakpointGroupMember");

                entity.Property(e => e.BpgroupId).HasColumnName("BPGroupId");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason).HasMaxLength(100);

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UserAudit)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtBreakpointStandard>(entity =>
            {
                entity.HasKey(e => e.RecordId);

                entity.ToTable("adt_BreakpointStandard");

                entity.Property(e => e.Bpstandard)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("BPStandard");

                entity.Property(e => e.BpstandardId).HasColumnName("BPStandardId");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserAudit)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtDrug>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adt_Drug");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DrugAbbr)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrugId).HasColumnName("DrugID");

                entity.Property(e => e.DrugName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrugSubclassId).HasColumnName("DrugSubclassID");

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.UserAudit)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtDrugClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adt_DrugClass");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DrugClassAbbr)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DrugClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordId).ValueGeneratedOnAdd();

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserAudit)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtDrugSubClass>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adt_DrugSubClass");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DrugSubClassAbbr)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.DrugSubClassName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DrugSubclassId).HasColumnName("DrugSubclassID");

                entity.Property(e => e.RecordId).ValueGeneratedOnAdd();

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserAudit)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdtProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("adt_Project");

                entity.Property(e => e.AssistantProjectManager).HasMaxLength(50);

                entity.Property(e => e.BeginningPlrrf).HasColumnName("BeginningPLRRF");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.ChangeReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientProjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientProjectStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyInvoicing).HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.DataGroup).HasMaxLength(50);

                entity.Property(e => e.DateLastReviewed).HasColumnType("datetime");

                entity.Property(e => e.Deliverables).HasMaxLength(1000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsolatesPerPlrrf).HasColumnName("IsolatesPerPLRRF");

                entity.Property(e => e.Location).HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.ProjectManager)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProposalDate).HasColumnType("datetime");

                entity.Property(e => e.RecordId).ValueGeneratedOnAdd();

                entity.Property(e => e.ReportDueDate).HasColumnType("datetime");

                entity.Property(e => e.ReportLevel).HasMaxLength(100);

                entity.Property(e => e.RowState)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StudyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserAudit)
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.HasSequence("seqCoC").StartsAt(1000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
