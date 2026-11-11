using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class McarePerEmployee
    {
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

        public List<McarePerEmployeeDetail> SummaryList { get; set; }
        public List<McarePerEmployeeDetail> DetailList { get; set; }
    }
    public class McarePerEmployeeDetail
    {

        public int EmployeeCode { get; set; }
        public string EmployeName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
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
        
      
        public string Location { get; set; }
        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeID { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerCity { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public DateTime RegistrationDate { get; set; }

        public int PlanCode { get; set; }
        public Decimal PlanAmount { get; set; }
        public string PlanName { get; set; }
        public int MCareNos { get; set; }
        public decimal MCareRevenue { get; set; }
    }
}
