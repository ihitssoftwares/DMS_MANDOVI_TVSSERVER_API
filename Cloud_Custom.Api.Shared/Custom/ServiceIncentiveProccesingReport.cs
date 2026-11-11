using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class ServiceIncentiveProccesingReport
    {
        public Dropdown Month { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public int EmployeeCode { get; set; }
        public String  BranchName { get; set; }
        public String  IncentiveGRoup { get; set; }
        public String  TotalIncentive { get; set; }


       public int BranchCode { get; set; }
       public int incentiveCode { get; set; }
       public int parameterCode { get; set; }
       public string EmployeeName { get; set; }
       public string Parametername { get; set; }
       public string ParameterType { get; set; }
        public int Target { get; set; }
        public int OrginalAcheivement { get; set; }
        public int ActualAcheivement { get; set; }
        public string Slab { get; set; }
        public decimal Incentive { get; set; }
        public decimal IncentiveAmount { get; set; }
public List<ServiceIncentiveProccesingReport> ReportList { get; set; }
public List<ServiceIncentiveProccesingReport> MainList { get; set; }
public List<ServiceIncentiveProccesingReport> PopupList { get; set; }

      
    }
}
