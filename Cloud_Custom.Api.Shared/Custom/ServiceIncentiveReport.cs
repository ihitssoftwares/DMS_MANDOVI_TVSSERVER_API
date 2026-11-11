using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class ServiceIncentiveReport
    {
        public Dropdown Month { get; set; }
        public int Monthcode { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public Dropdown Region { get; set; }
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
        public int WorkShops { get; set; }
        public string IncentiveType { get; set; }

        public int PendingCount { get; set; }
        public decimal SlabFrom { get; set; }
        public decimal SlabTo { get; set; }
        public decimal Incentive { get; set; }
        public List<ServiceIncentiveReport> List { get; set; }
        public List<string> Columns { get; set; } = new List<string>();
        public List<Dictionary<string, string>> Rows { get; set; } = new List<Dictionary<string, string>>();
    }
}
