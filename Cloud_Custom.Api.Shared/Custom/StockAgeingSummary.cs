using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Shared.Custom
{
  public   class StockAgeingSummary
    {
        
        public string Metric { get; set; }
        public Dropdown Type { get; set; }
        public Dropdown Model { get; set; }
        public Dropdown Variant { get; set; }
        public Dropdown Color { get; set; }
        public string Status { get; set; }
        public string GroupBy { get; set; }
        public string Particular { get; set; }
        public int Total { get; set; }
        public int NoOfStock { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalStock { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ZeroTo15 { get; set; }
        public decimal SixteenTo30 { get; set; }
        public decimal ThirtyOneTo60 { get; set; }
        public decimal SixtyOneTo90 { get; set; }
        public decimal NinetyTo180 { get; set; }
        public decimal GreaterThan180 { get; set; }
        public List<StockAgeingSummary> StockAgeingSummaryList { get; set; }
        public List<GrandTotal> GrandTotalList { get; set; }
    }
    public class GrandTotal {
        public string Particular { get; set; }
        public string Metric { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ZeroTo15 { get; set; }
        public decimal SixteenTo30 { get; set; }
        public decimal ThirtyOneTo60 { get; set; }
        public decimal SixtyOneTo90 { get; set; }
        public decimal NinetyTo180 { get; set; }
        public decimal GreaterThan180 { get; set; }
      
        
    }
}
    