using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class SalesIncentiveSettings
    {
        public int SalesIncSettingsCode { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown SalesDesignation { get; set; }
        public Dropdown Region { get; set; }
        public string Model { get; set; }
        public int ModelCode { get; set; }
        public int AmountPerCar { get; set; }
        public int MinimumAchievementPer { get; set; }
        public string MonthName { get; set; }
        public string Designation { get; set; }

        public List<SalesIncentiveSettings> SalesIncentiveSettingsList { get; set; }

    }
    
}
