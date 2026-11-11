using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class LoadDataUpdate
    {
        public string ServiceLocation { get; set; }
        public int ServiceLocationUpdateOrder { get; set; }
        public string UpdatedUser { get; set; }
        public string Branch { get; set; }
        public string ServiceLocationUpdateTime { get; set; }
        public Dropdown serviceBranch { get; set; }
        public int ServiceLocationCode { get; set; }
        public string ServiceAdvisor { get; set; }
        public int ServiceAdvisorUpdateOrder { get; set; }
        public int ServiceAdvisorEmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string ServiceAdvisorUpdateTime { get; set; }
        public string UpdatedBranchName { get; set; }
        public List<LoadDataUpdate> List { get; set; }
        public Dropdown serviceemployee { get; set; }
        public string Technician { get; set; }
        public int TechnicianUpdateOrder { get; set; }
        public int TechnicianEmployeeCode { get; set; }
        public string TechnicianUpdateTime { get; set; }
        public string EmployeeId { get; set; }
        public string MSPin { get; set; }
        public string IncentiveGroup { get; set; }
    }
}
