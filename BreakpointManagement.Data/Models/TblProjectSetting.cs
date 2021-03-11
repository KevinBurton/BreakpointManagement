using System;
using System.Collections.Generic;

#nullable disable

namespace BreakpointManagement.Data.Models
{
    public partial class TblProjectSetting
    {
        public int RecId { get; set; }
        public int ProjectId { get; set; }
        public string SettingGroup { get; set; }
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
        public string SettingValue2 { get; set; }
        public string SettingValue3 { get; set; }
    }
}
