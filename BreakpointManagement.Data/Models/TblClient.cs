using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class TblClient
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string ClientType { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string ShippingAddress { get; set; }
        public string ShippingCity { get; set; }
        public int? ShippingStateProvId { get; set; }
        public string ShippingPostalCode { get; set; }
        public int? ShippingCountryId { get; set; }
        public int? ShippingRegionId { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public int? BillingStateProvId { get; set; }
        public string BillingPostalCode { get; set; }
        public int? BillingCountryId { get; set; }
        public int? BillingRegionId { get; set; }
        public string Notes { get; set; }
        public string Website { get; set; }
        public int? ClientCode { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
