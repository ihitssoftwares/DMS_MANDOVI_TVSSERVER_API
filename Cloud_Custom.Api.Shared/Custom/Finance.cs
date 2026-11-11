using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class Finance
    {
        public UserBase User { get; set; }
        public string Mode { get; set; }
        public int FinancierCode { get; set; }
        
        public string FinancierName { get; set; }
        public string ShortName { get; set; }
        public string FinancierType { get; set; }
        public bool Active { get; set; }
        public bool MSSF { get; set; }
        
        public List<Finance> List { get; set; }
    }
}
