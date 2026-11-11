using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
   public class LeadVSPurchaseTimeLine
    {
        public Dropdown Model { get; set; }
        public Dropdown LeadType { get; set; }

        public MonthlyLeadCount MonthlyLeads { get; set; }
        public List<FuelTypeCount> FuelTypes { get; set; }
        public List<TransmissionTypeCount> Transmissions { get; set; }
        public List<SalesExecutiveCount> SalesExecutives { get; set; }
        public List<SourceEnquiryChart> SourceEnquiries { get; set; }
    }

    public class MonthlyLeadCount
    {
        public int JANUARY { get; set; }
        public int FEBRUARY { get; set; }
        public int MARCH { get; set; }
        public int APRIL { get; set; }
        public int MAY { get; set; }
        public int JUNE { get; set; }
        public int JULY { get; set; }
        public int AUGUST { get; set; }
        public int SEPTEMBER { get; set; }
        public int OCTOBER { get; set; }
        public int NOVEMBER { get; set; }
        public int DECEMBER { get; set; }
    }

    public class FuelTypeCount
    {
        public string FuelType { get; set; }
        public int TotalCount { get; set; }
    }

    public class TransmissionTypeCount
    {
        public string Transmission { get; set; }
        public int TotalCount { get; set; }
    }


    public class SalesExecutiveCount
    {
        public string SalesExecutive { get; set; }
        public int TotalCount { get; set; }
        public int RankNo { get; set; }
    }

    public class SourceEnquiryChart
    {
        public string SourceOfEnquiry { get; set; }
        public int TotalCount { get; set; }
        public decimal Percentage { get; set; }
    }
}
