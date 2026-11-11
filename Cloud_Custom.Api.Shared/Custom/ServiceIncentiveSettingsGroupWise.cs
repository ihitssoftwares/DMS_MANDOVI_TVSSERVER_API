using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceIncentiveSettingsGroupWise
    {
        public Dropdown Month { get; set; }
        public int Monthcode { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public int IncentiveGroupCode { get; set; }
        public string IncentiveGroupName { get; set; }
        public Dropdown WorkShop { get; set; }
        public Dropdown MonthFrom { get; set; }
        public Dropdown MonthTo { get; set; }
        public Dropdown Parameter { get; set; }
        public int RegionCode { get; set; }
        public string WorkShopName { get; set; }
        public string MonthName { get; set; }
        public string Colorcode { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string SlabType { get; set; }
        public int[] WorkShops { get; set; }
        public string IncentiveType { get; set; }
        public int PendingCount { get; set; }
        public decimal SlabFrom { get; set; }
        public decimal SlabTo { get; set; }
        public decimal Incentive { get; set; }
        public List<ServiceIncentiveSettingsGroupWise> List { get; set; }
        public List<EditServiceIncentiveSettingsGroupWise> EditList { get; set; }
        public List<DetailsServiceIncentiveSettingsGroupWise> DetailsList { get; set; }
    }
    public class EditServiceIncentiveSettingsGroupWise
    {
        public int IncentiveGroupCode { get; set; }
        public string GroupName { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string SlabType { get; set; }
        public decimal SlabFrom { get; set; }
        public decimal SlabTo { get; set; }
        public decimal Incentives { get; set; }
        public string IncentiveType { get; set; }
        public string IncentiveGroupName { get; set; }
    }

    public class DetailsServiceIncentiveSettingsGroupWise
    {
        public int DMonthCode { get; set; }
        public int DWorkShopCode { get; set; }
        public int DIncentiveGroupCode { get; set; }
        public Dropdown DCalculationType { get; set; }
        public string DGroupName { get; set; }
        public int DParameterCode { get; set; }
        public string DParameterName { get; set; }
        public string DSlabType { get; set; }
        public string DIncentiveType { get; set; }
        public decimal DSlabFrom { get; set; }
        public decimal DSlabTo { get; set; }
        public decimal DIncentives { get; set; }
        public int PercentOfAmount { get; set; }
    }
}
