using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class SalesProgressReport
    {
        public KpiSummary Kpi { get; set; }
        public List<Last5MonthsSales> Last5Months { get; set; }
        public List<ModelShare> ModelShares { get; set; }
        public TopBranch TopBranch { get; set; }
        public List<RevenueSplit> RevenueSplits { get; set; }
        public List<BranchPerformance> BranchPerformances { get; set; }
        public List<DealTypePercentage> DealTypePercentages { get; set; }
        public TargetAchievement Target { get; set; }
    }

    public class KpiSummary
    {
        public decimal TotalRevenue { get; set; }
        public decimal LastMonthRevenue { get; set; }
        public decimal RevenueChangePercentage { get; set; }

        public int TotalSales { get; set; }
        public int LastMonthSales { get; set; }
        public decimal SalesChangePercentage { get; set; }

        public decimal AvgTransaction { get; set; }
        public decimal LastMonthAvgTransaction { get; set; }
        public decimal AvgTransactionChange { get; set; }

        public decimal DailyRunRate { get; set; }
        public decimal LastMonthDailyRunRate { get; set; }
        public decimal DailyRunRateChange { get; set; }
    }

 
    public class Last5MonthsSales
    {
        public string MonthName { get; set; }
        public int TotalSales { get; set; }
    }

  
    public class ModelShare
    {
        public string ModelName { get; set; }
        public int UnitsSold { get; set; }
        public decimal SharePercentage { get; set; }
    }

    
    public class TopBranch
    {
        public string BranchName { get; set; }
        public decimal TotalRevenue { get; set; }
        public int UnitsSold { get; set; }
        public decimal RevenueChangePercentage { get; set; }
        public decimal UnitsChangePercentage { get; set; }
    }

   
    public class RevenueSplit
    {
        public string RevenueType { get; set; }
        public decimal TotalRevenue { get; set; }
        public int UnitsSold { get; set; }
        public decimal RevenuePercentage { get; set; }
        public decimal UnitsPercentage { get; set; }
    }

   
    public class BranchPerformance
    {
        public string BranchName { get; set; }
        public decimal TotalRevenue { get; set; }
        public int UnitsSold { get; set; }
        public decimal AvgTransaction { get; set; }
        public decimal ContributionPercentage { get; set; }
    }

   
    public class DealTypePercentage
    {
        public string DealType { get; set; } 
        public int Units { get; set; }
        public decimal Percentage { get; set; }
    }

 
    public class TargetAchievement
    {
        public int TotalTarget { get; set; }
        public int TotalUnitsSold { get; set; }
        public decimal Percentage { get; set; }
    }

}
