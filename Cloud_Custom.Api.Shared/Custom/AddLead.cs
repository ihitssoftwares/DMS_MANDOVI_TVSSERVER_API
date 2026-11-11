using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class AddLead
    {

        public string CustomerName { get; set; }
        public string EnquireDate { get; set; }
        public string LeadNo { get; set; }
        public string EmailId { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }

        public string Mobilno { get; set; }
        public string SourceOfEnquiry { get; set; }
        public UserBase User { get; set; }
        public Dropdown Status { get; set; }
        public Dropdown Modell { get; set; }
        public Dropdown SalesExc { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown Color { get; set; }
        public Dropdown Remarks { get; set; }
        public Dropdown SourceofENQ { get; set; }
        public string ModeOfContract { get; set; }
        public string NextDate { get; set; }
        public string LeadSts { get; set; }
        public Dropdown PurchaseTime { get; set; }

        public int LeadTrnCode { get; set; }
        public int EnqTrnCode { get; set; }
        public List<AddLead> AddLeadList { get; set; }

}
}
