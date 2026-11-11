using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public  class LeadStatus
    {
        public int trnCode { get; set; }
        public string StoreName { get; set; }
  
        public DateTime FromDate { get; set; }
        public DateTime  ToDate { get; set; }
        public string GroupBy { get; set; }
        public int ColdCall { get; set; }
        public int RB { get; set; }
        public int LDH { get; set; }
        public int lead { get; set; }
        public int Booked { get; set; }
        public int Alloted { get; set; }
        public int Billed { get; set; }
        public int Delivered { get; set; }
        public int Exchanged { get; set; }
        public int Registration { get; set; }
        public decimal LtoB { get; set; }
        public decimal LtoR { get; set; }
        public decimal BtoR { get; set; }
        public Dropdown Type { get; set; }
        public List<LeadStatus> LeadStatusList { get; set; }
    }
}
