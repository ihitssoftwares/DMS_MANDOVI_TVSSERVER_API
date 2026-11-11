using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class PendingPickup
    {
        public string selectDate { get; set; }
        public int WorkshopCode { get; set; }
        public Dropdown Branch { get; set; }
        public string FromDate { get; set; }
        public int BookingCode { get; set; }
        public string BookingNo { get; set; }
        public string BookingName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAdd { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public string RegNo { get; set; }
        public string Model { get; set; }
        public string ServiceTypeName { get; set; }
        public string PreferedDate { get; set; }
        public string PreferedTime { get; set; }
        public List<PendingPickup> pickuplist { get; set; }
    }
}
