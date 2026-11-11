using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class Month
    {
        public UserBase User { get; set; }
        public int SLno { get; set; }
        public int MonthCode { get; set; }
        public string Monthname { get; set; }
        public string year { get; set; }
        public string FinancialYear { get; set; }
        public string FromDate { get; set; }
        public string Todate { get; set; }
        public bool Active { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
        public string mode { get; set; }
        public List<Month> List { get; set; }
    }
}
