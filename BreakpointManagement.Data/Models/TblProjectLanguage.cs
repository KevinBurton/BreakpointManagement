using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class TblProjectLanguage
    {
        public string LanguageCode { get; set; }
        public int ProjectId { get; set; }
        public int? ClientContactId { get; set; }
        public string ProjectName { get; set; }
        public string ClientProjectId { get; set; }
        public string ClientProjectName { get; set; }
        public int? ProjectStatus { get; set; }
        public int? ProjectType { get; set; }
        public string StudyType { get; set; }
        public bool? Translated { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
