using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
    public class MCareServiceEntry
    {
        public int RegEntryCode { get; set; }
        public string McareEntryNo { get; set; }
        public int CustomerCode { get; set; }
        public string Customer { get; set; }
        public string VehiRegNo { get; set; }
        public string BuyDate { get; set; }
        public string Model { get; set; }
        public string Variant { get; set; }
        public string Color { get; set; }
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public int Amount { get; set; }
        public List<MCareServiceEntry> List { get; set; }
        public PopUpDetails PopUpDetails { get; set; }
    }
    public class PopUpDetails
    {
        public int RegEntryCode { get; set; }
        public int taxtypecode { get; set; }
        public int ServiceCode { get; set; }
        public string ServiceName { get; set; }
        public decimal? Amount { get; set; }
        public int Limit { get; set; }
        public int Alreadytaken { get; set; }
        public int precentage { get; set; }
        public string Description { get; set; }
        public string McareEntryNo { get; set; }
        public string Customer { get; set; }
        public string JobCardNo { get; set; }
        public decimal? DiscountAmt { get; set; }
        public decimal? TaxSum { get; set; }
        public decimal? ActualServiceCost { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public List<PopUpDetails> PopUpList { get; set; }
        public List<PopUpDetails> ViewList { get; set; }
        public Dropdown Tax { get; set; }
        public decimal? NetAmount { get; set; }
        public decimal? TaxPercentage { get; set; }

    }

}

