using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class SalesPerformanceReport
    {
        public Dropdown Month { get; set; }
        public string CumulativeFromMonthName { get; set; }
        public List<SalesPerformanceDetail> DetailList { get; set; } = new List<SalesPerformanceDetail>();
        public List<SalesPerformanceDetail> SummaryList { get; set; }
        public List<ChannelProductivity> MonthProductivityList { get; set; } = new List<ChannelProductivity>();
        public List<ChannelProductivity> CumulativeProductivityList { get; set; } = new List<ChannelProductivity>();
    }

    public class SalesPerformanceDetail
    {
        public int ChannelCode;

        public int BranchCode { get; set; }
        public string RegionName { get; set; }
        public string BranchName { get; set; }
        public string EmployeeName { get; set; }
        public int IsTotal { get; set; }

        public int TargetQty { get; set; }
        public int SlNo { get; set; }
        public int AchievedQty { get; set; }

        public decimal TargetAmount { get; set; }
        public decimal AchievedAmount { get; set; }

        public decimal AchievementPercent { get; set; }

        public int IsRegionTotal { get; set; }
        public int IsGrandTotal { get; set; }

        public int SRM { get; set; }
        public int AboveThreeMonthsRM_A { get; set; }
        public int BelowThreeMonthsRM_B { get; set; }
        public int TotalAB { get; set; }
        public int CurrentMonthCount { get; set; }
        public int GrandTotalManpower { get; set; }
        public int RetTarget { get; set; }
        public int RetailAch { get; set; }
        public decimal RetPercent { get; set; }
        public decimal RetPerRM_3MonthAbove { get; set; }
        public decimal RetPerRM_All { get; set; }
        public string ChannelName { get; set; }
    }

    public class ChannelProductivity
    {
        public int ChannelCode { get; set; }
        public int RM { get; set; }
        public int SRM { get; set; }
        public int TotalSalesMPCount { get; set; }
        public int RetailAch { get; set; }
        public decimal Productivity { get; set; }
    }
}
