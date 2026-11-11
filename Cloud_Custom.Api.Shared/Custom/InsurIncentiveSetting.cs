using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class InsurIncentiveSetting
    {
        public int IncSettingsCode { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown SalesDesignation { get; set; }
        public Dropdown Region { get; set; }
        public int AmountPerCar { get; set; }
        public int PercentOfAcheievementFrom { get; set; }
        public int PercentOfAcheievementTo { get; set; }
        public string MonthName { get; set; }
        public string Designation { get; set; }

        public List<InsurIncentiveSetting> InsurIncentiveSettingList { get; set; }

    }
}
