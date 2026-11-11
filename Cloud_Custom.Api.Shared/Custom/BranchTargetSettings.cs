using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BranchTargetSettings
    {
       
        public Dropdown Month { get; set; }
        public Dropdown Region { get; set; }

        public int BranchCode { get; set; }

        public string Branch { get; set; }
        public int target { get; set; }

        public decimal IncentiveAmount { get; set; }

        public List<BranchTargetSettings> List { get; set; }

        public int months { get; set; }

    }
   
  
}
