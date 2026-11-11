using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class OutLetWiseEnquiryReport
    {
        public UserBase User { get; set; }


        public string Channel { get; set; }


        public Filter Filter { get; set; }
        public string RegionName { get; set; }

        public string BranchName { get; set; }
        public int LiveEnquiry { get; set; }

        public int BranchCode { get; set; }

        public int MultipleOutlet { get; set; }

        public int FirstFollowUp { get; set; }

        public int SecondFollowUp { get; set; }

        public int TD { get; set; }

        public int HomeVisit { get; set; }

        public int ZeroFollowUp { get; set; }



        public decimal FollowPct { get; set; }

        public decimal HVPct { get; set; }

        public decimal TDPct { get; set; }

        public string TotalType { get; set; }

        public Dropdown Month { get; set; }

        public Dropdown Model { get; set; }
        public Dropdown Enquiry { get; set; }

        public int TotalCount { get; set; }
        public string LeadNo { get; set; }
        public string Name { get; set; }
        public string ModelName { get; set; }
        public string SourceofEnquiry { get; set; }
        public string Color { get; set; }
        public string Variant { get; set; }
        public string FuelType { get; set; }

        public string DseName { get; set; }

        public List<OutLetWiseEnquiryReport> List { get; set; }


    }
}
