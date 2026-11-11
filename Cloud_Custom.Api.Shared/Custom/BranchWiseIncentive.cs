using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BranchWiseIncentive
    {
      
            public Dropdown Month { get; set; }
            public Dropdown IncentiveGroup { get; set; }
            public Dropdown Parameter { get; set; }
            public Dropdown Region { get; set; }
            
        public Dropdown CalculationType { get; set; }

        public int HdCode { get; set; }
        public int MonthCode { get; set; }
        public string MonthName { get; set; }
        public int IncentiveGroupCode { get; set; }
        public string IncentiveGroupName { get; set; }
        public int ParameterCode { get; set; }
        public string ParameterName { get; set; }
        public int RegionCode { get; set; }
        public string RegionName { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public int CalculationTypeCode { get; set; }
        public string CalculationTypeName { get; set; }







        public string SlabType { get; set; }
            
            
            public decimal SlabFrom { get; set; }
            public decimal SlabTo { get; set; }
            public decimal Incentive { get; set; }
       
            public List<BranchWiseIncentive> List { get; set; }
           
    }
}
