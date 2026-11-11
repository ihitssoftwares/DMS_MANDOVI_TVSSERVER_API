using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class DSEvsTL
    {
        public UserBase User { get; set; }
        public Dropdown TeamLeader { get; set; }
        public Dropdown DSEemp { get; set; }
        public Dropdown Branch { get; set; }
        public int DSEempCode { get; set; }
        public int TLEmpCode { get; set; }
        public int TrnCode { get; set; }
        public int SLno { get; set; }
        public string DSEempname { get; set; }
        public string TLEmpname { get; set; }
        public string Mode { get; set; }

        public DateTime ActiveFrom { get; set; }
        public DateTime Date { get; set; }
        public DateTime ActiveTo { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }

        public List<DSEvsTL> List { get; set; }
    }
}
