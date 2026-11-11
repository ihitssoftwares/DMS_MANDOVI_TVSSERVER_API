using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public  class SalesTarget
    {
        public int SLno { get; set; }
        public int EmployeeCode { get; set; }
        public string Store { get; set; }
        public int TeamLeadCode { get; set; }
        public string TeamLead { get; set; }
        public string DSE { get; set; }
        public int Enquire { get; set; }
        public int Booking { get; set; }
        public int RetailTarget { get; set; }
        public int Vahan { get; set; }
      
        public decimal EnquirePre { get; set; }
        public decimal Bookingpre { get; set; }
        public decimal RetailTargetPre { get; set; }
        public decimal VahanPre { get; set; }

        public Dropdown Branch { get; set; }
        public Dropdown Month { get; set; }
        public List<SalesTarget> List { get; set; }
        public UserBase User { get; set; }

    }
}
