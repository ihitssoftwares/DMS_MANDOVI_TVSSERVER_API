using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceIncentive
    {
        public int EmployeeCode { get; set; }
        public  int SerialNO { get; set; }
        public string descriptions { get; set; }
        public string details { get; set; }
        public int Target { get; set; }
        public string Employee { get; set; }
        public string IncentiveGroup { get; set; }
        public string Branch { get; set; }
        public string Parameter { get; set; }
        public string ParameterType { get; set; }
        public int Achievment { get; set; }
        public decimal IncentiveAmount { get; set; }
        public decimal TotalIncentive { get; set; }
        public int TotalCount { get; set; }
        public string Slab { get; set; }
        public string Incentive { get; set; }
        public List<ServiceIncentive> List1 { get; set; }
        public List<ServiceIncentive> List2 { get; set; }
    }
}
