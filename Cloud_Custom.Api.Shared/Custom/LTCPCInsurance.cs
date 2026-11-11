using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class LTCPCInsurance
    {
        public int LtcpCode { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown SalesDesignation { get; set; }
        public Dropdown Region { get; set; }
        public int AmountPerCar { get; set; }
        public int PercentOfAcheievementFrom { get; set; }
        public int PercentOfAcheievementTo { get; set; }
        public string MonthName { get; set; }
        public string Designation { get; set; }

        public List<LTCPCInsurance> LTCPCInsuranceList { get; set; }
    }
}
