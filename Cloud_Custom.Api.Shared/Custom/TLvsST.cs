using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class TLvsST
    {
        public UserBase User { get; set; }
        public Dropdown Store { get; set; }
        public Dropdown TeamLeader { get; set; }
        public int TLEmpCode { get; set; }
        public int TrnCode { get; set; }
        public int SLno { get; set; }
        public string TLEmpname { get; set; }
        public string Mode { get; set; }
        public int SMempCode { get; set; }
        public string SMempname { get; set; }

        public DateTime ActiveFrom { get; set; }
        public DateTime ActiveTo { get; set; }
        public List<TLvsST> List { get; set; }
    }
}
