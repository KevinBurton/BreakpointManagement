using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class TblProject
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int? ClientId { get; set; }
        public int? ClientContactId { get; set; }
        public string ClientProjectId { get; set; }
        public string ClientProjectName { get; set; }
        public string ClientProjectStatus { get; set; }
        public int? ProjectStatus { get; set; }
        public int? ProjectType { get; set; }
        public string StudyType { get; set; }
        public DateTime? ProposalDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ProjectManager { get; set; }
        public string AssistantProjectManager { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? IsolatesPerPlrrf { get; set; }
        public int? BeginningPlrrf { get; set; }
        public int? ExpectedIsolatesPerInvestigator { get; set; }
        public string DataGroup { get; set; }
        public string Notes { get; set; }
        public bool IsDataLocked { get; set; }
        public string Deliverables { get; set; }
        public string CompanyInvoicing { get; set; }
        public string Location { get; set; }
        public DateTime? DateLastReviewed { get; set; }
        public int? SponsorId { get; set; }
        public string ReportLevel { get; set; }
        public DateTime? ReportDueDate { get; set; }
        public bool Manuscript { get; set; }
        public bool Abstract { get; set; }
        public bool Poster { get; set; }
        public bool SlideSet { get; set; }
    }
}
