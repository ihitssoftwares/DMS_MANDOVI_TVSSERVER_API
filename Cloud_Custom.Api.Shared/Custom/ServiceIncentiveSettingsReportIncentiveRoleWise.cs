using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceIncentiveSettingsReportIncentiveRoleWise
    {
        public Dropdown Month { get; set; }
        public int Monthcode { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public int IncentiveGroupCode { get; set; }
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
        public string BranchName { get; set; }
        public int Target { get; set; }
        public int employeeCount { get; set; }
        public List<ServiceIncentiveSettingsReportIncentiveRoleWise> List { get; set; }
        public List<ServiceIncentiveSettingsReportIncentiveRoleWise> List2 { get; set; }
        public List<EmployeeData> DataList { get; set; }

    }
    public class EmployeeData
    {
        public string UserCode { get; set; }
        public string EmployeeName { get; set; }
        public int EmployeeCode { get; set; }
        public string DepartmentName { get; set; }

        public string MSPin { get; set; }

    }
 }
