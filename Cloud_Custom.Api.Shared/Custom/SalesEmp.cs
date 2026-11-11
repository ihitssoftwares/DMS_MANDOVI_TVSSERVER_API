using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class SalesEmp
    {
        public UserBase User { get; set; }
        public int EmployeeCode { get; set; }
        public string UserCode { get; set; }
        public int SLno { get; set; }
        public Dropdown Department { get; set; }
        public Dropdown Dearler { get; set; }
        public Dropdown Branchs { get; set; }
        public Dropdown SalesDes { get; set; }
        public Dropdown Incentive { get; set; }
        public Dropdown salesdesignation { get; set; }
        public Dropdown teamLeader { get; set; }
        public Dropdown Position { get; set; }
        public Dropdown UserRole { get; set; }
        public Dropdown Division { get; set; }
        public Dropdown Gender { get; set; }

        public Dropdown District { get; set; }
        public Dropdown Regiondd { get; set; }

        public Dropdown SeniorRegManager { get; set; }
        public string EmployeeName { get; set; }
        public string EmpPosition { get; set; }
        public string TeamLead { get; set; }
        public string Branch { get; set; }
        public string DealerName { get; set; }
        public string DesignationName { get; set; }
        public string incentiveGroupname { get; set; }
        public string Status { get; set; }
        public string MSPin { get; set; }
        public string Mode { get; set; }
        public string? DMSCode { get; set; }
        public decimal? GrossPay { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }

        public string Region {get;set;}

        public int DtCode { get; set; }
        public string MatchingName { get; set; }
        public List<SalesEmp> List { get; set; }

        public int? SRM { get; set; }
        public int? RM { get; set; }

        public bool SRMChecked
        {
            get { return SRM == 1; }
            set { SRM = value ? 1 : 0; }
        }

        public bool RMChecked
        {
            get { return RM == 1; }
            set { RM = value ? 1 : 0; }
        }
    }
}
