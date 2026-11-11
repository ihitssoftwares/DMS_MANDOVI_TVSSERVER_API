using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class IncentiveProcessingApproval
    {
        public Dropdown Month { get; set; }

        public Dropdown Region { get; set; }

        public Dropdown SalesDesignation { get; set; }

        public Dropdown InsentiveType { get; set; }

        public int HDCode { get; set; }
        public int  EmployeeCode { get; set; }
        public string Empid { get; set; }
        public string IsSubmitted { get; set; }
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
        public bool Applicable { get; set; }
        public decimal TotalTarget { get; set; }
        public decimal TotalAchieved { get; set; }
        public decimal MinimumPercentageNeededForIncentive { get; set; }
        public decimal TotalAchievedPercentage { get; set; }
        public decimal IncentiveAmountAcheived { get; set; }

        public List<IncentiveProcessingApproval> IncentiveList { get; set; }
        public List<EmployeeDetails> EmployeeDetailsList { get; set; }
    }
    
}
