using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class ServiceIncentiveProcessingLock
    {
        public Dropdown Month { get; set; }
        public List<ServiceIncentiveProcessingLock> ServiceIncentiveProcessingLockList { get; set; }
        public string Region { get; set; }
        public int  RegionCode { get; set; }
        public DateTime ProcessedDate { get; set; }
        public string ProcessedUser { get; set; }
        public int MonthCode { get; set; }
        public string MonthName { get; set; }
        public UserBase User { get; set; }
        public int IsLocked { get; set; }
    }
}
