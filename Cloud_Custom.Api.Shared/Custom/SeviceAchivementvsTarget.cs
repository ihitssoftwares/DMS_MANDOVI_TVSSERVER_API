using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class SeviceAchivementvsTarget
    {
        public Dropdown Parameter { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown GroupBy { get; set; }

        public string IncentiveGroup { get; set; }
        public string Regions { get; set; }
        public string Branch { get; set; }
        public int TillDateAchievment { get; set; }
        public int Target { get; set; }
        public int PercentageofAchievment { get; set; }
        public int monthCode { get; set; }
        public string TargetParameter { get; set; }
        public int parameterCode { get; set; }
        public int IncentiveGroupCode { get; set; }
        public int RegionCode { get; set; }
        public int BranchCode { get; set; }
        public List<SeviceAchivementvsTarget> List { get; set; }
        public List<AchivementvsTarget> EditList { get; set; }
        public List<ServiceIncentiveLoad> ServiceIncentiveLoadList { get; set; }
        public List<LabourDetails> LabourDetailsList { get; set; }
        public List<MGADetails> MGADetailsList { get; set; }

        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeId { get; set; }
        

    }
    public class AchivementvsTarget
    {
        public string IncentiveGroup { get; set; }
        public string EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public int TillDateAchievment { get; set; }
        public int Target { get; set; }
        public int PercentageofAchievment { get; set; }
        public int monthCode { get; set; }
        public string TargetParameter { get; set; }
        public int parameterCode { get; set; }
        public int IncentiveGroupCode { get; set; }
        public int RegionCode { get; set; }
        public int BranchCode { get; set; }
        public int EmployeeCode { get; set; }
    }

    public class ServiceIncentiveLoad
    {
        public string Workshop { get; set; }
        public string RegionName { get; set; }
        public string EmployeeName { get; set; }
        public string ServiceAdvisor { get; set; }
        public string JobCardNumber { get; set; }
        public DateTime? JobCardDate { get; set; }
        public string CustomerName { get; set; }
        public string RegistrationNumber { get; set; }
        public string PsFStatus { get; set; }
        public string ServiceType { get; set; }
        public DateTime? SaleDate { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public decimal LabourAmount { get; set; }
        public decimal PartsAmount { get; set; }
        public decimal BillAmount { get; set; }
        public decimal MgaAmount { get; set; }
        public string CEI { get; set; }
        public string NPScategory { get; set; }
        public DateTime? EntryDate { get; set; }



    }

    public class LabourDetails
    {
        public string Workshop { get; set; }
        public string RegionName { get; set; }
        public string EmployeeName { get; set; }
        public string LabourName { get; set; }
        public decimal BasicAmt { get; set; }
        public decimal DiscountAmt { get; set; }
        public decimal ChargesAmt { get; set; }
        public decimal BillAmt { get; set; }
        public string JobCardNumber { get; set; }
        public DateTime JobCardDate { get; set; }
        public string CustomerName { get; set; }
        public string RegistrationNumber { get; set; }
        public string Variant { get; set; }
        public string ServiseType { get; set; }
        
        
        
        
        
        

    }
    public class MGADetails
    {
        public string Workshop { get; set; }
        public string RegionName { get; set; }
        public string EmployeeName { get; set; }
        public int VehicleCount { get; set; }
        public decimal Consumption { get; set; }
        public decimal LoadValue { get; set; }
        public decimal MGALoad { get; set; }
        public decimal ACFilter { get; set; }
        public decimal Screenwash { get; set; }
        public decimal Perfumes { get; set; }
        public decimal Mats { get; set; }
        public decimal ACGas { get; set; }
        public DateTime? MGADate { get; set; }

    }
}
