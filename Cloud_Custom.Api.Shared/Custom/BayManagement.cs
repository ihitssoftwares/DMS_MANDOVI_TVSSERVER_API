using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class BayManagement
    {
        public int JobCardCode { get; set; }
        public int BayCount { get; set; }
        public string JobCardNo { get; set; }
        public string JCdate { get; set; }
        public int customerCode { get; set; }
        public string Customer { get; set; }
        public string RegNo { get; set; }
        public string phoneNo { get; set; }
        public string ChassisNo { get; set; }
        public string EngineNo { get; set; }
        public string Model { get; set; }
        public string variant { get; set; }
        public Dropdown WorkShop { get; set; }
        public List<BayManagement> BayList { get; set; }
        public BayDetails BayDetails { get; set; }

    }
    public class BayDetails
    {
        public int BayCode { get; set; }
        public string Bayname { get; set; }
        public int BayTypeCode { get; set; }
        public string BayTypename { get; set; }
        public bool Applicability { get; set; }
        public int JobCardCode { get; set; }
        public Dropdown WorkShop { get; set; }
        public List<BayDetails> BayDetailsList { get; set; }
    }
}
