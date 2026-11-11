using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareSummaryReport
    {

        public string SalesFilter { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int DivisionCode { get; set; }
        public string DivisionName { get; set; }
        public int RegionCode { get; set; }
        public int BranchCode { get; set; }
        public string RegionName { get; set; }
        public string BranchName { get; set; }
        public int DesignationCode { get; set; }
        public string DesignationName { get; set; }
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }

        public List<MCareSummaryReportDetail> SummaryList { get; set; }
        public List<MCareSummaryReportDetail> DetailList { get; set; }
    }

    public class MCareSummaryReportDetail
    {
        public string RegionName { get; set; }
        public string CityName { get; set; }

        public int MCareNos { get; set; }
        public decimal MCareRevenue { get; set; }

        public int SilverNos { get; set; }
        public decimal SilverRevenue { get; set; }
        public int GoldNos { get; set; }
        public decimal GoldRevenue { get; set; }
        public int PlatinumNos { get; set; }
        public decimal PlatinumRevenue { get; set; }

        public int TotalNos { get; set; }
        public decimal TotalRevenue { get; set; }
        public int IsGrandTotal { get; set; }
        public int IsRegionTotal { get; set; }
    }
}
