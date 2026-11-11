using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Department
    {
        public int Slno { get; set; }
        public UserBase User { get; set; }
        public string ShortName { get; set; }
        public string Mode { get; set; }
        public string DMSCode { get; set; }
        public List<Department> List { get; set; }
        public int DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string Remarks { get; set; }
        public Dropdown Type { get; set; }
        public string DtType { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
    }
}
