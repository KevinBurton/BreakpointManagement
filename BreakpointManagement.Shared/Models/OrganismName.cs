using AutoMapper;
using AutoMapper.Configuration.Annotations;
using System;

namespace BreakpointManagement.Shared.Models
{
    public class OrganismName
    {
        public int OrganismId { get; set; }
        public string Name { get; set; }
        public int OrganismFamilyId { get; set; }
        public int? OrganismSubfamilyId { get; set; }
        public int? GenusId { get; set; }
        public bool PrintOnCodeList { get; set; }
        public int? RemapTo { get; set; }
        public bool Aerobic { get; set; }
        public bool Anaerobic { get; set; }
        public bool Fungal { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] TimeStamper { get; set; }
    }
}
