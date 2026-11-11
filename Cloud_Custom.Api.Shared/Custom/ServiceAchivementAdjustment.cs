using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceAchivementAdjustment
    {
        public Dropdown Branch { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown IncentiveGroup { get; set; }
        public Dropdown Parameter { get; set; }
        public int Employecode { get; set; }
        public string EmployeeName { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public int IncentiveGroupCode { get; set; }
        public decimal AchievmentOriginal { get; set; }
        public decimal AchievmentActual { get; set; }
        public string SlabType { get; set; }
        public int Target { get; set; }
        public string IncentiveSlab { get; set; }
        public int branchcode { get; set; }
        public int monthcode { get; set; }

        public List<ServiceAchivementAdjustment> List { get; set; }
    }
}
