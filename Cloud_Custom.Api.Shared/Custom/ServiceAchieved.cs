using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class ServiceAchieved
    {
        public int SlNo { get; set; }
        public int EmpCode { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown SalesDesignation { get; set; }
        public Dropdown Parameter { get; set; }
        public decimal Value { get; set; }
        public string ParameterCode { get; set; }
        public string MonthCode { get; set; }
        public string DesignationCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmpPosition { get; set; }
        public string TeamLead { get; set; }
        public string Branch { get; set; }
        public string DealerName { get; set; }
        public string incentiveGroupname { get; set; }
        public string Status { get; set; }
        public string Mode { get; set; }
        public int UserCode { get; set; }
        public decimal? GrossPay { get; set; }
        public List<ServiceAchieved> List { get; set; }
    }
}
