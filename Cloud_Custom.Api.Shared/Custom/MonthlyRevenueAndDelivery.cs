using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MonthlyRevenueAndDelivery
    {
        public int MonthNo { get; set; }
        public string MonthName { get; set; }
        
        public int TotalBooking { get; set; }
       
        public int DeliveredVehicles { get; set; }
      
        public decimal Revenue { get; set; }
        public List<MonthlyRevenueAndDelivery> List { get; set; }
        public UserBase User { get; set; }
        public Dropdown WorkShop { get; set; }
    }
}
