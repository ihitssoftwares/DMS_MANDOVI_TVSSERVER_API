using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.General
{
    public class EmployeeHeader
    {
        public Guid EmployeeGuid { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string ReportingManager { get; set; }
        public string EmployeeAbsoluteUri { get; set; }
        public string FileName { get; set; }
        public string EmployeeId { get; set; }
        public Dropdown Designation { get; set; }
        public Dropdown Department { get; set; }
        public Dropdown Location { get; set; }
        public Dropdown Category { get; set; }
        public string ReportingManagerID { get; set; }
        public Dropdown ReportingManagerDesignation { get; set; }
        public string LWD { get; set; }
        public DateTime DOJ { get; set; }
        public bool ActiveStatus { get; set; }

    }
}
