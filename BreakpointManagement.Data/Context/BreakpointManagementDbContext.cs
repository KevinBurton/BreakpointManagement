using Microsoft.EntityFrameworkCore;
using BreakpointManagement.Data.Models;

#nullable disable

namespace BreakpointManagement.Data.Context
{
    public partial class BreakpointManagementDbContext : DbContext
    {
        public BreakpointManagementDbContext()
        {
        }

        public BreakpointManagementDbContext(DbContextOptions<BreakpointManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBreakpoint> TblBreakpoints { get; set; }
        public virtual DbSet<TblBreakpointException> TblBreakpointExceptions { get; set; }
        public virtual DbSet<TblBreakpointHistory> TblBreakpointHistories { get; set; }
        public virtual DbSet<TblBreakpointInferred> TblBreakpointInferreds { get; set; }
        public virtual DbSet<TblBreakpointStandard> TblBreakpointStandards { get; set; }
        public virtual DbSet<TblBreakpointgroup> TblBreakpointgroups { get; set; }
        public virtual DbSet<TblBreakpointgroupmember> TblBreakpointgroupmembers { get; set; }
        public virtual DbSet<TblDrug> TblDrugs { get; set; }
        public virtual DbSet<TblDrugClass> TblDrugClasses { get; set; }
        public virtual DbSet<TblDrugSubclass> TblDrugSubclasses { get; set; }
        public virtual DbSet<TblOrganismFamily> TblOrganismFamilies { get; set; }
        public virtual DbSet<TblOrganismFamilyLanguage> TblOrganismFamilyLanguages { get; set; }
        public virtual DbSet<TblOrganismGenus> TblOrganismGenus { get; set; }
        public virtual DbSet<TblOrganismName> TblOrganismNames { get; set; }
        public virtual DbSet<TblOrganismNameLanguage> TblOrganismNameLanguages { get; set; }
        public virtual DbSet<TblOrganismSubfamily> TblOrganismSubfamilies { get; set; }
        public virtual DbSet<TblOrganismSubfamilyLanguage> TblOrganismSubfamilyLanguages { get; set; }
        public virtual DbSet<TblProject> TblProjects { get; set; }
        public virtual DbSet<TblProjectIsolate> TblProjectIsolates { get; set; }
        public virtual DbSet<TblProjectLanguage> TblProjectLanguages { get; set; }
        public virtual DbSet<TblProjectSetting> TblProjectSettings { get; set; }
        public virtual DbSet<TblProjectStatus> TblProjectStatuses { get; set; }
        public virtual DbSet<TblProjectTargetOrganism> TblProjectTargetOrganisms { get; set; }
        public virtual DbSet<TblClient> TblClients { get; set; }
        public virtual DbSet<TblContact> TblContacts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblBreakpoint>(entity =>
            {
                entity.HasKey(e => e.BreakpointId)
                    .HasName("PK_tbl_Breakpoint_2010");

                entity.HasIndex(e => new { e.ResultType, e.BpgroupId, e.DrugId, e.ProjectId }, "IX_tbl_Breakpoint")
                    .IsUnique()
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => new { e.ResultType, e.DrugId }, "Result_DrugID")
                    .HasFillFactor((byte)90);

                entity.HasIndex(e => e.ProjectId, "ix_projectid")
                    .HasFillFactor((byte)90);

                entity.Property(e => e.Bpyear).IsUnicode(false);

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DisplayedAs).IsUnicode(false);

                entity.Property(e => e.Dosage).IsUnicode(false);

                entity.Property(e => e.DosageType).IsUnicode(false);

                entity.Property(e => e.RepresentedBy).HasComment("The drugid that this drug infers its interpretion from.");
            });

            modelBuilder.Entity<TblBreakpointException>(entity =>
            {
                entity.HasComment("See tbl_Breakpoint.  An exception usually occurs when an individual species is handled differently than the rest of its genus.");

                entity.Property(e => e.BreakpointExceptionId).HasComment("A uniqe, system generated, value which identifies this breakpoint rule exception.");

                entity.Property(e => e.BreakPointType)
                    .IsUnicode(false)
                    .HasComment("The type of breakpoint, i.e. NCCLS or FDA");

                entity.Property(e => e.BreakPointYear).HasComment("The calendar year for which this exception is/was effective.");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Dosage)
                    .IsUnicode(false)
                    .HasComment("For PK/PD breakpoints, the dosage level appropriate for this breakpoint exception.");

                entity.Property(e => e.DrugId).HasComment("The drug to which this exception applies.");

                entity.Property(e => e.Intermediate).HasComment("The measure used for determining an Intermediate result.");

                entity.Property(e => e.OrganismId).HasComment("The organismid to which this breakpoint exception applies.");

                entity.Property(e => e.Resistant).HasComment("The measure used for determining a Resistant result.");

                entity.Property(e => e.Susceptible).HasComment("The measure used for determining a Susceptible result.");

                entity.Property(e => e.TestMethodId).HasComment("The microbiology testing method used for this exception.  The default being microbroth dilution.");
            });

            modelBuilder.Entity<TblBreakpointHistory>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.BreakpointId).ValueGeneratedOnAdd();

                entity.Property(e => e.BreakpointType).IsUnicode(false);

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DisplayValue).IsUnicode(false);

                entity.Property(e => e.Dosage).IsUnicode(false);

                entity.Property(e => e.DosageType).IsUnicode(false);
            });

            modelBuilder.Entity<TblBreakpointInferred>(entity =>
            {
                entity.HasKey(e => new { e.BpgroupId, e.DrugId, e.ResultType });

                entity.Property(e => e.DrugInferredFrom).HasComment("The drug upon which the interpretation is based.");
            });

            modelBuilder.Entity<TblBreakpointStandard>(entity =>
            {
                entity.Property(e => e.Bpstandard).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TblBreakpointgroup>(entity =>
            {
                entity.HasKey(e => e.BpgroupId)
                    .HasName("PK_tbl_breakpointgroup_2010");

                entity.Property(e => e.BpgroupName).IsUnicode(false);

                entity.Property(e => e.CreatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TblBreakpointgroupmember>(entity =>
            {
                entity.HasKey(e => new { e.OrganismId, e.BpgroupId })
                    .HasName("PK_tbl_breakpointgroupmember_2010");

                entity.Property(e => e.CreatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TblDrug>(entity =>
            {
                entity.HasComment("A drug is an anti-microbial agent.");

                entity.HasIndex(e => e.DrugName, "idx_DRUGNAME_u1")
                    .IsUnique()
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.DrugSubclassId, "idx_DrugName_n1")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.DrugId)
                    .ValueGeneratedNever()
                    .HasComment("A unique, system generated value which identifies this drug.");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DrugAbbr)
                    .IsUnicode(false)
                    .HasComment("An abbreviated form of the drug name.");

                entity.Property(e => e.DrugName)
                    .IsUnicode(false)
                    .HasComment("The chemical name for the drug.");

                entity.Property(e => e.DrugSubclassId).HasComment("Drugs are grouped into sub-classes.");

                entity.Property(e => e.ForPublicUse).HasComment("Can this drug appear in public domain media?");

                entity.HasOne(d => d.DrugSubclass)
                    .WithMany(p => p.TblDrugs)
                    .HasForeignKey(d => d.DrugSubclassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_Drug_tbl_DrugSubclass");
            });

            modelBuilder.Entity<TblDrugClass>(entity =>
            {
                entity.HasComment("A drug class is a major grouping of anti-microbial agents.");

                entity.Property(e => e.DrugClassId).HasComment("A unique, system generated value identifying this drug class.");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DrugClassAbbr).IsUnicode(false);

                entity.Property(e => e.DrugClassName)
                    .IsUnicode(false)
                    .HasComment("The name given to this drug class.");
            });

            modelBuilder.Entity<TblDrugSubclass>(entity =>
            {
                entity.HasComment("A drug sub-class is a minor grouping of anti-microbial agents.");

                entity.Property(e => e.DrugSubclassId).HasComment("A unique, system generated value identifying this sub-class.");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.DrugClassId).HasComment("The major grouping under which this sub-class falls.");

                entity.Property(e => e.DrugSubclassAbbr).IsUnicode(false);

                entity.Property(e => e.DrugSubclassName)
                    .IsUnicode(false)
                    .HasComment("The name of the sub-class.");

                entity.HasOne(d => d.DrugClass)
                    .WithMany(p => p.TblDrugSubclasses)
                    .HasForeignKey(d => d.DrugClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl_DrugSubclass_tbl_DrugClass");
            });

            modelBuilder.Entity<TblOrganismFamily>(entity =>
            {
                entity.HasComment("An organism family is a grouping of species.  By default the NCCLS grouping is used.");

                entity.Property(e => e.OrganismFamilyId).HasComment("A unique, user assigned, identifier for this grouping of organisms.");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.GramType)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.OrganismFamilyName)
                    .IsUnicode(false)
                    .HasComment("The name of this organism grouping.");

                entity.Property(e => e.OrganismGrouping).IsUnicode(false);
            });

            modelBuilder.Entity<TblOrganismFamilyLanguage>(entity =>
            {
                entity.HasKey(e => new { e.LanguageCode, e.OrganismFamilyId });

                entity.Property(e => e.LanguageCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.GramType)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<TblOrganismGenus>(entity =>
            {
                entity.HasKey(e => e.GenusId)
                    .HasName("PK_tbl_Genus");

                entity.HasIndex(e => e.GenusName, "IX_tbl_Genus")
                    .IsUnique()
                    .HasFillFactor((byte)80);

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.GenusName).IsUnicode(false);
            });

            modelBuilder.Entity<TblOrganismName>(entity =>
            {
                entity.HasComment("Each record in this table represents an organism species.  OrganismId codes over 9000 represent phenotype codes used for reporting purposes only.");

                entity.HasIndex(e => e.OrganismFamilyId, "OrganismFamilyId")
                    .HasFillFactor((byte)80);

                entity.HasIndex(e => e.OrganismName, "UI_tbl_OrganismName")
                    .IsUnique()
                    .HasFillFactor((byte)80);

                entity.Property(e => e.OrganismId)
                    .ValueGeneratedNever()
                    .HasComment("A unique, user generated, identifier for this species.");

                entity.Property(e => e.Aerobic).HasComment("Can this organism grow aerobically?");

                entity.Property(e => e.Anaerobic).HasComment("Can this organism grow anaerobically?");

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.Fungal).HasComment("Can this organism grow aerobically?");

                entity.Property(e => e.OrganismFamilyId).HasComment("The organism family to which this species belongs.");

                entity.Property(e => e.OrganismName)
                    .IsUnicode(false)
                    .HasComment("The genus and species name.");

                entity.Property(e => e.OrganismSubfamilyId).HasComment("The breakpoint organism group to use for this species.");

                entity.Property(e => e.PrintOnCodeList).HasComment("Should this code appear on public domain lists?");

                entity.Property(e => e.RemapTo).HasComment("Used for older species names, to remap their occurence to the correct name.");

                entity.Property(e => e.TimeStamper)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<TblOrganismNameLanguage>(entity =>
            {
                entity.HasKey(e => new { e.LanguageCode, e.OrganismId });

                entity.HasIndex(e => e.OrganismFamilyId, "idx_OrganismNameLanguage_OrganismFamilyId")
                    .HasFillFactor((byte)80);

                entity.Property(e => e.LanguageCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy).IsUnicode(false);
            });

            modelBuilder.Entity<TblOrganismSubfamily>(entity =>
            {
                entity.Property(e => e.OrganismSubfamilyId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy).IsUnicode(false);

                entity.Property(e => e.OrganismSubfamilyName).IsUnicode(false);

                entity.HasOne(d => d.OrganismFamily)
                    .WithMany(p => p.TblOrganismSubfamilies)
                    .HasForeignKey(d => d.OrganismFamilyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganismSubfamily_OrgamismFamily");
            });

            modelBuilder.Entity<TblOrganismSubfamilyLanguage>(entity =>
            {
                entity.HasKey(e => new { e.LanguageCode, e.OrganismSubfamilyId });

                entity.Property(e => e.LanguageCode)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CreatedBy).IsUnicode(false);
            });
            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.ToTable("tbl_Project");

                entity.HasComment("A project is a reason for collecting data.  We perform projects on behalf of client sites.  Data is either generated here at IHMA, or collected from investigating sites for a project.");

                entity.Property(e => e.ProjectId).HasComment("A unique, system generated, identifier for this project.");

                entity.Property(e => e.AssistantProjectManager).HasMaxLength(50);

                entity.Property(e => e.BeginningPlrrf)
                    .HasColumnName("BeginningPLRRF")
                    .HasComment("For clinical studies, the first PLRRF number to use on the documentation");

                entity.Property(e => e.ClientContactId).HasComment("The record in tbl_Site which identifies the sponsor of this project.");

                entity.Property(e => e.ClientId).HasComment("Id from Client table");

                entity.Property(e => e.ClientProjectId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("An abbreviated identifer assigned to this project by our client.");

                entity.Property(e => e.ClientProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasComment("The name of the project as it is known by our client.");

                entity.Property(e => e.ClientProjectStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyInvoicing)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DataGroup).HasMaxLength(50);

                entity.Property(e => e.DateLastReviewed).HasColumnType("datetime");

                entity.Property(e => e.Deliverables).HasMaxLength(1000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ExpectedIsolatesPerInvestigator).HasComment("Total number of isolates each investigator is expected to provide.");

                entity.Property(e => e.IsolatesPerPlrrf)
                    .HasColumnName("IsolatesPerPLRRF")
                    .HasComment("For clinical trials, the number of isolates each PLRRF contains.");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.ProjectManager).HasMaxLength(50);

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectStatus).HasComment("An indicator of the current activity level of the project.  Use tbl_Codes, group PROJECTSTATUS, for validation.  The default is PENDING.");

                entity.Property(e => e.ProjectType).HasComment("A classification of project.  Use tbl_Codes, group PROJECTTYPE, for validation. ");

                entity.Property(e => e.ProposalDate).HasColumnType("datetime");

                entity.Property(e => e.ReportDueDate).HasColumnType("datetime");

                entity.Property(e => e.ReportLevel).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StudyType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Type of Clinical or Surviellance study.  Validate vs tbl_Codes (STUDYTYPE)");
            });

            modelBuilder.Entity<TblProjectIsolate>(entity =>
            {
                entity.HasKey(e => new { e.ProjectId, e.OrganismId });

                entity.ToTable("tbl_ProjectIsolates");
            });

            modelBuilder.Entity<TblProjectLanguage>(entity =>
            {
                entity.HasKey(e => new { e.LanguageCode, e.ProjectId });

                entity.ToTable("tbl_ProjectLanguage");

                entity.Property(e => e.LanguageCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ClientProjectId).HasMaxLength(50);

                entity.Property(e => e.ClientProjectName).HasMaxLength(100);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ProjectName).HasMaxLength(100);

                entity.Property(e => e.StudyType).HasMaxLength(50);
            });

            modelBuilder.Entity<TblProjectSetting>(entity =>
            {
                entity.HasKey(e => e.RecId);

                entity.ToTable("tbl_ProjectSettings");

                entity.HasIndex(e => new { e.ProjectId, e.SettingGroup, e.SettingName }, "IX_tbl_ProjectSettings")
                    .IsUnique()
                    .HasFillFactor((byte)90);

                entity.Property(e => e.RecId).HasColumnName("recID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.SettingGroup)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SettingName).HasMaxLength(50);

                entity.Property(e => e.SettingValue).HasMaxLength(255);

                entity.Property(e => e.SettingValue2).HasMaxLength(255);
            });

            modelBuilder.Entity<TblProjectStatus>(entity =>
            {
                entity.HasKey(e => e.ProjectStatusId);

                entity.ToTable("tbl_ProjectStatus");

                entity.HasIndex(e => new { e.ProjectId, e.IsolateId }, "UI_tbl_ProjectStatus")
                    .IsUnique()
                    .HasFillFactor((byte)80);

                entity.Property(e => e.Comments).HasMaxLength(1000);
            });

            modelBuilder.Entity<TblProjectTargetOrganism>(entity =>
            {
                entity.HasKey(e => e.ProjectTargetOrganismId);

                entity.ToTable("tbl_ProjectTargetOrganism");

                entity.HasIndex(e => new { e.ProjectId, e.OrganismId }, "NonClusteredIndex-20181009-100852")
                    .IsUnique()
                    .HasFillFactor((byte)90);

                entity.Property(e => e.ProjectTargetOrganismId)
                    .HasColumnName("ProjectTargetOrganismID")
                    .HasComment("This table is used to hold any targeted Organisms at the Project level");

                entity.Property(e => e.InsertDatetime)
                    .HasColumnType("datetime")
                    .HasColumnName("INSERT_DATETIME");

                entity.Property(e => e.InsertUser)
                    .HasMaxLength(50)
                    .HasColumnName("INSERT_USER");

                entity.Property(e => e.OrganismId).HasColumnName("OrganismID");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            });

            modelBuilder.Entity<TblClient>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("tbl_Client");

                entity.Property(e => e.BillingAddress)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.BillingCity)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.BillingPostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ClientType)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateEntered).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.FaxNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingAddress)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingCity)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingPostalCode)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<TblContact>(entity =>
            {
                entity.HasKey(e => e.ContactId);

                entity.ToTable("tbl_Contact");

                entity.HasComment("A contact represents a person with whom we transact business.  Typically, they are an investigator, or someone associated with a study.");

                entity.HasIndex(e => e.ContactId, "ix_tbl_Contact_contid_prefixname_fname_mname_lname");

                entity.Property(e => e.ContactId).HasComment("A unique, system generated, identifier for this person.");

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId).HasComment("The country they are located in.");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasComment("Their current position at the site they are associated with.");

                entity.Property(e => e.LastName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PostalCode)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PrefixName)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("Any formal prefixes to their name, i.e. Dr. or Major");

                entity.Property(e => e.SiteId)
                    .HasColumnName("SiteID")
                    .HasComment("The site (hospital or lab) with which they are currently associated.");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Usually the list of credentials, i.e. PhD, MT-ASCP, etc.");

                entity.Property(e => e.UpdateSource)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasComment("Where did this entry come from");
            });


            modelBuilder.HasSequence("seqCoC").StartsAt(1000);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
