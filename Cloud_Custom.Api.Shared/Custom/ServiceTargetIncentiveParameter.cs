using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceTargetIncentiveParameter
    {
        public Dropdown Parameter { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public Dropdown WorkShop { get; set; }
        public Dropdown Region { get; set; }
        public int WorkShopCode { get; set; }
        public string WorkShopName { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string TargetType { get; set; }
        public int[] Regions { get; set; }
        public int Targets { get; set; }
        public string IncentiveGroupName { get; set; }
        public string BranchName { get; set; }
        public string ChannelName { get; set; }
        public Dropdown MonthFrom { get; set; }
        public Dropdown MonthTo { get; set; }
        public int PendingCount { get; set; }

        public List<ServiceTargetIncentiveParameter> List { get; set; }
        public List<EditServiceTargetIncentiveParameter> EditList { get; set; }
        public string Colorcode { get; set; }
    }
    public class EditServiceTargetIncentiveParameter
    {
        public int IncentiveGroupCode { get; set; }
        public string IncentiveGroupName { get; set; }
        public string GroupName { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public string TargetType { get; set; }
        public int PreTarget { get; set; }
        public int Target { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string WorkShopName { get; set; }
        public string ChannelName { get; set; }
        public string ChannelCode { get; set; }
        public string Colorcode { get; set; }
    }
}
