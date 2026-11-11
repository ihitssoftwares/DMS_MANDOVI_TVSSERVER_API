using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceTargetvsAchivement
    {
        public Dropdown Month { get; set; }
        public int Monthcode { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public int IncentiveGroupCode { get; set; }
        public Dropdown WorkShop { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown MonthFrom { get; set; }
        public Dropdown MonthTo { get; set; }
        public Dropdown Parameter { get; set; }
        public int WorkShopCode { get; set; }
        public string WorkShopName { get; set; }
        public string BranchName { get; set; }
        public string ServiceAdvisor { get; set; }
        public string MonthName { get; set; }
        public int empCode { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string SlabType { get; set; }
        public int[] WorkShops { get; set; }
        public string IncentiveType { get; set; }
        public decimal Variance { get; set; }
        public int AbsoluteVariance { get; set; }
        public int Target { get; set; }

        public int PendingCount { get; set; }
        public int Achievment { get; set; }
        public List<ServiceTargetvsAchivement> List { get; set; }
        //public List<EditServiceTargetvsAchivement> EditList { get; set; }
        //public List<DetailsServiceTargetvsAchivement> DetailsList { get; set; }
    }
}
