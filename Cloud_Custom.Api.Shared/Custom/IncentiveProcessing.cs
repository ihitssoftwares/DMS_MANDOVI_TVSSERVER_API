using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class IncentiveProcessing
    {
        public Dropdown Month { get; set; }

        public Dropdown Region { get; set; }

        public Dropdown SalesDesignation { get; set; }

        public Dropdown InsentiveType { get; set; }

        public int HDCode { get; set; }
        public int EmployeeCode { get; set; }
        public string Empid { get; set; }
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }
        public string IsSubmitted { get; set; }
        public bool Applicable { get; set; }
        public decimal TotalTarget { get; set; }
        public decimal TotalAchieved { get; set; }
        public decimal MinimumPercentageNeededForIncentive { get; set; }
        public decimal TotalAchievedPercentage { get; set; }
        public decimal IncentiveAmountAcheived { get; set; }

        public List<IncentiveProcessing> IncentiveList { get; set; }
        public List<EmployeeDetails> EmployeeDetailsList { get; set; }
    }

    public class EmployeeDetails
    {
        public int EmployeeCode { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string ModelName { get; set; }
        public decimal PerUnitIncentiveAmount { get; set; }
        public int AchievedTarget { get; set; }

        public decimal IncentiveAmountAchieved { get; set; }
    }
}
