using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class SalesDumpVsDispatchDump
    {

        public Dropdown Month { get; set; }
        public Dropdown Branch { get; set; }
        public int StatusType { get; set; }
        public List<SalesDumpVsDispatchDump> SalesDumpVsDispatchDumpList { get; set; }

        public string VinNumber { get; set; }
        public string InvNo { get; set; }
        public string Date { get; set; }
        public string StoreOrBranch { get; set; }
       
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string EngineNo { get; set; }
        public string ChasisNo { get; set; }
        public string saleEngineNo { get; set; }
        public string saleChasisNo { get; set; }
        public string Status { get; set; }
        public int active { get; set; }
        public int totalRecords { get; set; }
        public string RegionName { get; set; }
        public int NOTDESPATCHED { get; set; }
        public int DESPATCHED { get; set; }
    }




   
}
