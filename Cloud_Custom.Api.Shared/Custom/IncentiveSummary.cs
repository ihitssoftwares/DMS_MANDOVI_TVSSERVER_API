using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class IncentiveSummary
    {
        public Dropdown Month { get; set; }

        public Dropdown Delearship { get; set; }

        public Dropdown SalesDesignation { get; set; }

        public Dropdown InsentiveType { get; set; }
        public List<SummaryEmployeeDetails> EmployeeDetailsList { get; set; }
        public IncentiveSummaryEmployeeDetails IncentiveSummaryEmployeeDetails { get; set; }
    }
    public class SummaryEmployeeDetails
    {
        public int TeamLeaderEmployeeCode { get; set; }
        public string TeamLeaderName { get; set; }

        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }

        public string BranchName { get; set; }

        public decimal SalesIncentive { get; set; }
        public decimal EWIncentive { get; set; }
        public decimal GASIncentive { get; set; }
        public decimal ExchangeIncentive { get; set; }
        public decimal FinanceIncentive { get; set; }
        public decimal InsuranceIncentive { get; set; }
        public decimal MCPIncentive { get; set; }
        public decimal SPOTINCENTIVEMDOELWISE { get; set; }
        public decimal SPOTINCENTIVEDATEWISE { get; set; }
    }

    public class IncentiveSummaryEmployeeDetails
    {
        // Employee Info
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string BranchName { get; set; }

        // ---------------- SALES ----------------
        public int SalesTarget { get; set; }
        public int SalesAchieved { get; set; }
        public decimal SalesMinimumPercentage { get; set; }
        public decimal SalesAchievedPercentage { get; set; }
        public decimal SalesIncentiveAmount { get; set; }

        // ---------------- EXTENDED WARRANTY ----------------
        public int EWTarget { get; set; }
        public int EWSalesAchieved { get; set; }
        public int EWElligibleSales { get; set; }
        public decimal EWAchievedPercentage { get; set; }
        public decimal EWIncentiveAmount { get; set; }

        // ---------------- EXCHANGE ----------------
        public int ExchangeTarget { get; set; }
        public int ExchangeSalesAchieved { get; set; }
        public int ExchangeEligibleSales { get; set; }
        public decimal ExchangeAchievedPercentage { get; set; }
        public decimal ExchangeIncentiveAmount { get; set; }

        // ---------------- INSURANCE ----------------
        public int InsuranceTarget { get; set; }
        public int InsuranceSalesAchieved { get; set; }
        public int InsuranceEligibleSales { get; set; }
        public decimal InsuranceAchievedPercentage { get; set; }
        public decimal InsuranceIncentiveAmount { get; set; }

        // ---------------- FINANCE ----------------
        public int FinanceTarget { get; set; }
        public int FinanceSalesAchieved { get; set; }
        public int FinanceEligibleSales { get; set; }
        public decimal FinanceAchievedPercentage { get; set; }
        public decimal FinanceIncentiveAmount { get; set; }

        // ---------------- MCP ----------------
        public int MCPTarget { get; set; }
        public int MCPSalesAchieved { get; set; }
        public int MCPEligibleSales { get; set; }
        public decimal MCPAchievedPercentage { get; set; }
        public decimal MCPIncentiveAmount { get; set; }

        // ---------------- GAS ----------------
        public int GASTarget { get; set; }
        public int GASSalesAchieved { get; set; }
        public int GASEligibleSales { get; set; }
        public decimal GASAchievedPercentage { get; set; }
        public decimal GASIncentiveAmount { get; set; }

        // ---------------- MODEL ----------------
        public int MODELTarget { get; set; }
        public int MODELSalesAchieved { get; set; }
        public int MODELEligibleSales { get; set; }
        public decimal MODELAchievedPercentage { get; set; }
        public decimal MODELIncentiveAmount { get; set; }


        // ---------------- DATE ----------------
        public int DATETarget { get; set; }
        public int DATESalesAchieved { get; set; }
        public int DATEEligibleSales { get; set; }
        public decimal DATEAchievedPercentage { get; set; }
        public decimal DATEIncentiveAmount { get; set; }


    }
}
