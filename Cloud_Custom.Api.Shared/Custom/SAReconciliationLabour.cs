using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
     public class SAReconciliationLabour
    {

        public int AdvisorCode { get; set; }
        public Dropdown Month { get; set; }
        public Dropdown Region { get; set; }
        public Dropdown Branch { get; set; }
        public Dropdown NonSA { get; set; }
        public Dropdown MappedSA { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public string NonSAName { get; set; }
        public string JC { get; set; }
        public string CustomerName { get; set; }
        public string RegionName { get; set; }
        public string AdvisorName { get; set; }
        public string JCDatetime { get; set; }
        public string JCNumber { get; set; }
        public string LabourDescription { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string Phone { get; set; }
        public List<SAReconciliationLabour> List { get; set; }
        public List<SAReconciliationLabour> LobourList { get; set; }
    }
}
